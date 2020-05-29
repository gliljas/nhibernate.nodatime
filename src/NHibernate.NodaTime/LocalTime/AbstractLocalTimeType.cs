using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    public abstract class AbstractLocalTimeType<TPersisted, TNullableType> : AbstractStructType<LocalTime, TPersisted, TNullableType>
        where TNullableType : NullableType, new()
    {
        protected override LocalTime Cast(object value)
        {
            if (value is DateTimeOffset dateTimeOffset)
            {
                return LocalDateTime.FromDateTime(dateTimeOffset.UtcDateTime).TimeOfDay;
            }
            if (value is DateTime dateTime)
            {
                return LocalDateTime.FromDateTime(dateTime).TimeOfDay;
            }
            if (value is TimeSpan timeSpan)
            {
                return LocalTime.FromTicksSinceMidnight(timeSpan.Ticks);
            }
            return base.Cast(value);
        }
    }
}
