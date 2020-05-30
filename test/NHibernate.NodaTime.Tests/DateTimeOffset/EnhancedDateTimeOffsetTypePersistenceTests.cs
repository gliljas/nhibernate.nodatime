using NHibernate.NodaTime.Tests.Fixtures;

namespace NHibernate.NodaTime.Tests
{
    public class EnhancedDateTimeOffsetTypePersistenceTests : AbstractDateTimeOffsetPersistenceTests<EnhancedDateTimeOffsetType>
    {
        public EnhancedDateTimeOffsetTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {
        }
    }
}