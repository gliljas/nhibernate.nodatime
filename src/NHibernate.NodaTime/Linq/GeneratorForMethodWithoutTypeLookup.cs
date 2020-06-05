using NHibernate.Hql.Ast;
using NHibernate.Linq.Functions;
using NHibernate.Linq.Visitors;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace NHibernate.NodaTime.Linq
{
    internal class GeneratorForMethodWithoutTypeLookup : IHqlGeneratorForMethod
    {
        private readonly MethodInfo _method;
        private readonly IHqlMemberTransformer _hqlMethodTransformer;

        public GeneratorForMethodWithoutTypeLookup(MethodInfo method, IHqlMemberTransformer hqlMethodTransformer)
        {
            _method = method;
            _hqlMethodTransformer = hqlMethodTransformer;
        }

        public IEnumerable<MethodInfo> SupportedMethods => new[] { _method };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var expression = visitor.Visit(targetObject).AsExpression();
            var args = arguments.Select(visitor.Visit).Select(x => x.AsExpression()).ToList().AsReadOnly();
            return _hqlMethodTransformer.BuildHql(expression, args, treeBuilder);
        }
    }

    internal class GeneratorForPropertyWithoutTypeLookup : IHqlGeneratorForProperty
    {
        private readonly MemberInfo _member;
        private readonly IHqlMemberTransformer _hqlPropertyTransformer;

        public GeneratorForPropertyWithoutTypeLookup(MemberInfo member, IHqlMemberTransformer hqlPropertyTransformer)
        {
            _member = member;
            _hqlPropertyTransformer = hqlPropertyTransformer;
        }

        public IEnumerable<MemberInfo> SupportedProperties => new[] { _member };

        public HqlTreeNode BuildHql(MemberInfo member, Expression expression, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var hqlExpression = visitor.Visit(expression).AsExpression();
            return _hqlPropertyTransformer.BuildHql(hqlExpression, new List<HqlExpression>().AsReadOnly(), treeBuilder);
        }
    }
}