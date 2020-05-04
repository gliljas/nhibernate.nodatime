using FluentAssertions;
using NHibernate.Mapping.ByCode;
using NHibernate.NodaTime.Tests.Fixtures;
using NHibernate.UserTypes;
using System;
using System.Linq;
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
    public abstract class AbstractPersistenceTests<T,TUserType,TTestEntity> : IClassFixture<NHibernateFixture> 
        where TUserType : new()
        where TTestEntity : class, ITestEntity<T>
    {
        private readonly NHibernateFixture _nhibernateFixture;

        protected AbstractPersistenceTests(NHibernateFixture nhibernateFixture)
        {
            _nhibernateFixture = nhibernateFixture;
            _nhibernateFixture.Configure(c => {
                var mapper = new ModelMapper();
                mapper.Class<TTestEntity>(m => {
                    m.Table("`" + GetType().Name + "_" + typeof(TUserType).Name + "`" );
                    m.Id(p => p.Id, p => p.Generator(Generators.Guid));
                    m.Property(p => p.TestProperty,
                        p =>
                        {
                            p.Type<TUserType>();
                            var typeInstance = new TUserType();
                            if (typeInstance is ICompositeUserType compositeUserType)
                            {
                                p.Columns(compositeUserType.PropertyNames.Select(
                                    pn => new Action<IColumnMapper>(cm => cm.Name(pn))
                                    ).ToArray());

                            }
                        }
                    );
                });
                var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
                c.AddMapping(mapping);
            });
        }

        [Theory]
        [NodaTimeAutoData]
        public void CanSave(TestEntity<T> testValue)
        {
            testValue.TestProperty = AdjustValue(testValue.TestProperty);
            
            AddToDatabase(testValue);

            using (var session = _nhibernateFixture.SessionFactory.OpenSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    var dbEntity = session.Get<TestEntity<T>>(testValue.Id);
                    var propertyValue = AdjustValue(dbEntity.TestProperty);
                    propertyValue.Should().Be(testValue.TestProperty);
                }
            }
        }

        private void AddToDatabase(params TestEntity<T>[] testValues)
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
