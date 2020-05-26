using NHibernate.SqlTypes;
using NHibernate.Type;
using System;

namespace NHibernate.NodaTime
{
    public class DateTimeOffsetAsUtcTicksType : AbstractDateTimeOffsetAsDateTimeType<UtcTicksType>
    {
    }
}
