using NHibernate.NodaTime.Tests.Fixtures;

namespace NHibernate.NodaTime.Tests
{
    public class YearMonthAsYearAndMonthTypePersistenceTests : AbstractYearMonthPersistenceTests<YearMonthAsYearAndMonthType>
    {
        public YearMonthAsYearAndMonthTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {
        }
    }
}
