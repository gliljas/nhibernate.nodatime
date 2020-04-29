#if NETFRAMEWORK
using NodaTime;

namespace NHibernate.NodaTime
{
    public class BclDateTimeZoneType : AbstractDateTimeZoneType
    {
        protected override IDateTimeZoneProvider DateTimeZoneProvider => DateTimeZoneProviders.Bcl;
    }
}
#endif
