using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public abstract class AbstractDateIntervalPersistenceTests<TUserType> : AbstractPersistenceTests<DateInterval, TUserType>
        where TUserType : new()
    {
        protected AbstractDateIntervalPersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public void CanQueryByStart(List<TestEntity<DateInterval>> testEntities)
        {
            AddToDatabase(testEntities.ToArray());

            var start = testEntities.First().TestProperty.Start;

            using (var session = SessionFactory.OpenSession())
            using (var trans = session.BeginTransaction())
            {
                var foundEntities = session.Query<TestEntity<DateInterval>>().Where(x => x.TestProperty.Start == start).ToList();
            }
        }
    }
}
