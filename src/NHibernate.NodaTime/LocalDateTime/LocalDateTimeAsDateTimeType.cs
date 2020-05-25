using NHibernate.SqlTypes;
using NHibernate.Type;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persists a <see cref="LocalDateTime"/> as a <see cref="DateTime"/>, using <see cref="DateTimeType"/>
    /// </summary>
    public class LocalDateTimeAsDateTimeType : AbstractStructType<LocalDateTime, DateTime, DateTimeType>
    {
        protected override LocalDateTime Unwrap(DateTime value) => LocalDateTime.FromDateTime(value);

        protected override DateTime Wrap(LocalDateTime value) => value.ToDateTimeUnspecified();

    }
}
