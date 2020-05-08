using NHibernate.Type;
using NHibernate.UserTypes;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.NodaTime
{
    public abstract class AbstractDateIntervalAsLocalDatesType<TLocalDateType> : AbstractTwoPropertyStructType<DateInterval, LocalDate, LocalDate, CustomType<TLocalDateType>, CustomType<TLocalDateType>>
        where TLocalDateType : IUserType
    {
        protected override string Property1Name => "Start";
        protected override string Property2Name => "End";

        protected override int Property1ColumnSpan => 1;
        protected override int Property2ColumnSpan => 1;

        protected override DateInterval Unwrap(LocalDate property1Value, LocalDate property2Value) => new DateInterval(property1Value, property2Value);

        protected override LocalDate GetProperty1Value(DateInterval value) => value.Start;

        protected override LocalDate GetProperty2Value(DateInterval value) => value.End;

        protected override DateInterval Cast(object value)
        {
            if (value is DateIntervalWrapper wrapper)
            {
                return (DateInterval)wrapper;
            }
            return base.Cast(value);
        }
    }

    public class DateIntervalWrapper
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
            return d1.Equals(d2);
        }

        public static bool operator ==(DateInterval d1, DateIntervalWrapper d2)
        {
            return d1.Equals(d2);
        }

        public static bool operator !=(DateIntervalWrapper d1, DateInterval d2)
        {
            return !d1.Equals(d2);
        }

        public static bool operator !=(DateInterval d1, DateIntervalWrapper d2)
        {
            return !d1.Equals(d2);
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
