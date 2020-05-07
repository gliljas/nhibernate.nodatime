using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;

namespace NHibernate.NodaTime.Tests
{
    public class InstantAsUtcTicksTypePersistenceTests : AbstractPersistenceTests<Instant, InstantAsUtcDbTimestampType>
    {
        public InstantAsUtcTicksTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }
    }
}
