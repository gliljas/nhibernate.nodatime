using NHibernate.SqlTypes;
using NHibernate.Type;
using NodaTime;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persist an <see cref="Offset"/> as its corresponding number of seconds, using <see cref="Int32Type"/>
    /// </summary>
    public class OffsetAsInt32SecondsType : AbstractOffsetType<int, Int32Type>
    {
        protected override Offset Unwrap(int value) => Offset.FromSeconds(value);

        protected override int Wrap(Offset value) => value.Seconds;
    }

}
