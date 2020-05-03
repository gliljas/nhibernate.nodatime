using NHibernate.SqlTypes;
using NHibernate.Type;
using System;

namespace NHibernate.NodaTime
{
    public class DateTimeOffsetAsInt64MillisecondsType : AbstractStructType<DateTimeOffset, long>
    {
        protected override IType ValueType => NHibernateUtil.Int64;
        protected override SqlType SqlType => SqlTypeFactory.Int64;
        protected override DateTimeOffset Unwrap(long value) => DateTimeOffset.FromUnixTimeMilliseconds(value);
        protected override long Wrap(DateTimeOffset value) => value.ToUnixTimeMilliseconds();
    }
}
