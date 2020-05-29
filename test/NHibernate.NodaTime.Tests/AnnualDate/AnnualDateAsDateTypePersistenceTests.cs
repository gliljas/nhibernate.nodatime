using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public class AnnualDateAsDateTypePersistenceTests : AbstractPersistenceTests<AnnualDate, AnnualDateAsDateType>
    {
        public AnnualDateAsDateTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsMonth(List<TestEntity<AnnualDate>> testEntities)
        {
            AddToDatabase(testEntities.ToArray());

            var month = testEntities.First().TestProperty.Month;

            using (var session = SessionFactory.OpenSession())
            using (var trans = session.BeginTransaction())
            {
                var foundEntities = session.Query<TestEntity<AnnualDate>>().Where(x=>x.TestProperty.Month == month).ToList();
            }
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsDay(List<TestEntity<AnnualDate>> testEntities)
        {
            AddToDatabase(testEntities.ToArray());

            var day = testEntities.First().TestProperty.Day;

            ExecuteWithQueryable(q =>
            {
                var foundEntities = q.Where(x => x.TestProperty.Day == day).ToList();
            });
        }

        protected override object GetTypeParameters()
        {
            return new { 
                BaseYear = 2000
            };
        }
    }


}
