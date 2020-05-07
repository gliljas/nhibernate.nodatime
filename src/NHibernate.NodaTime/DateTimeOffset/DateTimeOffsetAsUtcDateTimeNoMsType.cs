using NHibernate.Engine;
using NHibernate.SqlTypes;
using NHibernate.Type;
using NHibernate.UserTypes;
using System;

namespace NHibernate.NodaTime
{
    public class DateTimeOffsetAsUtcDateTimeNoMsType : VersionedAbstractStructType<DateTimeOffset, DateTime, UtcDateTimeNoMsType>
    {
        protected override DateTimeOffset Unwrap(DateTime value) => DateTime.SpecifyKind(value, DateTimeKind.Utc);
        protected override DateTime Wrap(DateTimeOffset value) => value.UtcDateTime;
    }
}
