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
        protected override SqlType SqlType => SqlTypeFactory.DateTime;
        protected override DateTimeOffset Unwrap(DateTime value) => value;
        protected override DateTime Wrap(DateTimeOffset value) => value.UtcDateTime;
    }
}
