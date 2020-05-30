using FluentAssertions;
using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;
using System;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public abstract class AbstractLocalDatePersistenceTests<TUserType> : AbstractPersistenceTests<LocalDate, TUserType>
    where TUserType : new()
    {
        protected AbstractLocalDatePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {
        }

        [SkippableFact]
        public virtual void SupportsAtMidnight()
        {
            SupportsPropertyOrMethod(x => x.AtMidnight());
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsAtStartOfDayInZone(DateTimeZone dateTimeZone)
        {
            SupportsPropertyOrMethod(x => x.AtStartOfDayInZone(dateTimeZone));
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsCompareTo(LocalDate localDate)
        {
            SupportsPropertyOrMethod(x => x.CompareTo(localDate));
        }

        [SkippableFact]
        public virtual void SupportsDay()
        {
            SupportsPropertyOrMethod(x => x.Day);
        }

        [SkippableFact]
        public virtual void SupportsDayOfWeek()
        {
            SupportsPropertyOrMethod(x => x.DayOfWeek);
        }

        [SkippableFact]
        public virtual void SupportsDayOfYear()
        {
            SupportsPropertyOrMethod(x => x.DayOfYear);
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsEquals(LocalDate localDate)
        {
            SupportsPropertyOrMethod(x => x.Equals(localDate));
        }

        [SkippableFact]
        public virtual void SupportsEra()
        {
            SupportsPropertyOrMethod(x => x.Era);
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsMax(LocalDate localDate)
        {
            SupportsPropertyOrMethod(x => LocalDate.Max(x, localDate));
        }

        //[SkippableFact]
        //[NodaTimeAutoData]
        //public virtual void SupportsFromDateTime(DateTime dateTime)
        //{
        //    SupportsPropertyOrMethod(x => x.Equals(localDateTime));
        //}
        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsMin(LocalDate localDate)
        {
            SupportsPropertyOrMethod(x => LocalDate.Min(x, localDate));
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsMinusLocalDate(LocalDate localDate)
        {
            SupportsPropertyOrMethod(x => x.Minus(localDate));
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsMinusLocalDateOperator(LocalDate localDate)
        {
            SupportsPropertyOrMethod(x => x - localDate);
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsMinusPeriod(Period period)
        {
            SupportsPropertyOrMethod(x => x.Minus(period));
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsMinusPeriodOperator(Period period)
        {
            SupportsPropertyOrMethod(x => x - period);
        }

        [SkippableFact]
        public virtual void SupportsMonth()
        {
            SupportsPropertyOrMethod(x => x.Month);
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsNext(IsoDayOfWeek isoDayOfWeek)
        {
            SupportsPropertyOrMethod(x => x.Next(isoDayOfWeek));
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsPlusDays(int days)
        {
            SupportsPropertyOrMethod(x => x.PlusDays(days));
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsPlusMonths(int months)
        {
            SupportsPropertyOrMethod(x => x.PlusMonths(months));
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsPlusPeriod(Period period)
        {
            SupportsPropertyOrMethod(x => x.Plus(period));
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsPlusPeriodOperator(Period period)
        {
            SupportsPropertyOrMethod(x => x + period);
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsPlusYears(int years)
        {
            SupportsPropertyOrMethod(x => x.PlusYears(years));
        }

        [SkippableFact]
        public virtual void SupportsToDateTimeUnspecified()
        {
            SupportsPropertyOrMethod(x => x.ToDateTimeUnspecified(), x => x.Kind.Should().Be(DateTimeKind.Unspecified));
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