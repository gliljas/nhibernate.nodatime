using NHibernate.SqlTypes;
using NHibernate.Type;
using NodaTime;

namespace NHibernate.NodaTime
{
    public class OffsetAsInt32MilliSecondsType : AbstractOffsetType<int, Int32Type>
    {
        protected override Offset Unwrap(int value) => Offset.FromMilliseconds(value);

        protected override int Wrap(Offset value) => value.Milliseconds;
    }

}
