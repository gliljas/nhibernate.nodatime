using NHibernate.SqlTypes;
using NHibernate.Type;
using NodaTime;

namespace NHibernate.NodaTime
{
    public class InstantAsInt64TicksType : AbstractStructType<Instant, long>
    {
        protected override IType ValueType => NHibernateUtil.Int64;

        protected override SqlType SqlType => SqlTypeFactory.Int64;

        protected override Instant Unwrap(long value) => Instant.FromUnixTimeTicks(value);

        protected override long Wrap(Instant value) => value.ToUnixTimeTicks();
    }
}
