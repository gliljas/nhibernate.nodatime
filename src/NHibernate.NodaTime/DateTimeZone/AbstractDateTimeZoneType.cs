using NHibernate.SqlTypes;
using NHibernate.Type;
using NodaTime;

namespace NHibernate.NodaTime
{
    public abstract class AbstractDateTimeZoneType : AbstractStructType<DateTimeZone, string>
    {
        public AbstractDateTimeZoneType() : base(TypeFactory.GetStringType(30))
        {
            
        }
        protected abstract IDateTimeZoneProvider DateTimeZoneProvider { get; }

        protected override string Wrap(DateTimeZone value) => value.Id;

        protected override DateTimeZone Unwrap(string value) => DateTimeZoneProvider[value];
    }
}
