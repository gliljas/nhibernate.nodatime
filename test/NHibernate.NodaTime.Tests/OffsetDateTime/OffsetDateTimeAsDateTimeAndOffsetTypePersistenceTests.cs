using NHibernate.NodaTime.Tests.Fixtures;

namespace NHibernate.NodaTime.Tests
{
    public class OffsetDateTimeAsLocalDateTimeAndOffsetTypePersistenceTests : AbstractOffsetDateTimePersistenceTests<OffsetDateTimeAsLocalDateTimeAndOffsetType>
    {
        public OffsetDateTimeAsLocalDateTimeAndOffsetTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }

    }
}
