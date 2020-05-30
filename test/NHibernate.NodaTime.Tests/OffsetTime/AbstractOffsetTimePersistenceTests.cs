using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public abstract class AbstractOffsetTimePersistenceTests<TUserType> : AbstractPersistenceTests<OffsetTime, TUserType>
    where TUserType : new()
    {
        protected AbstractOffsetTimePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsOn(LocalDate localDate)
        {
            SupportsPropertyOrMethod(x => x.On(localDate));
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

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsEquals(OffsetTime offsetTime)
        {
            SupportsPropertyOrMethod(x => x.Equals(offsetTime));
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsWithOffset(Offset offset)
        {
            SupportsPropertyOrMethod(x => x.WithOffset(offset));
        }
    }
}