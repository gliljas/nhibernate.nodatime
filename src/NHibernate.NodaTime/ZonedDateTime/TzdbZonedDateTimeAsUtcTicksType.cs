using NHibernate.Type;
using NHibernate.UserTypes;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    public class TzdbZonedDateTimeAsUtcTicksType : AbstractDateTimeBackedZonedDateTimeType<UtcTicksType, TzdbDateTimeZoneType>
    {
    }
}
