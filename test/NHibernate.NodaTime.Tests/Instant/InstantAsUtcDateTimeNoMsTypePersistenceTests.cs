using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;

namespace NHibernate.NodaTime.Tests
{
    public class InstantAsUtcDateTimeNoMsTypePersistenceTests : AbstractPersistenceTests<Instant, InstantAsUtcDateTimeNoMsType>
    {
        public InstantAsUtcDateTimeNoMsTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }
    }
}
