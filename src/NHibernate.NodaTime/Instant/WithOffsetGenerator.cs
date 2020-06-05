using NHibernate.Hql.Ast;
using NHibernate.NodaTime.Linq;
using System.Collections.ObjectModel;

namespace NHibernate.NodaTime
{
    internal class WithOffsetGenerator : IHqlMemberTransformer
    {
        public HqlExpression BuildHql(HqlExpression expression, ReadOnlyCollection<HqlExpression> arguments, HqlTreeBuilder treeBuilder)
        {
            return expression;
        }
    }
}