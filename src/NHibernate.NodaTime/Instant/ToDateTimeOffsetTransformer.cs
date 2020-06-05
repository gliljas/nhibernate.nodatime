using NHibernate.Engine;
using NHibernate.Hql.Ast;
using NHibernate.Linq.Visitors;
using NHibernate.NodaTime.Linq;
using NHibernate.Type;
using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;

namespace NHibernate.NodaTime
{
    internal class ToDateTimeOffsetTransformer : IHqlMemberTransformer
    {
        public HqlExpression BuildHql(HqlExpression expression, ReadOnlyCollection<HqlExpression> arguments, HqlTreeBuilder treeBuilder)
        {
            return treeBuilder.Cast(expression, typeof(DateTimeOffset)).AsExpression();
        }
    }

    internal class ToDateTimeUtcTransformer : IHqlMemberTransformer
    {
        public HqlExpression BuildHql(HqlExpression expression, ReadOnlyCollection<HqlExpression> arguments, HqlTreeBuilder treeBuilder)
        {
            return treeBuilder.CastToIType(NHibernateUtil.UtcDateTime, treeBuilder.Cast(expression, typeof(DateTime)));
        }
    }

    internal class ToUnixTimeMillisecondsTransformer : MethodCallTransformer
    {
        public ToUnixTimeMillisecondsTransformer() : base("nodafromdatetimeoffsettounixtimemilliseconds")
        {
        }
    }

    internal class MethodCallTransformer : IHqlMemberTransformer
    {
        private readonly string _methodName;

        protected MethodCallTransformer(string methodName)
        {
            _methodName = methodName;
        }
        public HqlExpression BuildHql(HqlExpression expression, ReadOnlyCollection<HqlExpression> arguments, HqlTreeBuilder treeBuilder)
        {
            return treeBuilder.MethodCall(_methodName, expression);
        }
    }

    public static class TreeBuilderExtensions
    {
        public static HqlExpression CastToIType(this HqlTreeBuilder builder, IType type, params HqlExpression[] hqlExpression)
        {
            return builder.MethodCall($"nodacastto{type.Name}", hqlExpression);
        }
    }

}