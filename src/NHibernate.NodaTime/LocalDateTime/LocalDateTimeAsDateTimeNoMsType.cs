using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    public class LocalDateTimeAsDateTimeNoMsType : AbstractStructType<LocalDateTime, DateTime, DateTimeNoMsType>
    {
        protected override LocalDateTime Unwrap(DateTime value) => LocalDateTime.FromDateTime(value);

        protected override DateTime Wrap(LocalDateTime value) => value.ToDateTimeUnspecified();

    }
}
