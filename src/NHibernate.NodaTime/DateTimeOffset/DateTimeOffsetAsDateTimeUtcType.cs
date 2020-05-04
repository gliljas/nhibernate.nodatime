using NHibernate.SqlTypes;
using NHibernate.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.NodaTime
{
    public class DateTimeOffsetAsDateTimeUtcType : AbstractStructType<DateTimeOffset, DateTime>
    {
        protected override IType ValueType => NHibernateUtil.DateTime;
        protected override SqlType SqlType => SqlTypeFactory.GetDateTime(7);
        protected override DateTimeOffset Unwrap(DateTime value) => DateTime.SpecifyKind(value, DateTimeKind.Utc);
        protected override DateTime Wrap(DateTimeOffset value) => value.UtcDateTime;
    }
}
