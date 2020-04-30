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
    public class OffsetDateTimeAsDateTimeOffsetType : AbstractStructType<OffsetDateTime,DateTimeOffset>
    {
        protected override IType ValueType => NHibernateUtil.DateTimeOffset;

        protected override SqlType SqlType => SqlTypeFactory.DateTimeOffSet;

        protected override OffsetDateTime Unwrap(DateTimeOffset value) => OffsetDateTime.FromDateTimeOffset(value);

        protected override DateTimeOffset Wrap(OffsetDateTime value) => value.ToDateTimeOffset();

    }
}
