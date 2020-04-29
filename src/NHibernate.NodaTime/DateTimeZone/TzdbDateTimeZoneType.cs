using NodaTime;

namespace NHibernate.NodaTime
{
    public class TzdbDateTimeZoneType : AbstractDateTimeZoneType
    {
        protected override IDateTimeZoneProvider DateTimeZoneProvider => DateTimeZoneProviders.Tzdb;
    }
}
