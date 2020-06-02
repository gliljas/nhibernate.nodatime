using NHibernate.NodaTime.Tests.Fixtures;

namespace NHibernate.NodaTime.Tests
{
    public class BclDateTimeZoneTypePersistenceTests : AbstractDateTimeZoneTypePersistenceTests<BclDateTimeZoneType>
    {
        public BclDateTimeZoneTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {
        }
    }
}