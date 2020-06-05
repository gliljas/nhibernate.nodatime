using NHibernate.Hql.Ast;
using System.Collections.ObjectModel;

namespace NHibernate.NodaTime.Linq
{
    public interface IHqlMemberTransformer
    {
        HqlExpression BuildHql(HqlExpression expression, ReadOnlyCollection<HqlExpression> arguments, HqlTreeBuilder treeBuilder);
    }
}