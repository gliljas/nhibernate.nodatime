using NHibernate.Type;

namespace NHibernate.NodaTime
{
    public class DateTimeOffsetAsUtcDbTimestampType : AbstractDateTimeOffsetAsDateTimeType<UtcDbTimestampType>
    {
    }
}