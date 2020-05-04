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
    public class OffsetTimeAsDateTimeOffsetType : AbstractStructType<OffsetTime, DateTimeOffset>
    {
        protected override IType ValueType => NHibernateUtil.DateTimeOffset;

        protected override SqlType SqlType => SqlTypeFactory.DateTimeOffSet;

        protected override OffsetTime Unwrap(DateTimeOffset value) => OffsetDateTime.FromDateTimeOffset(value).ToOffsetTime();

        protected override DateTimeOffset Wrap(OffsetTime value) => value.On(new LocalDate(1970, 1, 1)).ToDateTimeOffset();

    }
}
