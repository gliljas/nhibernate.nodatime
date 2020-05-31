using NHibernate.NodaTime.Tests.Fixtures;

namespace NHibernate.NodaTime.Tests
{
    public class OffsetAsInt32SecondsTypePersistenceTests : AbstractOffsetPersistenceTests<OffsetAsInt32SecondsType>
    {
        public OffsetAsInt32SecondsTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {
        }
    }
}