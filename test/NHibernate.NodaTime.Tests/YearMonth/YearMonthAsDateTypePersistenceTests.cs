using NHibernate.NodaTime.Tests.Fixtures;

namespace NHibernate.NodaTime.Tests
{
    public class YearMonthAsDateTypePersistenceTests : AbstractYearMonthPersistenceTests<YearMonthAsDateType>
    {
        public YearMonthAsDateTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {
        }
    }
}