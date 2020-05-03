using FluentAssertions;
using NHibernate.NodaTime.Tests.Fixtures;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public abstract class AbstractPersistenceTests<T,TUserType> : IClassFixture<NHibernateFixture>
    {
        private readonly NHibernateFixture _nhibernateFixture;

        protected AbstractPersistenceTests(NHibernateFixture nhibernateFixture)
        {
            _nhibernateFixture = nhibernateFixture;
            _nhibernateFixture.Configure(c => { 
            
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
