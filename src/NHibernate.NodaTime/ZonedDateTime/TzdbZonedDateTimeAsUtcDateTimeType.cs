using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    public class TzdbZonedDateTimeAsUtcDateTimeType : AbstractDateTimeBackedZonedDateTimeType<UtcDateTimeType, TzdbDateTimeZoneType>
    {
       
    }
}
