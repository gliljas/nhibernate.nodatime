using NHibernate.UserTypes;
using NodaTime;

namespace NHibernate.NodaTime
{

    public class TzdbZonedDateTimeAsLocalDateTimeAndZoneType : AbstractZonedDateTimeAsLocalDateTimeAndZoneType<LocalDateTimeAsDateTimeType, TzdbDateTimeZoneType>
    { 
    }
}
