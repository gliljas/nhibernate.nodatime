using NHibernate.Hql.Ast;
using NHibernate.Linq.Functions;
using NHibernate.Linq.Visitors;
using NHibernate.Type;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;

namespace NHibernate.NodaTime.Linq
{
    internal class GeneratorForMethodWithTypeLookup : IHqlGeneratorForMethod
    {
        private readonly MethodInfo _method;
        private readonly IReadOnlyDictionary<INodaTimeType, IHqlMethodTransformer> _transformers;

        public GeneratorForMethodWithTypeLookup(MethodInfo method, IReadOnlyDictionary<INodaTimeType, IHqlMethodTransformer> transformers)
        {
            _method = method;
            _transformers = transformers;
        }

        public IEnumerable<MethodInfo> SupportedMethods => new[] { _method };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var type = MappingHelper.GetType(visitor, targetObject);
            if (type == null)
            {
                throw new System.Exception();
            }
            var exposingType = type.AsNodaType();
            if (exposingType == null)
            {
                throw new System.Exception();
            }
            if (!_transformers.TryGetValue(exposingType, out var transformer))
            {
                throw new System.Exception();
            }
            return transformer.BuildHql(method, targetObject, arguments, treeBuilder, visitor);
        }
    }

    public static class TypeExtensions
    {
        public static INodaTimeType AsNodaType(this IType instance)
        {
            if (instance is INodaTimeType n0)
            {
                return n0;
            }
            if (instance is CustomType customType && customType.UserType is INodaTimeType n1)
            {
                return n1;
            }
            if (instance is CompositeCustomType compositeCustomType && compositeCustomType.UserType is INodaTimeType n2)
            {
                return n2;
            }
            return null;
        }
    }
}