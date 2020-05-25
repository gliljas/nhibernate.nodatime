#if NETFRAMEWORK
using NodaTime;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persists a <see cref="DateTimeZone"/> as a string 
    /// </summary>
    public class BclDateTimeZoneType : AbstractDateTimeZoneType
    {
        protected override IDateTimeZoneProvider DateTimeZoneProvider => DateTimeZoneProviders.Bcl;
    }
}
#endif
