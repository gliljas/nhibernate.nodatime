using NHibernate.Type;

namespace NHibernate.NodaTime
{
    public class LocalDateTimeAsDbTimestampType : AbstractLocalDateTimeAsDateTimeType<DbTimestampType>
    {
    }
}
