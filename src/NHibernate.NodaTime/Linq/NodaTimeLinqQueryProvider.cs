using NHibernate.Engine;
using NHibernate.Linq;
using NHibernate.Type;
using NHibernate.Util;
using NodaTime;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NHibernate.NodaTime.Linq
{
    public class NodaTimeLinqQueryProvider : DefaultQueryProvider
    {
        private readonly ISessionImplementor _session;

        public NodaTimeLinqQueryProvider(ISessionImplementor session) : base(session)
        {
            _session = session;
        }

        protected override NhLinqExpression PrepareQuery(Expression expression, out IQuery query)
        {
            expression = NhRelinqQueryParser.PreTransform(expression, _session.Factory);
            expression = new PlusMinusDurationMethodExpandingVisitor().Visit(expression);
            expression = Blapp.Rewrite(expression, _session.Factory);
            return base.PrepareQuery(expression, out query);
        }
    }

    public class Blapp
    {
        private static FactoryLocal<ExpressionVisitor> _factoryLocalVisitor = new FactoryLocal<ExpressionVisitor>();

        public static Expression Rewrite(Expression expression, ISessionFactoryImplementor sessionFactory)
        {
            var visitor = _factoryLocalVisitor.GetOrAdd(sessionFactory, s => CreateVisitorFromMapping(s));
            return visitor.Visit(expression);
        }

        private static ExpressionVisitor CreateVisitorFromMapping(ISessionFactoryImplementor sessionFactory)
        {
            var types = sessionFactory.GetAllClassMetadata().Values.SelectMany(x => x.PropertyTypes).SelectMany(x => GetNodaTimeTypes(x, sessionFactory)).Distinct().ToList();
            return new DateIntervalVisitor(sessionFactory);
        }

        private static IEnumerable<INodaTimeType> GetNodaTimeTypes(IType x, ISessionFactoryImplementor sessionFactory)
        {
            if (x is INodaTimeType n0)
            {
                yield return n0;
            }
            else if (x is CustomType customType && customType.UserType is INodaTimeType n1)
            {
                yield return n1;
            }
            else if (x is CompositeCustomType compositeCustomType && compositeCustomType.UserType is INodaTimeType n2)
            {
                yield return n2;
            }
            else if (x is CollectionType collectionType)
            {
                foreach (var nodaType in GetNodaTimeTypes(collectionType.GetElementType(sessionFactory), sessionFactory))
                {
                    yield return nodaType;
                }
            }
            else if (x is IAbstractComponentType componentType)
            {
                foreach (var subType in componentType.Subtypes)
                {
                    foreach (var nodaType in GetNodaTimeTypes(subType, sessionFactory))
                    {
                        yield return nodaType;
                    }
                }
            }
        }
    }

    public interface INodaTimeType
    {
        System.Type ReturnedType { get; }
    }

    internal class DateIntervalVisitor : ExpressionVisitor
    {
        private readonly ISessionFactoryImplementor _sessionFactoryImplementor;

        public DateIntervalVisitor(ISessionFactoryImplementor sessionFactoryImplementor)
        {
            _sessionFactoryImplementor = sessionFactoryImplementor;
        }

        public static Expression Visit(Expression expression, ISessionFactoryImplementor sessionFactory)
        {
            expression = NhRelinqQueryParser.PreTransform(expression, sessionFactory);
            return new DateIntervalVisitor(sessionFactory).Visit(expression);
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node.Left.NodeType != ExpressionType.Constant && node.Right.NodeType == ExpressionType.Constant && node.Right.Type == typeof(DateInterval))
            {
                return Expression.MakeBinary(node.NodeType, Visit(node.Left), Expression.Convert(node.Right, typeof(DateIntervalWrapper)));
            }
            if (node.Right.NodeType != ExpressionType.Constant && node.Left.NodeType == ExpressionType.Constant && node.Left.Type == typeof(DateInterval))
            {
                return Expression.MakeBinary(node.NodeType, Expression.Convert(node.Left, typeof(DateIntervalWrapper)), Visit(node.Right));
            }
            return base.VisitBinary(node);
        }
    }
}