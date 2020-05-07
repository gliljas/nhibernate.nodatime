using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    public class LocalDateAsDateType : AbstractStructType<LocalDate, DateTime, DateType>
    {
        protected override LocalDate Unwrap(DateTime value) => LocalDate.FromDateTime(value);

        protected override DateTime Wrap(LocalDate value) => value.ToDateTimeUnspecified();

    }
}
