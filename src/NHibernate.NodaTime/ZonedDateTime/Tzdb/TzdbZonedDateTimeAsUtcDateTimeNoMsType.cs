using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    public class TzdbZonedDateTimeAsUtcDateTimeNoMsType : AbstractDateTimeBackedZonedDateTimeType<UtcDateTimeNoMsType, TzdbDateTimeZoneType>
    {
    }
}
