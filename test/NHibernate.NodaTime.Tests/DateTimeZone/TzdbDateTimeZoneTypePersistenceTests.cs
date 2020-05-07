using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public class TzdbDateTimeZoneTypePersistenceTests : AbstractPersistenceTests<DateTimeZone, TzdbDateTimeZoneType>
    {
        public TzdbDateTimeZoneTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public void CanQueryByZoneId(List<TestEntity<DateTimeZone>> testEntities)
        {
            AddToDatabase(testEntities.ToArray());

            var zoneId = testEntities.First().TestProperty.Id;

            using (var session = SessionFactory.OpenSession())
            using (var trans = session.BeginTransaction())
            {
                var foundEntities = session.Query<TestEntity<DateTimeZone>>().Where(x => x.TestProperty.Id == zoneId).ToList();
            }
        }

    }
}
