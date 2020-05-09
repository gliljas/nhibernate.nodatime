using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public abstract class AbstractInstantPersistenceTests<TUserType> : AbstractPersistenceTests<Instant, TUserType>
          where TUserType : new()

    {
        protected AbstractInstantPersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public void CanQueryWithGreaterThan(List<TestEntity<Instant>> testEntities)
        {
            AddToDatabase(testEntities.ToArray());

            var minimum = testEntities.Select(x => x.TestProperty).Min();

            using (var session = SessionFactory.OpenSession())
            using (var trans = session.BeginTransaction())
            {
                var foundEntities = session.Query<TestEntity<Instant>>().Where(x => x.TestProperty > minimum).ToList();
            }
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public void CanQueryWithLessThan(List<TestEntity<Instant>> testEntities)
        {
            AddToDatabase(testEntities.ToArray());

            var minimum = testEntities.Select(x => x.TestProperty).Min();

            using (var session = SessionFactory.OpenSession())
            using (var trans = session.BeginTransaction())
            {
                var foundEntities = session.Query<TestEntity<Instant>>().Where(x => x.TestProperty < minimum).ToList();
            }
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public void CanQueryWithPlus(TestEntity<Instant> testEntity)
        {
            AddToDatabase(testEntity);

            var minimum = testEntity.TestProperty.Plus(Duration.FromHours(1));

            using (var session = SessionFactory.OpenSession())
            using (var trans = session.BeginTransaction())
            {
                var foundEntities = session.Query<TestEntity<Instant>>().Where(x => x.TestProperty == minimum).ToList();
            }
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public void CanQueryWithMinus(TestEntity<Instant> testEntity)
        {
            AddToDatabase(testEntity);

            var minimum = testEntity.TestProperty.Minus(Duration.FromHours(1));

            using (var session = SessionFactory.OpenSession())
            using (var trans = session.BeginTransaction())
            {
                var foundEntities = session.Query<TestEntity<Instant>>().Where(x => x.TestProperty.Minus(Duration.FromHours(1)) == minimum).ToList();
            }
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public void CanQueryByWithOffset(TestEntity<Instant> testEntity)
        {
            AddToDatabase(testEntity);

            var minimum = testEntity.TestProperty.WithOffset(Offset.FromHours(3));

            using (var session = SessionFactory.OpenSession())
            using (var trans = session.BeginTransaction())
            {
                var foundEntities = session.Query<TestEntity<Instant>>().Where(x => x.TestProperty.WithOffset(Offset.FromHours(3)) == minimum).ToList();
            }
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public void CanQueryByToDateTimeOffset(TestEntity<Instant> testEntity)
        {
            AddToDatabase(testEntity);

            var minimum = testEntity.TestProperty.ToDateTimeOffset();

            using (var session = SessionFactory.OpenSession())
            using (var trans = session.BeginTransaction())
            {
                var foundEntities = session.Query<TestEntity<Instant>>().Where(x => x.TestProperty.ToDateTimeOffset() == minimum).ToList();
            }
        }

        
    }
}
