using FluentAssertions;
using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public abstract class AbstractOffsetDatePersistenceTests<TUserType> : AbstractPersistenceTests<OffsetDate, TUserType>
    where TUserType : new()
    {
        protected AbstractOffsetDatePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }

        [Theory]
        [NodaTimeAutoData]
        public void CanQueryByLocalDate(TestEntity<OffsetDate> testValue)
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
        public void CanQueryWithGreaterThan(List<TestEntity<OffsetDate>> testEntities)
        {
            AddToDatabase(testEntities.ToArray());

            var minimum = testEntities.OrderBy(x => x.TestProperty.Date).First().TestProperty;

            using (var session = SessionFactory.OpenSession())
            using (var trans = session.BeginTransaction())
            {
                var foundEntities = session.Query<TestEntity<OffsetDate>>().Where(x => x.TestProperty.Date > minimum.Date).ToList();
            }
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public void CanQueryWithLessThan(List<TestEntity<OffsetDate>> testEntities)
        {
            AddToDatabase(testEntities.ToArray());

            var minimum = testEntities.Select(x => x.TestProperty.Date).Min();

            using (var session = SessionFactory.OpenSession())
            using (var trans = session.BeginTransaction())
            {
                var foundEntities = session.Query<TestEntity<OffsetDate>>().Where(x => x.TestProperty.Date < minimum).ToList();
            }
        }

    }
}
