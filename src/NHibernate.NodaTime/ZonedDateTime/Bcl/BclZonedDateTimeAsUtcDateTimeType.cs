#if NETFRAMEWORK

using NHibernate.Type;

namespace NHibernate.NodaTime
{
    public class BclZonedDateTimeAsUtcDateTimeType : AbstractDateTimeBackedZonedDateTimeType<UtcDateTimeType, BclDateTimeZoneType>
    {
    }
}

#endif