#if NETFRAMEWORK
using NHibernate.Type;

namespace NHibernate.NodaTime
{
    public class BclZonedDateTimeAsUtcDbTimestampType : AbstractDateTimeBackedZonedDateTimeType<UtcDbTimestampType, BclDateTimeZoneType>
    {
    }
}
#endif
