using NHibernate.SqlTypes;
using NHibernate.Type;
using System;

namespace NHibernate.NodaTime
{
    public class DateTimeOffsetAsUtcTicksType : VersionedAbstractStructType<DateTimeOffset, DateTime, UtcTicksType>
    {
        protected override DateTimeOffset Unwrap(DateTime value) => DateTime.SpecifyKind(value, DateTimeKind.Utc);
        protected override DateTime Wrap(DateTimeOffset value) => value.UtcDateTime;
    }
}
