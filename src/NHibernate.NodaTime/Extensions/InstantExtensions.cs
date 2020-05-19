using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.NodaTime.Extensions
{
    internal static class InstantExtensions
    {
        internal static OffsetDateTime WithOffsetFromDateTimeOffset(this Instant instance, Offset offset) => instance.WithOffset(offset);
        internal static ZonedDateTime InUtcFromDateTimeOffset(this Instant instance) => instance.InUtc();

        internal static ZonedDateTime InZoneFromDateTimeOffset(this Instant instance, DateTimeZone zone) => instance.InZone(zone);

        internal static Instant PlusFromDateTimeOffset(this Instant instance, Duration duration) => instance.Plus(duration);


    }
}
