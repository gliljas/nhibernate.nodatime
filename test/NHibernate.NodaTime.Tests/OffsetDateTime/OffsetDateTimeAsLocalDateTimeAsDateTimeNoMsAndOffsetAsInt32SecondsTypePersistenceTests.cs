using NHibernate.NodaTime.Tests.Fixtures;

namespace NHibernate.NodaTime.Tests
{
    public class OffsetDateTimeAsLocalDateTimeAsDateTimeNoMsAndOffsetAsInt32SecondsTypePersistenceTests : AbstractOffsetDateTimePersistenceTests<OffsetDateTimeViaLocalDateTimeAsDateTimeNoMsAndOffsetAsInt32SecondsType>
    {
        public OffsetDateTimeAsLocalDateTimeAsDateTimeNoMsAndOffsetAsInt32SecondsTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {
        }
    }
}