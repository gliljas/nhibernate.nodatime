using NHibernate.Type;
using NodaTime;

namespace NHibernate.NodaTime
{
    public abstract class AbstractOffsetDateType<TPersisted, TNullableType> : AbstractStructType<OffsetDate, TPersisted, TNullableType>
        where TNullableType : NullableType, new()

    {
        protected override OffsetDate Cast(object value)
        {
            if (value is LocalDate localDate)
            {
                return localDate.WithOffset(Offset.Zero);
            }
            return base.Cast(value);
        }
    }
}