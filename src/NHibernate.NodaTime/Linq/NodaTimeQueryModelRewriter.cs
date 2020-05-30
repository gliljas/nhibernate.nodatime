﻿using NHibernate.Engine;
using NHibernate.Linq.Visitors;
using NHibernate.Type;
using NodaTime;
using Remotion.Linq;
using Remotion.Linq.Clauses;
using Remotion.Linq.Clauses.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NHibernate.NodaTime.Linq
{
    public class NodaTimeQueryModelVisitor : QueryModelVisitorBase
    {
        // override
    }

    public class NodaTimeQueryModelRewriterFactory : IQueryModelRewriterFactory
    {
        public QueryModelVisitorBase CreateVisitor(VisitorParameters parameters)
        {
            return new NodaTimeQueryModelVisitor();
        }
    }

    public class ReplaceMethodsAndPropertiesVisitor : NhExpressionVisitor
    {
        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Expression.Type.Assembly == typeof(Instant).Assembly)
            {
                var types = TryGetMappedTypesFromExpression(node);
                if (types.Count > 0)
                {
                    foreach (var type in types)
                    {
                        if (type is CustomType customType)
                        {
                            if (customType.UserType is IPropertyRewriter propertyRewriter)
                            {
                            }
                        }
                    }
                }
            }
            return base.VisitMember(node);
        }

        private IReadOnlyList<IType> TryGetMappedTypesFromExpression(Expression expression)
        {
            return new List<IType>();
        }
    }

    public class ExpressionMapping
    {
        private readonly ISessionFactoryImplementor _sessionFactoryImplementor;
        private Dictionary<Expression, IReadOnlyList<IType>> _cache = new Dictionary<Expression, IReadOnlyList<IType>>();

        public ExpressionMapping(ISessionFactoryImplementor sessionFactoryImplementor)
        {
            _sessionFactoryImplementor = sessionFactoryImplementor;
        }

        public IReadOnlyList<IType> TryGetMappedTypesFromExpression(Expression expression)
        {
            if (_cache.TryGetValue(expression, out var types))
            {
                return types;
            }
            var visitor = new TypeExtractionVisitor(_sessionFactoryImplementor);
            visitor.Visit(expression);
            return visitor.ExtractedTypes;
        }

        private class TypeExtractionVisitor : NhExpressionVisitor
        {
            private readonly ISessionFactoryImplementor _sessionFactoryImplementor;

            public TypeExtractionVisitor(ISessionFactoryImplementor sessionFactoryImplementor)
            {
                _sessionFactoryImplementor = sessionFactoryImplementor;
                ExtractedTypes = new List<IType>();
            }

            public List<IType> ExtractedTypes { get; internal set; }

            protected override Expression VisitQuerySourceReference(QuerySourceReferenceExpression expression)
            {
                if (expression.ReferencedQuerySource is JoinClause joinClause)
                {
                    return base.Visit(joinClause.InnerSequence);
                }

                return expression;
            }

            protected override Expression VisitMethodCall(MethodCallExpression node)
            {
                return base.VisitMethodCall(node);
            }

            protected override Expression VisitConditional(ConditionalExpression node)
            {
                return base.VisitConditional(node);
            }

            protected override Expression VisitConstant(ConstantExpression node)
            {
                if (node.Value is IQueryable queryable)
                {
                    var persister = _sessionFactoryImplementor.GetEntityPersister(queryable.ElementType.FullName);
                }
                return node;
            }

            protected override Expression VisitMember(MemberExpression node)
            {
                return base.VisitMember(node);
            }
        }
    }
}