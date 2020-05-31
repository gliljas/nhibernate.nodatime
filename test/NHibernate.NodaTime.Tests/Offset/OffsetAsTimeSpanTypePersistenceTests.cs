using NHibernate.NodaTime.Tests.Fixtures;

namespace NHibernate.NodaTime.Tests
{
    public class OffsetAsTimeSpanTypePersistenceTests : AbstractOffsetPersistenceTests<OffsetAsTimeSpanType>
    {
        public OffsetAsTimeSpanTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {
        }
    }
}