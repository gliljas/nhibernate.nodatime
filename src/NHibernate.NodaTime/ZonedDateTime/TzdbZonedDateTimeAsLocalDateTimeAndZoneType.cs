using NodaTime;

namespace NHibernate.NodaTime
{
    public class TzdbZonedDateTimeAsLocalDateTimeAndZoneType : AbstractTwoPropertyStructType<ZonedDateTime, LocalDateTime, DateTimeZone, CustomType<LocalDateTimeAsDateTimeType>, CustomType<TzdbDateTimeZoneType>>
    {
        protected override string Property1Name => nameof(ZonedDateTime.LocalDateTime);
        protected override string Property2Name => nameof(ZonedDateTime.Zone);
        protected override int Property1ColumnSpan => 1;
        protected override int Property2ColumnSpan => 1;
        protected override ZonedDateTime Unwrap(LocalDateTime property1Value, DateTimeZone property2Value) => property1Value.InZoneLeniently(property2Value);
        protected override LocalDateTime GetProperty1Value(ZonedDateTime value) => value.LocalDateTime;
        protected override DateTimeZone GetProperty2Value(ZonedDateTime value) => value.Zone;

    }

}
