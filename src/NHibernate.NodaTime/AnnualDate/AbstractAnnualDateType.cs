using NHibernate.Type;
using NodaTime;

namespace NHibernate.NodaTime
{
    public abstract class AbstractAnnualDateType<TPersisted, TNullableType> : AbstractStructType<AnnualDate, TPersisted, TNullableType>
        where TNullableType : NullableType, new()
    {
    }
}