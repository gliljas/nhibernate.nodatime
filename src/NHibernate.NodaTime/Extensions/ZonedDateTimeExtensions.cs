using NodaTime;

namespace NHibernate.NodaTime.Extensions
{
    internal static class ZonedDateTimeExtensions
    {
        internal static LocalDate DateFromDateTime(this ZonedDateTime instance) => instance.Date;
        internal static int DayFromDateTime(this ZonedDateTime instance) => instance.Day;
        internal static int HourFromDateTime(this ZonedDateTime instance) => instance.Hour;
        internal static int MinuteFromDateTime(this ZonedDateTime instance) => instance.Minute;
        internal static int SecondFromDateTime(this ZonedDateTime instance) => instance.Second;
        internal static int MillisecondFromDateTime(this ZonedDateTime instance) => instance.Millisecond;
        internal static int NanosecondOfSecondFromDateTime(this ZonedDateTime instance) => instance.NanosecondOfSecond;
        internal static long NanosecondOfDayFromDateTime(this ZonedDateTime instance) => instance.NanosecondOfDay;

        internal static IsoDayOfWeek DayOfWeekFromDateTime(this ZonedDateTime instance) => instance.DayOfWeek;
        internal static int DayOfYearFromDateTime(this ZonedDateTime instance) => instance.DayOfYear;
        internal static ZonedDateTime PlusFromDateTime(this ZonedDateTime instance, Duration duration) => instance.Plus(duration);
        internal static ZonedDateTime MinusFromDateTime(this ZonedDateTime instance, Duration duration) => instance.Minus(duration);
   
    }


}
