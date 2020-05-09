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
        public void CanQueryByLocalHour(TestEntity<OffsetTime> testValue)
        {
            var date = testValue.TestProperty.Hour;

            AddToDatabase(testValue);

            using (var session = SessionFactory.OpenSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    var list = session.Query<TestEntity<OffsetTime>>().Where(x => x.TestProperty.Hour == date).ToList();
                    list.Should().HaveCount(1);
                }
            }
        }

        [Theory]
        [NodaTimeAutoData]
        public void CanQueryByWithOffset(TestEntity<OffsetTime> testValue)
        {
            var date = testValue.TestProperty.WithOffset(Offset.FromHours(3));

            AddToDatabase(testValue);

            using (var session = SessionFactory.OpenSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    var list = session.Query<TestEntity<OffsetTime>>().Where(x => x.TestProperty.WithOffset(Offset.FromHours(3)) == date).ToList();
                    list.Should().HaveCount(1);
                }
            }
        }

    }
}
