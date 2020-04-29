using NHibernate.SqlTypes;
using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    public class InstantAsDateTimeOffsetType : AbstractStructType<Instant, DateTimeOffset>
    {
        protected override IType ValueType => NHibernateUtil.DateTime;

        protected override SqlType SqlType => SqlTypeFactory.DateTime;

        protected override Instant Unwrap(DateTimeOffset value) => Instant.FromDateTimeOffset(value);

        protected override DateTimeOffset Wrap(Instant value) => value.ToDateTimeOffset();
    }
}
