using NHibernate.SqlTypes;
using NHibernate.Type;
using NodaTime;

namespace NHibernate.NodaTime
{
    public abstract class AbstractDateTimeZoneType : AbstractStructType<DateTimeZone, string>
    {
        protected override IType ValueType => NHibernateUtil.AnsiString;
        protected override SqlType SqlType => SqlTypeFactory.GetAnsiString(30);

        protected abstract IDateTimeZoneProvider DateTimeZoneProvider { get; }

        protected override string Wrap(DateTimeZone value) => value.Id;

        protected override DateTimeZone Unwrap(string value) => DateTimeZoneProvider[value];
    }
}
