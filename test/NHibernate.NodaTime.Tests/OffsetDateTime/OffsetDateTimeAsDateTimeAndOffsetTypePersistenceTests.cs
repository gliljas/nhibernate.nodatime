using NHibernate.NodaTime.Tests.Fixtures;

namespace NHibernate.NodaTime.Tests
{
    public class OffsetDateTimeAsDateTimeAndOffsetTypePersistenceTests : AbstractOffsetDateTimePersistenceTests<OffsetDateTimeAsDateTimeAndOffsetType>
    {
        public OffsetDateTimeAsDateTimeAndOffsetTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }

    }
}
