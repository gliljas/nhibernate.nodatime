using NHibernate.SqlTypes;
using NHibernate.Type;
using System;

namespace NHibernate.NodaTime
{
    public class DateTimeOffsetAsUtcDateTimeType : AbstractDateTimeOffsetAsDateTimeType<UtcDateTimeType>
    {
    }
}
