using NHibernate.SqlTypes;
using NHibernate.Type;
using System;

namespace NHibernate.NodaTime
{
    public class DateTimeOffsetAsUtcDbTimestampType : AbstractDateTimeOffsetAsDateTimeType<UtcDbTimestampType>
    {
    }
}
