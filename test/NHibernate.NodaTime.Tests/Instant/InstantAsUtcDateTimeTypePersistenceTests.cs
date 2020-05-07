using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;

namespace NHibernate.NodaTime.Tests
{
    public class InstantAsUtcDateTimeTypePersistenceTests : AbstractPersistenceTests<Instant, InstantAsUtcDateTimeType>
    {
        public InstantAsUtcDateTimeTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }
    }
}
