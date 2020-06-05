using System.Collections.Generic;

namespace NHibernate.NodaTime.Linq
{
    public interface ISupportLinqQueries
    {
        IEnumerable<ISupportedQueryMember> SupportedQueryMembers { get; }
    }


}