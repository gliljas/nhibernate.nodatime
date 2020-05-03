using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    public class TzdbZonedDateTimeAsDateTimeUtcType : AbstractTwoPropertyStructType<ZonedDateTime, DateTime, DateTimeZone>
    {
        protected override string Property1Name => "DateTime";
        protected override string Property2Name => "Zone";
        protected override IType Property1Type => NHibernateUtil.DateTime;
        protected override IType Property2Type => new CustomType(typeof(TzdbDateTimeZoneType), null);
        protected override int Property1ColumnSpan => 1;
        protected override int Property2ColumnSpan => 1;
        protected override ZonedDateTime Unwrap(DateTime property1Value, DateTimeZone property2Value) => Instant.FromDateTimeUtc(property1Value).InZone(property2Value);
        protected override DateTime GetProperty1Value(ZonedDateTime value) => value.ToDateTimeUtc();
        protected override DateTimeZone GetProperty2Value(ZonedDateTime value) => value.Zone;

    }

}
