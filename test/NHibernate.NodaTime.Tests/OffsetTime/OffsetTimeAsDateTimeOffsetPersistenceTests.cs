using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;

namespace NHibernate.NodaTime.Tests
{
    public class OffsetTimeAsDateTimeOffsetPersistenceTests : AbstractPersistenceTests<OffsetTime, OffsetTimeAsDateTimeOffsetType>
    {
        public OffsetTimeAsDateTimeOffsetPersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }

        protected override OffsetTime AdjustValue(OffsetTime value)
        {
            return value.WithOffset(Offset.FromSeconds(value.Offset.Seconds / 60 * 60));
        }

    }
}
