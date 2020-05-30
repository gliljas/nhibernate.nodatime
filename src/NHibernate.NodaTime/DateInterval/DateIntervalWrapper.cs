using NodaTime;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// This class is used to mascerade DateInterval as a non IEnumerable class,
    /// since otherwise DateInterval parameters would be treated as parameter lists
    /// </summary>
    internal class DateIntervalWrapper
    {
        public DateIntervalWrapper(DateInterval dateInterval)
        {
            Start = dateInterval.Start;
            End = dateInterval.End;
        }

        public LocalDate Start { get; }
        public LocalDate End { get; }

        public override bool Equals(object obj)
        {
            return obj is DateIntervalWrapper wrapper &&
                   Start.Equals(wrapper.Start) &&
                   End.Equals(wrapper.End);
        }

        public override int GetHashCode()
        {
            int hashCode = -1676728671;
            hashCode = hashCode * -1521134295 + Start.GetHashCode();
            hashCode = hashCode * -1521134295 + End.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(DateIntervalWrapper d1, DateInterval d2)
        {
            return d1.Start == d2.Start && d1.End == d2.End;
        }

        public static bool operator ==(DateInterval d1, DateIntervalWrapper d2)
        {
            return d1.Start == d2.Start && d1.End == d2.End;
        }

        public static bool operator !=(DateIntervalWrapper d1, DateInterval d2)
        {
            return d1.Start != d2.Start || d1.End != d2.End;
        }

        public static bool operator !=(DateInterval d1, DateIntervalWrapper d2)
        {
            return d1.Start != d2.Start || d1.End != d2.End;
        }

        public static explicit operator DateIntervalWrapper(DateInterval v)
        {
            return new DateIntervalWrapper(v);
        }

        public static explicit operator DateInterval(DateIntervalWrapper v)
        {
            return new DateInterval(v.Start, v.End);
        }
    }
}