using NodaTime;

namespace NHibernate.NodaTime.Extensions
{
    internal static class IntervalExtensions
    {
        internal static Duration DurationFromDateTimeOffset(this Interval instance, Period period) => instance.Duration;

        internal static Duration DurationFromDateTime(this Interval instance, Period period) => instance.Duration;
    }
}