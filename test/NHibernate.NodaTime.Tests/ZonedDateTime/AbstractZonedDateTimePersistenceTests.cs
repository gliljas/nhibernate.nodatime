using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public abstract class AbstractZonedDateTimePersistenceTests<TUserType> : AbstractPersistenceTests<ZonedDateTime, TUserType>
    where TUserType : new()
    {
        protected AbstractZonedDateTimePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {
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

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsEquals(OffsetDateTime offsetDateTime)
        {
            SupportsPropertyOrMethod(x => x.Equals(offsetDateTime));
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
        public virtual void SupportsIsDaylightSavingTime()
        {
            SupportsPropertyOrMethod(x => x.IsDaylightSavingTime());
        }

        [SkippableFact]
        public virtual void SupportsLocalDateTime()
        {
            SupportsPropertyOrMethod(x => x.LocalDateTime);
        }

        [SkippableFact]
        public virtual void SupportsMillisecond()
        {
            SupportsPropertyOrMethod(x => x.Millisecond);
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsMinusDuration(Duration duration)
        {
            SupportsPropertyOrMethod(x => x.Minus(duration));
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsMinusDurationOperator(Duration duration)
        {
            SupportsPropertyOrMethod(x => x - duration);
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsMinusZonedDateTime(ZonedDateTime zonedDateTime)
        {
            SupportsPropertyOrMethod(x => x.Minus(zonedDateTime));
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsMinusZonedDateTimeOperator(ZonedDateTime zonedDateTime)
        {
            SupportsPropertyOrMethod(x => x - zonedDateTime);
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

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsPlusDuration(Duration duration)
        {
            SupportsPropertyOrMethod(x => x.Plus(duration));
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsPlusDurationOperator(Duration duration)
        {
            SupportsPropertyOrMethod(x => x + duration);
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsPlusHours(int hours)
        {
            SupportsPropertyOrMethod(x => x.PlusHours(hours));
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsPlusMilliseconds(long milliseconds)
        {
            SupportsPropertyOrMethod(x => x.PlusMilliseconds(milliseconds));
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsPlusMinutes(int minutes)
        {
            SupportsPropertyOrMethod(x => x.PlusMinutes(minutes));
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsPlusTicks(long ticks)
        {
            SupportsPropertyOrMethod(x => x.PlusTicks(ticks));
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
        public virtual void SupportsToDateTimeOffset()
        {
            SupportsPropertyOrMethod(x => x.ToDateTimeOffset());
        }
        [SkippableFact]
        public virtual void SupportsToDateTimeUnspecified()
        {
            SupportsPropertyOrMethod(x => x.ToDateTimeUnspecified());
        }

        [SkippableFact]
        public virtual void SupportsToDateTimeUtc()
        {
            SupportsPropertyOrMethod(x => x.ToDateTimeUtc());
        }

        [SkippableFact]
        public virtual void SupportsToInstant()
        {
            SupportsPropertyOrMethod(x => x.ToInstant());
        }

        //[SkippableFact]
        //[NodaTimeAutoData]
        //public virtual void SupportsFromDateTime(DateTime dateTime)
        //{
        //    SupportsPropertyOrMethod(x => x.Equals(offsetDateTime));
        //}
        [SkippableFact]
        public virtual void SupportsToOffsetDateTime()
        {
            SupportsPropertyOrMethod(x => x.ToOffsetDateTime());
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsWithZone(DateTimeZone zone)
        {
            SupportsPropertyOrMethod(x => x.WithZone(zone));
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
        public virtual void SupportsZone()
        {
            SupportsPropertyOrMethod(x => x.Zone);
        }
    }
}