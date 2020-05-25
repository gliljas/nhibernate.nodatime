#if NETFRAMEWORK
using NodaTime;

namespace NHibernate.NodaTime
{
    public class BclZonedDateTimeAsLocalDateTimeAndZoneType : AbstractZonedDateTimeType<LocalDateTime, CustomType<LocalDateTimeAsDateTimeType>, BclDateTimeZoneType>
    {
        protected override string Property1Name => nameof(ZonedDateTime.LocalDateTime);
        protected override int Property1ColumnSpan => 1;
        protected override ZonedDateTime Unwrap(LocalDateTime property1Value, DateTimeZone property2Value) => property1Value.InZoneLeniently(property2Value);
        protected override LocalDateTime GetProperty1Value(ZonedDateTime value) => value.LocalDateTime;
    }
}
#endif
