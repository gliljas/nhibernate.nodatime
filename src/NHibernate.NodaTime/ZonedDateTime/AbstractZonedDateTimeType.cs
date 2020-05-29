using NHibernate.Type;
using NHibernate.UserTypes;
using NodaTime;

namespace NHibernate.NodaTime
{
    public abstract class AbstractZonedDateTimeType<TPersisted,TPersistedType,TDateTimeZoneType> : AbstractTwoPropertyStructType<ZonedDateTime, TPersisted, DateTimeZone, TPersistedType, CustomType<TDateTimeZoneType>>
     where TPersistedType : IType, new()
     where TDateTimeZoneType : IUserType
    {
        protected override string Property2Name => nameof(ZonedDateTime.Zone);
        protected override int Property1ColumnSpan => 1;
        protected override int Property2ColumnSpan => 1;
        protected override DateTimeZone GetProperty2Value(ZonedDateTime value) => value.Zone;
    }
}
