using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persists a <see cref="LocalDateTime"/> as a <see cref="DateTime"/>, using <see cref="DateTimeNoMsType"/>
    /// </summary>
    public class LocalDateTimeAsDateTimeNoMsType : AbstractStructType<LocalDateTime, DateTime, DateTimeNoMsType>
    {
        protected override LocalDateTime Unwrap(DateTime value) => LocalDateTime.FromDateTime(value);

        protected override DateTime Wrap(LocalDateTime value) => value.ToDateTimeUnspecified();

    }
}
