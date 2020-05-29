using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public abstract class AbstractLocalTimePersistenceTests<TUserType> : AbstractPersistenceTests<LocalTime, TUserType>
    where TUserType : new()
    {
        protected AbstractLocalTimePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }

        [SkippableFact]
        public virtual void SupportsClockHourOfHalfDay()
        {
            SupportsPropertyOrMethod(x => x.ClockHourOfHalfDay);
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
        [NodaTimeAutoData]
        public virtual void SupportsOn(LocalDate localDate)
        {
            SupportsPropertyOrMethod(x => x.On(localDate));
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
        [NodaTimeAutoData]
        public virtual void SupportsCompareTo(LocalTime localTime)
        {
            SupportsPropertyOrMethod(x => x.CompareTo(localTime));
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsEquals(LocalTime localTime)
        {
            SupportsPropertyOrMethod(x => x.Equals(localTime));
        }

        //[SkippableFact]
        //[NodaTimeAutoData]
        //public virtual void SupportsFromDateTime(DateTime dateTime)
        //{
        //    SupportsPropertyOrMethod(x => x.Equals(localTime));
        //}

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsMax(LocalTime localTime)
        {
            SupportsPropertyOrMethod(x => LocalTime.Max(x, localTime));
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsMin(LocalTime localTime)
        {
            SupportsPropertyOrMethod(x => LocalTime.Min(x, localTime));
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsMinusLocalTime(LocalTime localTime)
        {
            SupportsPropertyOrMethod(x => x.Minus(localTime));
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsMinusLocalTimeOperator(LocalTime localTime)
        {
            SupportsPropertyOrMethod(x => x - localTime);
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

    }
}
