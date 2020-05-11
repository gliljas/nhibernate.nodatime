using NHibernate.SqlTypes;
using NHibernate.Type;
using NodaTime;

namespace NHibernate.NodaTime
{
    public class OffsetAsInt32SecondsType : AbstractOffsetType<int, Int32Type>
    {
        protected override Offset Unwrap(int value) => Offset.FromSeconds(value);

        protected override int Wrap(Offset value) => value.Seconds;
    }

}
