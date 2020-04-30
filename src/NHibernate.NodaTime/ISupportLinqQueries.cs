using System.Collections.Generic;

namespace NHibernate.NodaTime
{
    public interface ISupportLinqQueries<T>
    {
        IEnumerable<SupportedQueryProperty<T>> SupportedQueryProperties { get; }
    }
}