using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persists a <see cref="ZonedDateTime"/> as a <see cref="DateTimeOffset"/> and a <see cref="Offset"/>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This type preserves the offset from the <see cref="ZonedDateTime"/>
    /// </para>
    /// </remarks>
    public class TzdbZonedDateTimeAsDateTimeOffsetType : AbstractZonedDateTimeType<DateTimeOffset,DateTimeOffsetType, TzdbDateTimeZoneType>
    {
        protected override string Property1Name => "DateTimeOffset";
        protected override int Property1ColumnSpan => 1;
        protected override ZonedDateTime Unwrap(DateTimeOffset property1Value, DateTimeZone property2Value) => new ZonedDateTime(Instant.FromDateTimeOffset(property1Value), property2Value);
        protected override DateTimeOffset GetProperty1Value(ZonedDateTime value) => value.ToDateTimeOffset();
    }
}
