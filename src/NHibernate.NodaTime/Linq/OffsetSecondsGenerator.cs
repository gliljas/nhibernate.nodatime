using NHibernate.Hql.Ast;
using NHibernate.Linq.Functions;
using NHibernate.Linq.Visitors;
using NHibernate.Util;
using NodaTime;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace NHibernate.NodaTime.Linq
{
    public class OffsetSecondsGenerator : IHqlGeneratorForProperty
    {
        public IEnumerable<MemberInfo> SupportedProperties => new[] { ReflectHelper.GetProperty(() => new Offset().Seconds) };

        public HqlTreeNode BuildHql(MemberInfo member, Expression expression, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(expression).AsExpression();
            return treeBuilder.TransparentCast(source, typeof(int));
        }
    }

    //public static class HqlTreeBuilderExtensions
    //{
    //    public static HqlExpression CastToNHibernateType(this HqlTreeBuilder treeBuilder, HqlExpression expression, IType type)
    //    {
    //        return new HqlTransparentITypeCast(treeBuilder.Into().Factory, expression, type);
            
    //    }
    //}
}