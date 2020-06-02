using NHibernate.Hql.Ast;
using NHibernate.Linq.Visitors;
using NHibernate.NodaTime.Linq;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;

namespace NHibernate.NodaTime
{
    internal class PlusDurationTransformer : IHqlMethodTransformer
    {
        public HqlTreeNode BuildHql(MethodInfo method, Expression expression, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            throw new System.NotImplementedException();
        }
    }
}