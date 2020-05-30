using NHibernate.Type;
using System;

namespace NHibernate.NodaTime
{
    public abstract class AbstractDateTimeOffsetAsDateTimeAndOffsetType<TDateTimeType> : AbstractTwoPropertyStructType<DateTimeOffset, DateTime, TimeSpan, TDateTimeType, TimeSpanType>
        where TDateTimeType : AbstractDateTimeType, IVersionType, new()
    {
        protected override string Property1Name => nameof(DateTimeOffset.UtcDateTime);
        protected override string Property2Name => nameof(DateTimeOffset.Offset);

        protected override DateTime GetProperty1Value(DateTimeOffset value) => value.UtcDateTime;

        protected override TimeSpan GetProperty2Value(DateTimeOffset value) => value.Offset;

        protected override DateTimeOffset Unwrap(DateTime property1Value, TimeSpan property2Value) => new DateTimeOffset(DateTime.SpecifyKind(property1Value, DateTimeKind.Utc), property2Value);
    }
}