using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    public class TzdbZonedDateTimeAsUtcDbTimestampType : AbstractDateTimeBackedZonedDateTimeType<UtcDbTimestampType, TzdbDateTimeZoneType>
    {
    }
}
