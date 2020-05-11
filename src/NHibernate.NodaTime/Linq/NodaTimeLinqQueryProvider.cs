using NHibernate.Engine;
using NHibernate.Linq;
using NHibernate.Util;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
            expression = DateIntervalVisitor.Visit(expression, _session.Factory);
            return base.PrepareQuery(expression, out query);
        }
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
