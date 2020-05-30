#if NETFRAMEWORK

using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    public class BclZonedDateTimeAsUtcTicksType : AbstractZonedDateTimeType<DateTime, UtcTicksType, BclDateTimeZoneType>
    {
        protected override string Property1Name => "DateTime";
        protected override int Property1ColumnSpan => 1;

        protected override ZonedDateTime Unwrap(DateTime property1Value, DateTimeZone property2Value) => Instant.FromDateTimeUtc(property1Value).InZone(property2Value);

        protected override DateTime GetProperty1Value(ZonedDateTime value) => value.ToDateTimeUtc();
    }
}

#endif