using System.Collections.Generic;

namespace NHibernate.NodaTime.Linq
{
    public interface ISupportLinqQueries<T>
    {
        IEnumerable<SupportedQueryProperty<T>> SupportedQueryProperties { get; }
        IEnumerable<SupportedQueryMethod<T>> SupportedQueryMethods { get; }
    }
}