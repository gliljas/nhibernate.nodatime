using NHibernate.Hql.Ast;
using NHibernate.Linq.Functions;
using NHibernate.Linq.Visitors;
using NHibernate.Type;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace NHibernate.NodaTime.Linq
{
    internal class GeneratorForPropertyWithTypeLookup : IHqlGeneratorForProperty
    {
        private readonly MemberInfo _member;
        private readonly IReadOnlyDictionary<System.Type, IHqlMemberTransformer> _transformers;

        public GeneratorForPropertyWithTypeLookup(MemberInfo member, IReadOnlyDictionary<INodaTimeType, IHqlMemberTransformer> transformers)
        {
            _member = member;
            _transformers = transformers.ToDictionary(x => x.Key.GetType(), x => x.Value);
        }

        public IEnumerable<MemberInfo> SupportedProperties => new[] { _member };

        public HqlTreeNode BuildHql(MemberInfo member, Expression expression, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var type = MappingHelper.GetType(visitor, expression);
            if (type == null)
            {
                throw new System.Exception();
            }
            var exposingType = type.AsNodaType();
            if (exposingType == null)
            {
                throw new System.Exception();
            }
            if (!_transformers.TryGetValue(exposingType.GetType(), out var transformer))
            {
                throw new NotImplementedException($"No transformer has been implemented for {member}, using {exposingType}");
            }
            var hqlExpression = visitor.Visit(expression).AsExpression();
            //var args = arguments.Select(visitor.Visit).Select(x => x.AsExpression()).ToList().AsReadOnly();
            return transformer.BuildHql(hqlExpression, new List<HqlExpression>().AsReadOnly(), treeBuilder);
        }

       
    }
    internal class GeneratorForMethodWithTypeLookup : IHqlGeneratorForMethod
    {
        private readonly MethodInfo _method;
        private readonly IReadOnlyDictionary<System.Type, IHqlMemberTransformer> _transformers;

        public GeneratorForMethodWithTypeLookup(MethodInfo method, IReadOnlyDictionary<INodaTimeType, IHqlMemberTransformer> transformers)
        {
            _method = method;
            _transformers = transformers.ToDictionary(x => x.Key.GetType(), x => x.Value);
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
            if (!_transformers.TryGetValue(exposingType.GetType(), out var transformer))
            {
                throw new NotImplementedException($"No transformer has been implemented for {method}, using {exposingType}");
            }
            var expression = visitor.Visit(targetObject).AsExpression();
            var args = arguments.Select(visitor.Visit).Select(x => x.AsExpression()).ToList().AsReadOnly();
            return transformer.BuildHql(expression, args, treeBuilder);
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