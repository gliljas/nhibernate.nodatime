using NHibernate.Hql.Ast;
using NHibernate.Linq.Functions;
using NHibernate.Linq.Visitors;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;

namespace NHibernate.NodaTime.Linq
{
    internal class GeneratorForMethodWithoutTypeLookup  : IHqlGeneratorForMethod
    {
        private readonly MethodInfo _method;
        private readonly IHqlMethodTransformer _hqlMethodTransformer;

        public GeneratorForMethodWithoutTypeLookup(MethodInfo method,IHqlMethodTransformer hqlMethodTransformer)
        {
            _method = method;
            _hqlMethodTransformer = hqlMethodTransformer;
        }

        public IEnumerable<MethodInfo> SupportedMethods => new[] { _method };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            return _hqlMethodTransformer.BuildHql(method, targetObject, arguments, treeBuilder, visitor);
        }
    }
}