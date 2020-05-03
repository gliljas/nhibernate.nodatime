using NHibernate.SqlTypes;
using NHibernate.Type;
using System;

namespace NHibernate.NodaTime
{
    public class DateTimeOffsetAsDateTimeUtcNoMsType : AbstractStructType<DateTimeOffset, DateTime>
    {
        protected override IType ValueType => NHibernateUtil.DateTimeNoMs;
        protected override SqlType SqlType => SqlTypeFactory.DateTime;
        protected override DateTimeOffset Unwrap(DateTime value) => value;
        protected override DateTime Wrap(DateTimeOffset value) => value.UtcDateTime;
    }
}
