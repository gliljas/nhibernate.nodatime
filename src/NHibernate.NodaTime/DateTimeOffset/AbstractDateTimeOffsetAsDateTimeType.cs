using NHibernate.Type;
using System;

namespace NHibernate.NodaTime
{
    public abstract class AbstractDateTimeOffsetAsDateTimeType<TDateTimeType> : AbstractDateTimeOffsetType<DateTime, TDateTimeType>
        where TDateTimeType : AbstractDateTimeType, IVersionType, new()
    {
        protected override DateTimeOffset Unwrap(DateTime value) => DateTime.SpecifyKind(value, DateTimeKind.Utc);
        protected override DateTime Wrap(DateTimeOffset value) => value.UtcDateTime;
    }
}
