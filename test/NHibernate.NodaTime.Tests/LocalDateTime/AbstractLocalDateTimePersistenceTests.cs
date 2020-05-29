using FluentAssertions;
using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;
using System;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public abstract class AbstractLocalDateTimePersistenceTests<TUserType> : AbstractPersistenceTests<LocalDateTime, TUserType>
    where TUserType : new()
    {
        protected AbstractLocalDateTimePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }

        [SkippableFact]
        public virtual void SupportsToDateTimeUnspecified()
        {
            SupportsPropertyOrMethod(x => x.ToDateTimeUnspecified(), x => x.Kind.Should().Be(DateTimeKind.Unspecified));
        }

        [SkippableFact]
        public virtual void SupportsClockHourOfHalfDay()
        {
            SupportsPropertyOrMethod(x => x.ClockHourOfHalfDay);
        }

        [SkippableFact]
        public virtual void SupportsDate()
        {
            SupportsPropertyOrMethod(x => x.Date);
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
        public virtual void SupportsEra()
        {
            SupportsPropertyOrMethod(x => x.Era);
        }

        [SkippableFact]
        public virtual void SupportsHour()
        {
            SupportsPropertyOrMethod(x => x.Hour);
        }

        [SkippableFact]
        public virtual void SupportsMillisecond()
        {
            SupportsPropertyOrMethod(x => x.Millisecond);
        }

        [SkippableFact]
        public virtual void SupportsMinute()
        {
            SupportsPropertyOrMethod(x => x.Minute);
        }

        [SkippableFact]
        public virtual void SupportsMonth()
        {
            SupportsPropertyOrMethod(x => x.Month);
        }

        [SkippableFact]
        public virtual void SupportsNanosecondOfDay()
        {
            SupportsPropertyOrMethod(x => x.NanosecondOfDay);
        }

        [SkippableFact]
        public virtual void SupportsNanosecondOfSecond()
        {
            SupportsPropertyOrMethod(x => x.NanosecondOfSecond);
        }

        [SkippableFact]
        public virtual void SupportsSecond()
        {
            SupportsPropertyOrMethod(x => x.Second);
        }

        [SkippableFact]
        public virtual void SupportsTickOfDay()
        {
            SupportsPropertyOrMethod(x => x.TickOfDay);
        }

        [SkippableFact]
        public virtual void SupportsTickOfSecond()
        {
            SupportsPropertyOrMethod(x => x.TickOfSecond);
        }

        [SkippableFact]
        public virtual void SupportsTimeOfDay()
        {
            SupportsPropertyOrMethod(x => x.TimeOfDay);
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

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsCompareTo(LocalDateTime localDateTime)
        {
            SupportsPropertyOrMethod(x => x.CompareTo(localDateTime));
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsEquals(LocalDateTime localDateTime)
        {
            SupportsPropertyOrMethod(x => x.Equals(localDateTime));
        }

        //[SkippableFact]
        //[NodaTimeAutoData]
        //public virtual void SupportsFromDateTime(DateTime dateTime)
        //{
        //    SupportsPropertyOrMethod(x => x.Equals(localDateTime));
        //}

        [SkippableFact]
        public virtual void SupportsInUtc()
        {
            SupportsPropertyOrMethod(x => x.InUtc());
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsInZoneLeniently(DateTimeZone dateTimeZone)
        {
            SupportsPropertyOrMethod(x => x.InZoneLeniently(dateTimeZone));
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsInZoneStrictly(DateTimeZone dateTimeZone)
        {
            SupportsPropertyOrMethod(x => x.InZoneStrictly(dateTimeZone));
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsMax(LocalDateTime localDateTime)
        {
            SupportsPropertyOrMethod(x => LocalDateTime.Max(x, localDateTime));
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsMin(LocalDateTime localDateTime)
        {
            SupportsPropertyOrMethod(x => LocalDateTime.Min(x, localDateTime));
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsMinusLocalDateTime(LocalDateTime localDateTime)
        {
            SupportsPropertyOrMethod(x => x.Minus(localDateTime));
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsMinusLocalDateTimeOperator(LocalDateTime localDateTime)
        {
            SupportsPropertyOrMethod(x => x - localDateTime);
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
        [NodaTimeAutoData]
        public virtual void SupportsNext(IsoDayOfWeek isoDayOfWeek)
        {
            SupportsPropertyOrMethod(x => x.Next(isoDayOfWeek));
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
        public virtual void SupportsPlusDays(int days)
        {
            SupportsPropertyOrMethod(x => x.PlusDays(days));
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsPlusHours(long hours)
        {
            SupportsPropertyOrMethod(x => x.PlusHours(hours));
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsPlusMilliseconds(long milliseconds)
        {
            SupportsPropertyOrMethod(x => x.PlusMilliseconds(milliseconds));
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsPlusMinutes(long minutes)
        {
            SupportsPropertyOrMethod(x => x.PlusMinutes(minutes));
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsPlusMonths(int months)
        {
            SupportsPropertyOrMethod(x => x.PlusMonths(months));
        }
    }
}
