using FluentAssertions;
using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime.Extensions;
using System;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public abstract class AbstractDateTimeOffsetPersistenceTests<TUserType> : AbstractPersistenceTests<DateTimeOffset, TUserType>
    where TUserType : new()
    {
        protected AbstractDateTimeOffsetPersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

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
        public virtual void SupportsDateTime()
        {
            SupportsPropertyOrMethod(x => x.DateTime);
        }

        [SkippableFact]
        public virtual void SupportsUtcDateTime()
        {
            SupportsPropertyOrMethod(x => x.UtcDateTime, x => x.Kind.Should().Be(DateTimeKind.Utc));
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsAddDays(double days)
        {
            SupportsPropertyOrMethod(x => x.AddDays(days));
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsAddMinutes(double minutes)
        {
            SupportsPropertyOrMethod(x => x.AddMinutes(minutes));
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsAddSeconds(double seconds)
        {
            SupportsPropertyOrMethod(x => x.AddSeconds(seconds));
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsAddMilliseconds(double milliseconds)
        {
            SupportsPropertyOrMethod(x => x.AddMilliseconds(milliseconds));
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsAddTicks(long ticks)
        {
            SupportsPropertyOrMethod(x => x.AddTicks(ticks));
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsAddYears(int years)
        {
            SupportsPropertyOrMethod(x => x.AddYears(years));
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsAdd(TimeSpan timeSpan)
        {
            SupportsPropertyOrMethod(x => x.Add(timeSpan));
        }

        [SkippableFact]
        public virtual void SupportsLocalDateTime()
        {
            SupportsPropertyOrMethod(x => x.LocalDateTime);
        }

        [SkippableFact]
        public virtual void SupportsOffset()
        {
            SupportsPropertyOrMethod(x => x.Offset);
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsSubtractDateTimeOffset(DateTimeOffset dateTimeOffset)
        {
            SupportsPropertyOrMethod(x => x.Subtract(dateTimeOffset));
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsSubtractDateTimeOffsetWithOperator(DateTimeOffset dateTimeOffset)
        {
            SupportsPropertyOrMethod(x => x - dateTimeOffset);
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsSubtractTimeSpan(TimeSpan timeSpan)
        {
            SupportsPropertyOrMethod(x => x.Subtract(timeSpan));
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsSubtractTimeSpanWithOperator(TimeSpan timeSpan)
        {
            SupportsPropertyOrMethod(x => x - timeSpan);
        }

        [SkippableFact]
        public virtual void SupportsToUnixTimeSeconds()
        {
            SupportsPropertyOrMethod(x => x.ToUnixTimeSeconds());
        }

        [SkippableFact]
        public virtual void SupportsToUnixTimeMilliseconds()
        {
            SupportsPropertyOrMethod(x => x.ToUnixTimeMilliseconds());
        }

        [SkippableFact]
        public virtual void SupportsTicks()
        {
            SupportsPropertyOrMethod(x => x.Ticks);
        }

        [SkippableFact]
        public virtual void SupportsTimeOfDay()
        {
            SupportsPropertyOrMethod(x => x.TimeOfDay);
        }

        [SkippableFact]
        public virtual void SupportsToFileTime()
        {
            SupportsPropertyOrMethod(x => x.ToFileTime());
        }

        [SkippableFact]
        public virtual void SupportsToUniversalTime()
        {
            SupportsPropertyOrMethod(x => x.ToUniversalTime());
        }

        [SkippableFact]
        public virtual void SupportsToInstant()
        {
            SupportsPropertyOrMethod(x => x.ToInstant());
        }

        [SkippableFact]
        public virtual void SupportsToLocalTime()
        {
            SupportsPropertyOrMethod(x => x.ToLocalTime());
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsToOffset(TimeSpan offset)
        {
            SupportsPropertyOrMethod(x => x.ToOffset(offset));
        }

        [SkippableFact]
        public virtual void SupportsToOffsetDateTime()
        {
            SupportsPropertyOrMethod(x => x.ToOffsetDateTime());
        }

        [SkippableFact]
        public virtual void SupportsToZonedDateTime()
        {
            SupportsPropertyOrMethod(x => x.ToZonedDateTime());
        }

        [SkippableFact]
        public virtual void SupportsMonth()
        {
            SupportsPropertyOrMethod(x => x.Month);
        }

        [SkippableFact]
        public virtual void SupportsYear()
        {
            SupportsPropertyOrMethod(x => x.Year);
        }
    }
}
