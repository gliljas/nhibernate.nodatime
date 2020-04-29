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
    public class InstantAsInt64MillisecondsType : AbstractStructType<Instant, long>
    {
        protected override IType ValueType => NHibernateUtil.Int64;

        protected override SqlType SqlType => SqlTypeFactory.Int64;

        protected override Instant Unwrap(long value) => Instant.FromUnixTimeMilliseconds(value);

        protected override long Wrap(Instant value) => value.ToUnixTimeMilliseconds();
    }
}
