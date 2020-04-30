using NHibernate.SqlTypes;
using NHibernate.Type;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.NodaTime
{
    public class LocalDateTimeAsDateTimeType : AbstractStructType<LocalDateTime, DateTime>
    {
        protected override IType ValueType => NHibernateUtil.DateTimeOffset;

        protected override SqlType SqlType => SqlTypeFactory.DateTimeOffSet;

        protected override LocalDateTime Unwrap(DateTime value) => LocalDateTime.FromDateTime(value);

        protected override DateTime Wrap(LocalDateTime value) => value.ToDateTimeUnspecified();

    }
}
