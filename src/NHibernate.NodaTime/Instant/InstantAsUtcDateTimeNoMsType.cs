using NHibernate.SqlTypes;
using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persists an <see cref="Instant"/> as a <see cref="DateTime"/>, using <see cref="UtcDateTimeNoMsType"/>
    /// </summary>
    public class InstantAsUtcDateTimeNoMsType : AbstractInstantType<DateTime, UtcDateTimeNoMsType>
    {
        protected override Instant Unwrap(DateTime value) => Instant.FromDateTimeUtc(DateTime.SpecifyKind(value, DateTimeKind.Utc));

        protected override DateTime Wrap(Instant value) => value.ToDateTimeUtc();
    }
}
