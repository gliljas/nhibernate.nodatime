using NHibernate.NodaTime.Tests.Fixtures;

namespace NHibernate.NodaTime.Tests
{
    public class LocalDateTimeAsDateTimeNoMsTypePersistenceTests : AbstractLocalDateTimePersistenceTests<LocalDateTimeAsDateTimeNoMsType>
    {
        public LocalDateTimeAsDateTimeNoMsTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {
        }
    }
}
