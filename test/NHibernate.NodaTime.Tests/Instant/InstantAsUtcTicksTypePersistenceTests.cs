using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;

namespace NHibernate.NodaTime.Tests
{
    public class InstantAsUtcTicksTypePersistenceTests : AbstractInstantPersistenceTests<InstantAsUtcDbTimestampType>
    {
        public InstantAsUtcTicksTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }
    }
}
