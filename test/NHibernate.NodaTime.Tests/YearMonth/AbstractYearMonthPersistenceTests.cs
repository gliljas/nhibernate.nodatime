using AutoFixture.Xunit2;
using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public abstract class AbstractYearMonthPersistenceTests<TUserType> : AbstractPersistenceTests<YearMonth, TUserType>
    where TUserType : new()
    {
        protected AbstractYearMonthPersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {
        }

        [SkippableFact]
        public virtual void SupportsMonth()
        {
            SupportsPropertyOrMethod(x => x.Month);
        }

        [SkippableTheory]
        [AutoData]
        public virtual void SupportsOnDayOfMonth(int day)
        {
            SupportsPropertyOrMethod(x => x.OnDayOfMonth(day));
        }

        [SkippableFact]
        public virtual void SupportsToDateInterval()
        {
            SupportsPropertyOrMethod(x => x.ToDateInterval());
        }

        [SkippableFact]
        public virtual void SupportsYear()
        {
            SupportsPropertyOrMethod(x => x.Year);
        }

        [SkippableFact]
        public virtual void SupportsYearOfEra()
        {
            SupportsPropertyOrMethod(x => x.YearOfEra);
        }
    }
}