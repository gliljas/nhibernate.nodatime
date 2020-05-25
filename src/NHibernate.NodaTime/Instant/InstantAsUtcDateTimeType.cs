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
    /// Persists an <see cref="Instant"/> as a <see cref="DateTime"/>, using <see cref="UtcDateTimeType"/>
    /// </summary>
    public class InstantAsUtcDateTimeType : AbstractInstantType<DateTime, UtcDateTimeType>
    {
        protected override Instant Unwrap(DateTime value) => Instant.FromDateTimeUtc(DateTime.SpecifyKind(value, DateTimeKind.Utc));

        protected override DateTime Wrap(Instant value) => value.ToDateTimeUtc();

        protected override Instant Cast(object value)
        {
            if (value is DateTimeOffset dateTimeOffset)
            {
                return Instant.FromDateTimeOffset(dateTimeOffset);
            }
            if (value is DateTime dateTime)
            {
                return Instant.FromDateTimeUtc(dateTime);
            }
            return base.Cast(value);
        }
    }
}
