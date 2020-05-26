using NHibernate.Engine;
using NHibernate.SqlTypes;
using NHibernate.Type;
using NHibernate.UserTypes;
using System;

namespace NHibernate.NodaTime
{
    public class DateTimeOffsetAsUtcDateTimeNoMsType : AbstractDateTimeOffsetAsDateTimeType<UtcDateTimeNoMsType>
    {
    }
}
