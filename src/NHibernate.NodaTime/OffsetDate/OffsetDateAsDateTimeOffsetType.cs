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
    public class OffsetDateAsDateTimeOffsetType : AbstractStructType<OffsetDate,DateTimeOffset>
    {
        protected override IType ValueType => NHibernateUtil.DateTimeOffset;

        protected override SqlType SqlType => SqlTypeFactory.DateTimeOffSet;

        protected override OffsetDate Unwrap(DateTimeOffset value) => OffsetDateTime.FromDateTimeOffset(value).ToOffsetDate();

        protected override DateTimeOffset Wrap(OffsetDate value) => value.At(LocalTime.MinValue).ToDateTimeOffset();

    }
}
