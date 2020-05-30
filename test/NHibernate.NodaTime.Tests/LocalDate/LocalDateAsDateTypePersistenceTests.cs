using NHibernate.NodaTime.Tests.Fixtures;

namespace NHibernate.NodaTime.Tests
{
    public class LocalDateAsDateTypePersistenceTests : AbstractLocalDatePersistenceTests<LocalDateAsDateType>
    {
        public LocalDateAsDateTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {
        }
    }
}