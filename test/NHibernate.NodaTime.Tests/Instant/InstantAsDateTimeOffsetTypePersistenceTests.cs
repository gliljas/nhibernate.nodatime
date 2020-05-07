using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;

namespace NHibernate.NodaTime.Tests
{
    public class InstantAsDateTimeOffsetTypePersistenceTests : AbstractPersistenceTests<Instant, InstantAsDateTimeOffsetType>
    {
        public InstantAsDateTimeOffsetTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }
    }
}
