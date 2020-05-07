using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;

namespace NHibernate.NodaTime.Tests
{
    public class InstantAsUtcDbTimestampTypePersistenceTests : AbstractPersistenceTests<Instant, InstantAsUtcDbTimestampType>
    {
        public InstantAsUtcDbTimestampTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }
    }
}
