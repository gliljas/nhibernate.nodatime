using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public abstract class AbstractDateTimeOffsetPersistenceTests<TUserType> : AbstractPersistenceTests<DateTimeOffset, TUserType>
    where TUserType : new()
    {
        protected AbstractDateTimeOffsetPersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public void CanQueryWithGreaterThan(List<TestEntity<DateTimeOffset>> testEntities)
        {
            AddToDatabase(testEntities.ToArray());

            var minimum = testEntities.Select(x => x.TestProperty).Min();

            ExecuteWithQueryable(q =>
            {
                var foundEntities = q.Where(x => x.TestProperty > minimum).ToList();
            });
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public void CanQueryWithLessThan(List<TestEntity<DateTimeOffset>> testEntities)
        {
            AddToDatabase(testEntities.ToArray());

            var minimum = testEntities.Select(x => x.TestProperty).Min();

            ExecuteWithQueryable(q =>
            {
                var foundEntities = q.Where(x => x.TestProperty < minimum).ToList();
            });
        }
    }
}
