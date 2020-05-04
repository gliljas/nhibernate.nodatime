using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;

namespace NHibernate.NodaTime.Tests
{
    public class OffsetTimeAsTimeAndOffsetTypePersistenceTests : AbstractPersistenceTests<OffsetTime, OffsetTimeAsTimeAndOffsetType>
    {
        public OffsetTimeAsTimeAndOffsetTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }

        protected override OffsetTime AdjustValue(OffsetTime value)
        {
            return value.WithOffset(Offset.FromSeconds(value.Offset.Seconds / 60 * 60));
        }

    }
}
