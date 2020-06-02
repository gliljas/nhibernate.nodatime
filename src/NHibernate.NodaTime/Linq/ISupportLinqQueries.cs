using System.Collections.Generic;

namespace NHibernate.NodaTime.Linq
{
    public interface ISupportLinqQueries
    {
        IEnumerable<ISupportedQueryProperty> SupportedQueryProperties { get; }
        IEnumerable<ISupportedQueryMethod> SupportedQueryMethods { get; }
    }


}