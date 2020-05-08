using FluentAssertions;
using NHibernate.Linq;
using NHibernate.NodaTime.Tests.Fixtures;
using NHibernate.UserTypes;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public abstract class AbstractDateIntervalPersistenceTests<TUserType> : AbstractPersistenceTests<DateInterval, TUserType>
        where TUserType : ICompositeUserType, new()
    {
        protected AbstractDateIntervalPersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public void CanQueryByLinq2(List<TestEntity<DateInterval>> testEntities)
        {
            AddToDatabase(testEntities.ToArray());

            var start = testEntities.First().TestProperty;

            using (var session = SessionFactory.OpenSession())
            using (var trans = session.BeginTransaction())
            {
                var foundEntities = session.Query<TestEntity<DateInterval>>().Where(x => x.TestProperty == (DateIntervalWrapper)start).ToList();
            }
        }

        
    }
}
