using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    public class InstantAsUtcDbTimestampType : AbstractInstantType<DateTime, UtcDbTimestampType>
    {
        protected override Instant Unwrap(DateTime value) => Instant.FromDateTimeUtc(DateTime.SpecifyKind(value, DateTimeKind.Utc));

        protected override DateTime Wrap(Instant value) => value.ToDateTimeUtc();
    }
}
