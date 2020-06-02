using NHibernate.Hql.Ast;
using NHibernate.Linq.Visitors;
using NHibernate.NodaTime.Linq;
using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;

namespace NHibernate.NodaTime
{
    internal class ToDateTimeOffsetTransformer : IHqlMethodTransformer
    {
        public HqlTreeNode BuildHql(MethodInfo method, Expression expression, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(expression).AsExpression();
            return treeBuilder.Cast(source, typeof(DateTimeOffset));
        }
    }
}