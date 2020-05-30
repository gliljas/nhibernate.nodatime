using NodaTime;

namespace NHibernate.NodaTime.Extensions
{
    internal static class LocalTimeExtensions
    {
        internal static LocalTime PlusFromTimeSpan(this LocalTime instance, Period period) => instance.Plus(period);

        internal static LocalTime PlusHoursFromTimeSpan(this LocalTime instance, int hours) => instance.PlusHours(hours);

        internal static LocalTime PlusMinutesFromTimeSpan(this LocalTime instance, int minutes) => instance.PlusMinutes(minutes);

        internal static LocalTime MinusFromTimeSpan(this LocalTime instance, Period period) => instance.Minus(period);

        internal static int HourFromTimeSpan(this LocalTime instance, Period period) => instance.Hour;

        internal static int MinuteFromTimeSpan(this LocalTime instance, Period period) => instance.Minute;

        internal static int SecondFromTimeSpan(this LocalTime instance, Period period) => instance.Second;

        internal static int MillisecondFromTimeSpan(this LocalTime instance, Period period) => instance.Millisecond;

        internal static int NanosecondOfSecondFromTimeSpan(this LocalTime instance, Period period) => instance.NanosecondOfSecond;
    }
}