using NHibernate.Type;

namespace NHibernate.NodaTime
{
    public class DateTimeOffsetAsUtcDbTimestampAndTimeSpanType : AbstractDateTimeOffsetAsDateTimeAndOffsetType<UtcDbTimestampType>
    {
    }
}
