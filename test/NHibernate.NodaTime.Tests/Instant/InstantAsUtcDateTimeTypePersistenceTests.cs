using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;

namespace NHibernate.NodaTime.Tests
{
    public class InstantAsUtcDateTimeTypePersistenceTests : AbstractInstantPersistenceTests<InstantAsUtcDateTimeType>
    {
        public InstantAsUtcDateTimeTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }
    }
}
