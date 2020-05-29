using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;

namespace NHibernate.NodaTime.Tests
{
    public class InstantAsUtcDateTimeNoMsTypePersistenceTests : AbstractInstantPersistenceTests<InstantAsUtcDateTimeNoMsType>
    {
        public InstantAsUtcDateTimeNoMsTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }

        protected override Instant AdjustValue(Instant value)
        {
            return value.Minus(Duration.FromMilliseconds(value.ToDateTimeUtc().Millisecond));
        }
    }
}
