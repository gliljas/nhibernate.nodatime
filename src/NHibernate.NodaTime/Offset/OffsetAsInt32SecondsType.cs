using NHibernate.SqlTypes;
using NHibernate.Type;
using NodaTime;

namespace NHibernate.NodaTime
{
    public class OffsetAsInt32SecondsType : AbstractStructType<Offset,int>
    {
        protected override IType ValueType => NHibernateUtil.Int32;

        protected override SqlType SqlType => SqlTypeFactory.Int32;

        protected override Offset Unwrap(int value) => Offset.FromSeconds(value);

        protected override int Wrap(Offset value) => value.Seconds;
    }
}
