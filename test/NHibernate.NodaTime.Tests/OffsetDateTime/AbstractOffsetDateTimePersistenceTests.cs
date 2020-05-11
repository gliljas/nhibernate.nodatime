using FluentAssertions;
using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public abstract class AbstractOffsetDateTimePersistenceTests<TUserType> : AbstractPersistenceTests<OffsetDateTime, TUserType>
    where TUserType : new()
    {
        protected AbstractOffsetDateTimePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }

        [Theory]
        [NodaTimeAutoData]
        public void CanQueryByLocalDate(TestEntity<OffsetDateTime> testValue)
        {
            var date = testValue.TestProperty.Date;

            AddToDatabase(testValue);

            ExecuteWithQueryable(q =>
            {
                var list = q.Where(x => x.TestProperty.Date == date).ToList();
                    list.Should().HaveCount(1);
            });
        }

        [Theory]
        [NodaTimeAutoData]
        public void CanQueryByWithOffset(TestEntity<OffsetDate> testValue)
        {
            var date = testValue.TestProperty.Date.WithOffset(Offset.FromHours(3));

            AddToDatabase(testValue);

            ExecuteWithQueryable(q =>
            {
                var list = q.Where(x => x.TestProperty.Date.WithOffset(Offset.FromHours(3)) == date).ToList();
                    list.Should().HaveCount(1);
                
            });
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public void CanQueryWithGreaterThan(List<TestEntity<OffsetDateTime>> testEntities)
        {
            AddToDatabase(testEntities.ToArray());

            var minimum = testEntities.Select(x => x.TestProperty).Min();

            ExecuteWithQueryable(q =>
            {
                var foundEntities = q.Where(x => x.TestProperty.Date > minimum.Date).ToList();
            });
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public void CanQueryWithLessThan(List<TestEntity<OffsetDateTime>> testEntities)
        {
            AddToDatabase(testEntities.ToArray());

            var minimum = testEntities.Select(x => x.TestProperty).Min();

            ExecuteWithQueryable(q =>
            {
                var foundEntities = q.Where(x => x.TestProperty.Date < minimum.Date).ToList();
            });
        }

    }
}
