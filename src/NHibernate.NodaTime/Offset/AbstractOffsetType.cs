using NHibernate.Type;
using NodaTime;

namespace NHibernate.NodaTime
{
    public abstract class AbstractOffsetType<TPersisted, TNullableType> : AbstractStructType<Offset, TPersisted, TNullableType>
         where TNullableType : NullableType, new()
    {
    }
}