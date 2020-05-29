using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public abstract class AbstractOffsetDateTimePersistenceTests<TUserType> : AbstractPersistenceTests<OffsetDateTime, TUserType>
    where TUserType : new()
    {
        protected AbstractOffsetDateTimePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }

        [SkippableFact]
        public virtual void SupportsToDateTimeOffset()
        {
            SupportsPropertyOrMethod(x => x.ToDateTimeOffset());
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

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsEquals(OffsetDateTime offsetDateTime)
        {
            SupportsPropertyOrMethod(x => x.Equals(offsetDateTime));
        }

        //[SkippableFact]
        //[NodaTimeAutoData]
        //public virtual void SupportsFromDateTime(DateTime dateTime)
        //{
        //    SupportsPropertyOrMethod(x => x.Equals(offsetDateTime));
        //}

        [SkippableFact]
        public virtual void SupportsToInstant()
        {
            SupportsPropertyOrMethod(x => x.ToInstant());
        }

        [SkippableFact]
        public virtual void SupportsToOffsetDate()
        {
            SupportsPropertyOrMethod(x => x.ToOffsetDate());
        }

        [SkippableFact]
        public virtual void SupportsToOffsetTime()
        {
            SupportsPropertyOrMethod(x => x.ToOffsetTime());
        }


        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsWithOffset(Offset offset)
        {
            SupportsPropertyOrMethod(x => x.WithOffset(offset));
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsMinusOffsetDateTime(OffsetDateTime offsetDateTime)
        {
            SupportsPropertyOrMethod(x => x.Minus(offsetDateTime));
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsMinusOffsetDateTimeOperator(OffsetDateTime offsetDateTime)
        {
            SupportsPropertyOrMethod(x => x - offsetDateTime);
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsMinusDuration(Duration duration)
        {
            SupportsPropertyOrMethod(x => x.Minus(duration));
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsMinusDurationOperator(Duration duration)
        {
            SupportsPropertyOrMethod(x => x - duration);
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsPlusDuration(Duration duration)
        {
            SupportsPropertyOrMethod(x => x.Plus(duration));
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsPlusDurationOperator(Duration duration)
        {
            SupportsPropertyOrMethod(x => x + duration);
        }

       
        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsPlusHours(int hours)
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
        public virtual void SupportsPlusMinutes(int minutes)
        {
            SupportsPropertyOrMethod(x => x.PlusMinutes(minutes));
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsPlusTicks(long ticks)
        {
            SupportsPropertyOrMethod(x => x.PlusTicks(ticks));
        }

    }
}
