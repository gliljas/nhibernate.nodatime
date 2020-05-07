using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;

namespace NHibernate.NodaTime.Tests
{
    public class TzdbDateTimeZoneTypePersistenceTests : AbstractPersistenceTests<DateTimeZone, TzdbDateTimeZoneType>
    {
        public TzdbDateTimeZoneTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }

       
    }
}
