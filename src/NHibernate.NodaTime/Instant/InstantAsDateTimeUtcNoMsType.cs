using NHibernate.SqlTypes;
using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    public class InstantAsDateTimeUtcNoMsType : AbstractStructType<Instant, DateTime>
    {
        protected override IType ValueType => NHibernateUtil.DateTimeNoMs;

        protected override SqlType SqlType => SqlTypeFactory.DateTime;

        protected override Instant Unwrap(DateTime value) => Instant.FromDateTimeUtc(DateTime.SpecifyKind(value, DateTimeKind.Utc));

        protected override DateTime Wrap(Instant value) => value.ToDateTimeUtc();
    }
}
