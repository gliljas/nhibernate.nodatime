#if NETFRAMEWORK
using NHibernate.NodaTime.Linq;
using NHibernate.Type;
using NodaTime;
using System;
using System.Collections.Generic;

namespace NHibernate.NodaTime
{
    public class BclZonedDateTimeAsDateTimeOffsetType : AbstractZonedDateTimeType<DateTimeOffset, DateTimeOffsetType, BclDateTimeZoneType>
    {
        protected override string Property1Name => "DateTimeOffset";
        protected override int Property1ColumnSpan => 1;
        protected override ZonedDateTime Unwrap(DateTimeOffset property1Value, DateTimeZone property2Value) => new ZonedDateTime(Instant.FromDateTimeOffset(property1Value), property2Value);
        protected override DateTimeOffset GetProperty1Value(ZonedDateTime value) => value.ToDateTimeOffset();

        public override IEnumerable<SupportedQueryMethod<ZonedDateTime>> SupportedQueryMethods => new[] {
            new SupportedQueryMethod<ZonedDateTime>(x=>x.ToDateTimeOffset(),new PropertyResolver(Property1Name))
        };
    }
}
#endif