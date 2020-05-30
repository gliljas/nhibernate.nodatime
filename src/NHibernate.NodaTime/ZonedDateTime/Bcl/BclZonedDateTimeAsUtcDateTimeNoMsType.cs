#if NETFRAMEWORK

using NHibernate.Type;

namespace NHibernate.NodaTime
{
    public class BclZonedDateTimeAsUtcDateTimeNoMsType : AbstractDateTimeBackedZonedDateTimeType<UtcDateTimeNoMsType, BclDateTimeZoneType>
    {
    }
}

#endif