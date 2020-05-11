using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public abstract class AbstractLocalDatePersistenceTests<TUserType> : AbstractPersistenceTests<LocalDate, TUserType>
    where TUserType : new()
    {
        protected AbstractLocalDatePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public void CanQueryWithGreaterThan(List<TestEntity<LocalDate>> testEntities)
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
        public void CanQueryWithLessThan(List<TestEntity<LocalDate>> testEntities)
        {
            AddToDatabase(testEntities.ToArray());

            var minimum = testEntities.Select(x => x.TestProperty).Min();

            ExecuteWithQueryable(q =>
            {
                var foundEntities = q.Where(x => x.TestProperty < minimum).ToList();
            });
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public void CanQueryAtMidnight(TestEntity<LocalDate> testEntity)
        {
            AddToDatabase(testEntity);

            var minimum = testEntity.TestProperty.AtMidnight();

            ExecuteWithQueryable(q =>
            {
                var foundEntities = q.Where(x => x.TestProperty.AtMidnight() == minimum).ToList();
            });
        }
    }
}
