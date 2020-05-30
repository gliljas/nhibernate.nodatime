using NHibernate.NodaTime.Tests.Fixtures;

namespace NHibernate.NodaTime.Tests
{
    public class InstantAsUtcDbTimestampTypePersistenceTests : AbstractInstantPersistenceTests<InstantAsUtcDbTimestampType>
    {
        public InstantAsUtcDbTimestampTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {
        }
    }
}