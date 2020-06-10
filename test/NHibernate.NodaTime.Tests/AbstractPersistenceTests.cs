using AutoFixture;
using FluentAssertions;
using NHibernate.Linq.Visitors;
using NHibernate.Mapping.ByCode;
using NHibernate.NodaTime.Tests.Fixtures;
using NHibernate.UserTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public abstract class AbstractPersistenceTests<T, TUserType> : AbstractPersistenceTests<T, TUserType, TestEntity<T>>
        where TUserType : new()
    {
        protected AbstractPersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {
        }
    }

    public abstract class AbstractPersistenceTests<T, TUserType, TTestEntity> : IClassFixture<NHibernateFixture>
        where TUserType : new()
        where TTestEntity : class, ITestEntity<T>
    {
        private readonly IFixture _nodaFixture;
        private readonly NHibernateFixture _nhibernateFixture;

        protected AbstractPersistenceTests(NHibernateFixture nhibernateFixture)
        {
            _nodaFixture = new Fixture().Customize(new NodaTimeCustomization());
            _nhibernateFixture = nhibernateFixture;
            _nhibernateFixture.Configure(c =>
            {
                c.AddNodaTime();

                var mapper = new ModelMapper();
                mapper.Class<TTestEntity>(m =>
                {
                    m.Table("`" + typeof(TUserType).Name + "`");
                    m.Id(p => p.Id, p => p.Generator(Generators.Guid));
                    m.Property(p => p.TestProperty,
                        p =>
                        {
                            p.Type<TUserType>(GetTypeParameters());
                            var typeInstance = new TUserType();
                            if (typeInstance is ICompositeUserType compositeUserType)
                            {
                                p.Columns(compositeUserType.PropertyNames.Select(
                                    pn => new Action<IColumnMapper>(cm => cm.Name("TestProperty" + pn + "Col"))
                                    ).ToArray());
                            }
                        }
                    );
                    m.Component(component => component.TestComponent,
                        cm =>
                        {
                            cm.Property(p => p.TestComponentProperty,
                            p =>
                            {
                                p.Type<TUserType>(GetTypeParameters());
                                var typeInstance = new TUserType();
                                if (typeInstance is ICompositeUserType compositeUserType)
                                {
                                    p.Columns(compositeUserType.PropertyNames.Select(
                                        pn => new Action<IColumnMapper>(ccm => ccm.Name("TestComponentPropertyTestComponent" + pn + "Col"))
                                        ).ToArray());
                                }
                            });
                        }
                    );
                });
                var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
                c.AddMapping(mapping);
            });
        }

        protected virtual object GetTypeParameters()
        {
            return null;
        }

        protected ISessionFactory SessionFactory => _nhibernateFixture.SessionFactory;

        [Theory]
        [NodaTimeAutoData]
        public void CanSave(TTestEntity testValue)
        {
            AddToDatabase(testValue);

            using (var session = _nhibernateFixture.SessionFactory.OpenSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    var dbEntity = session.Get<TestEntity<T>>(testValue.Id);
                    var propertyValue = AdjustValue(dbEntity.TestProperty);
                    propertyValue.Should().Be(AdjustValue(testValue.TestProperty));
                }
            }
        }

        [SkippableFact]
        public void CanQueryPropertyWithLinq()
        {
            SupportsPropertyOrMethod(x => x);
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public void CanQueryPropertyWithQueryOver(List<TTestEntity> testEntities)
        {
            AddToDatabase(testEntities.ToArray());
            var testValue = testEntities.Select(x => x.TestProperty).First();

            var param = Expression.Parameter(typeof(TTestEntity));
            var lambda = Expression.Lambda(Expression.Equal(Expression.Property(param, "TestProperty"), Expression.Constant(testValue)), param) as Expression<Func<TTestEntity, bool>>;

            using (var session = SessionFactory.OpenSession())
            using (var trans = session.BeginTransaction())
            {
                var foundEntities = session.QueryOver<TTestEntity>().Where(lambda).List();
                foundEntities.Should().HaveCount(testEntities.Count(lambda.Compile()));
            }
        }

        protected void SupportsPropertyOrMethod<TValue>(Expression<Func<T, TValue>> expression, params Action<TValue>[] extraValueChecks)
        {
            var func = expression.Compile();

            var testEntities = _nodaFixture.Create<List<TTestEntity>>();

            AdjustValues(testEntities);

            AddToDatabase(testEntities.ToArray());

            TValue testValue = func(AdjustValue(testEntities[0].TestProperty));

            var param = Expression.Parameter(typeof(TTestEntity));
            var equalityLambda = Expression.Lambda(
                Expression.Equal(
                    expression.Body.Replace(expression.Parameters.First(), Expression.Property(param, "TestProperty")),
                    Expression.Constant(testValue))
                , param) as Expression<Func<TTestEntity, bool>>;

            var selectParam = Expression.Parameter(typeof(TTestEntity));
            var selectLambda = Expression.Lambda(

                   expression.Body.Replace(expression.Parameters.First(), Expression.Property(param, "TestProperty"))
               , param) as Expression<Func<TTestEntity, TValue>>;

            var expectedCount = testEntities.Count(equalityLambda.Compile());

            expectedCount.Should().NotBe(0,$"testValue:{testValue}");

            ExecuteWithQueryable(q =>
            {
                var firstEntity = q.Where(x => x.Id == testEntities[0].Id).Single();
                var loadedTestValue = func(firstEntity.TestProperty);
               // loadedTestValue.Should().Be(testValue);
                var foundEntities = q.Where(equalityLambda).Select(selectLambda).ToList();
                foundEntities.Should().HaveCount(expectedCount);
                foundEntities[0].Should().Be(testValue);
                foreach (var extraValueCheck in extraValueChecks)
                {
                    extraValueCheck(foundEntities[0]);
                }
            });
        }

        private void AdjustValues(List<TTestEntity> testEntities)
        {
            foreach (var testEntity in testEntities)
            {
                testEntity.TestProperty = AdjustValue(testEntity.TestProperty);
            }
        }

        protected void AddToDatabase(params object[] testValues)
        {
            using (var session = _nhibernateFixture.SessionFactory.OpenSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    foreach (var entity in testValues)
                    {
                        session.Save(entity);
                    }
                    trans.Commit();
                }
            }
        }

        protected void ExecuteWithQueryable(Action<IQueryable<TTestEntity>> queryableAction)
        {
            using (var session = SessionFactory.OpenSession())
            using (var trans = session.BeginTransaction())
            {
                queryableAction(session.Query<TTestEntity>());
            }
        }

        protected void ExecuteWithQueryable<TElement>(Action<IQueryable<TElement>> queryableAction)
        {
            using (var session = SessionFactory.OpenSession())
            using (var trans = session.BeginTransaction())
            {
                queryableAction(session.Query<TElement>());
            }
        }

        protected virtual T AdjustValue(T value)
        {
            return value;
        }
    }
}