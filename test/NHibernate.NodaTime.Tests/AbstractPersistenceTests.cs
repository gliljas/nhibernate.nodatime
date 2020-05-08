using FluentAssertions;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using NHibernate.NodaTime.Linq;
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
        private readonly NHibernateFixture _nhibernateFixture;

        protected AbstractPersistenceTests(NHibernateFixture nhibernateFixture)
        {
            _nhibernateFixture = nhibernateFixture;
            _nhibernateFixture.Configure(c =>
            {

                c.LinqQueryProvider<NodaTimeLinqQueryProvider>();

                var mapper = new ModelMapper();
                mapper.Class<TTestEntity>(m =>
                {
                    m.Table("`" + GetType().Name + "_" + typeof(TUserType).Name + "`");
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
                        cm => {
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
            // testValue.TestProperty = AdjustValue(testValue.TestProperty);

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

        [SkippableTheory]
        [NodaTimeAutoData]
        public void CanQueryPropertyWithLinq(List<TTestEntity> testEntities)
        {
            AddToDatabase(testEntities.ToArray());
            var testValue = testEntities.Select(x => x.TestProperty).First();

            var param = Expression.Parameter(typeof(TTestEntity));
            var lambda = Expression.Lambda(Expression.Equal(Expression.Property(param, "TestProperty"), Expression.Constant(testValue)), param) as Expression<Func<TTestEntity, bool>>;

            using (var session = SessionFactory.OpenSession())
            using (var trans = session.BeginTransaction())
            {
                var foundEntities = session.Query<TTestEntity>().Where(lambda).ToList();
                foundEntities.Should().HaveCountGreaterOrEqualTo(1);
            }
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

        protected void AddToDatabase(params ITestEntity<T>[] testValues)
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

        protected virtual T AdjustValue(T value)
        {
            return value;
        }
    }
}
