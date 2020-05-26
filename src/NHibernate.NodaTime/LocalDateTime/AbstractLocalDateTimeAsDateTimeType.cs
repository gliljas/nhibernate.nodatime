using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    public abstract class AbstractLocalDateTimeAsDateTimeType<TDateTimeType> : AbstractStructType<LocalDateTime, DateTime, TDateTimeType>
        where TDateTimeType : NullableType, new()
    {
        protected override LocalDateTime Unwrap(DateTime value) => LocalDateTime.FromDateTime(value);

        protected override DateTime Wrap(LocalDateTime value) => value.ToDateTimeUnspecified();

    }
}
