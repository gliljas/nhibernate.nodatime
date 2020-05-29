using NodaTime;

namespace NHibernate.NodaTime.Extensions
{
    internal static class InstantExtensions
    {
        internal static OffsetDateTime WithOffsetFromDateTimeOffset(this Instant instance, Offset offset) => instance.WithOffset(offset);
        internal static ZonedDateTime InUtcFromDateTimeOffset(this Instant instance) => instance.InUtc();

        internal static ZonedDateTime InZoneFromDateTimeOffset(this Instant instance, DateTimeZone zone) => instance.InZone(zone);

        internal static Instant PlusFromDateTimeOffset(this Instant instance, Duration duration) => instance.Plus(duration);

        internal static Instant MinusFromDateTimeOffset(this Instant instance, Duration duration) => instance.Minus(duration);

        internal static Instant PlusHours(this Instant instance, int hours) => instance.Plus(Duration.FromHours(hours));
        internal static Instant PlusMinutes(this Instant instance, int minutes) => instance.Plus(Duration.FromMinutes(minutes));
        internal static Instant PlusSeconds(this Instant instance, int seconds) => instance.Plus(Duration.FromSeconds(seconds));
        internal static Instant PlusMilliseconds(this Instant instance, int seconds) => instance.Plus(Duration.FromMilliseconds(seconds));

        internal static OffsetDateTime WithOffsetSeconds(this Instant instance, int seconds) => instance.WithOffset(Offset.FromSeconds(seconds));

    }
}
