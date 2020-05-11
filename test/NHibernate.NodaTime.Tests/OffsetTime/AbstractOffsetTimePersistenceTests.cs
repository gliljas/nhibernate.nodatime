using FluentAssertions;
using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;
using System.Linq;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public abstract class AbstractOffsetTimePersistenceTests<TUserType> : AbstractPersistenceTests<OffsetTime, TUserType>
    where TUserType : new()
    {
        protected AbstractOffsetTimePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }

        [Theory]
        [NodaTimeAutoData]
        public void CanQueryByHour(TestEntity<OffsetTime> testValue)
        {
            var date = testValue.TestProperty.Hour;

            AddToDatabase(testValue);

            ExecuteWithQueryable(q =>
            {
                var list = q.Where(x => x.TestProperty.Hour == date).ToList();
                list.Should().HaveCount(1);
            });
        }

        [Theory]
        [NodaTimeAutoData]
        public void CanQueryByMinute(TestEntity<OffsetTime> testValue)
        {
            var date = testValue.TestProperty.Minute;

            AddToDatabase(testValue);

            ExecuteWithQueryable(q =>
            {
                var list = q.Where(x => x.TestProperty.Minute == date).ToList();
                list.Should().HaveCount(1);
            });
        }

        [Theory]
        [NodaTimeAutoData]
        public void CanQueryBySecond(TestEntity<OffsetTime> testValue)
        {
            var date = testValue.TestProperty.Second;

            AddToDatabase(testValue);

            ExecuteWithQueryable(q =>
            {
                var list = q.Where(x => x.TestProperty.Second == date).ToList();
                list.Should().HaveCount(1);
            });
        }

        [Theory]
        [NodaTimeAutoData]
        public void CanQueryByWithOffset(TestEntity<OffsetTime> testValue)
        {
            var date = testValue.TestProperty.WithOffset(Offset.FromHours(3));

            AddToDatabase(testValue);

            ExecuteWithQueryable(q =>
            {
                var list = q.Where(x => x.TestProperty.WithOffset(Offset.FromHours(3)) == date).ToList();
                list.Should().HaveCount(1);
            });
        }

    }
}
