using NHibernate.NodaTime.Linq;
using NHibernate.Type;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.NodaTime
{
    public class TzdbZonedDateTimeAsDateTimeOffsetType : AbstractTwoPropertyStructType<ZonedDateTime, DateTimeOffset, DateTimeZone>
    {
        public TzdbZonedDateTimeAsDateTimeOffsetType() : base(new DateTimeOffsetType(), new CustomType(typeof(TzdbDateTimeZoneType), null))
        {

        }
        protected override string Property1Name => "DateTimeOffset";
        protected override string Property2Name => "Zone";
        protected override int Property1ColumnSpan => 1;
        protected override int Property2ColumnSpan => 1;
        protected override ZonedDateTime Unwrap(DateTimeOffset property1Value, DateTimeZone property2Value) => new ZonedDateTime(Instant.FromDateTimeOffset(property1Value), property2Value);
        protected override DateTimeOffset GetProperty1Value(ZonedDateTime value) => value.ToDateTimeOffset();
        protected override DateTimeZone GetProperty2Value(ZonedDateTime value) => value.Zone;

        public override IEnumerable<SupportedQueryMethod<ZonedDateTime>> SupportedQueryMethods => new[] { 
            new SupportedQueryMethod<ZonedDateTime>(x=>x.ToDateTimeOffset(),new PropertyResolver(Property1Name))
        };
    }

}
