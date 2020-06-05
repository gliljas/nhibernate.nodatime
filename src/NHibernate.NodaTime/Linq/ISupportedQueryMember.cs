using System.Reflection;

namespace NHibernate.NodaTime.Linq
{
    public interface ISupportedQueryMember
    {
        MemberInfo Member { get; }
        IHqlMemberTransformer Transformer { get; }
    }
}