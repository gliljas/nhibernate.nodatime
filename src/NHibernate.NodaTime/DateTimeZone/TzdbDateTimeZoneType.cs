using NodaTime;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persists a <see cref="DateTimeZone"/> as a string 
    /// </summary>
    public class TzdbDateTimeZoneType : AbstractDateTimeZoneType
    {
        protected override IDateTimeZoneProvider DateTimeZoneProvider => DateTimeZoneProviders.Tzdb;
    }
}
