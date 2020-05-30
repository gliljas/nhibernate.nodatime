using NHibernate.NodaTime.Tests.Fixtures;

namespace NHibernate.NodaTime.Tests
{
    public class InstantAsUtcTicksTypePersistenceTests : AbstractInstantPersistenceTests<InstantAsUtcTicksType>
    {
        public InstantAsUtcTicksTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {
        }
    }
}