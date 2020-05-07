using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;

namespace NHibernate.NodaTime.Tests
{
    public class InstantAsUtcDbTimestampTypePersistenceTests : AbstractInstantPersistenceTests<InstantAsUtcDbTimestampType>
    {
        public InstantAsUtcDbTimestampTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }
    }
}
