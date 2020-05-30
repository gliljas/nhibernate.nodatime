using NHibernate.Type;
using NodaTime;

namespace NHibernate.NodaTime
{
    public abstract class AbstractYearMonthType<TPersisted, TNullableType> : AbstractStructType<YearMonth, TPersisted, TNullableType>
        where TNullableType : NullableType, new()
    {
    }
}