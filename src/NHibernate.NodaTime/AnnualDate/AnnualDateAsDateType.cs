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
    public class AnnualDateAsDateType : AbstractStructType<AnnualDate, DateTime>
    {
        protected override IType ValueType => NHibernateUtil.Date;
        protected override SqlType SqlType => SqlTypeFactory.Date;
        protected override AnnualDate Unwrap(DateTime value) => new AnnualDate(value.Month, value.Day);
        protected override DateTime Wrap(AnnualDate value) => value.InYear(2000).ToDateTimeUnspecified();
    }
}
