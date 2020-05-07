using NHibernate.SqlTypes;
using NHibernate.Type;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.NodaTime
{
    public class LocalDateAsDateTimeType : AbstractStructType<LocalDate, DateTime, DateTimeType>
    {
        protected override LocalDate Unwrap(DateTime value) => LocalDate.FromDateTime(value);

        protected override DateTime Wrap(LocalDate value) => value.ToDateTimeUnspecified();

    }

    public class LocalDateVisitor : ExpressionVisitor
    {
        protected override Expression VisitBinary(BinaryExpression node)
        {
            //if (node.Left.Type == typeof(LocalDate) && node.Right.Type == typeof(LocalDate))
            //{
            //    var left = Visit(node.Left);
            //    var right = Visit(node.Right);
            //    return Expression.MakeBinary(node.NodeType,
            //            Expression.Call(left, "ToDateTimeUnspecified", new System.Type[] { }),
            //            Expression.Call(right, "ToDateTimeUnspecified", new System.Type[] { })
            //    );
            //}

            //if (node.Left.Type == typeof(Instant) && node.Right.Type == typeof(Instant))
            //{
            //    var left = Visit(node.Left);
            //    var right = Visit(node.Right);
            //    return Expression.MakeBinary(node.NodeType,
            //            Expression.Call(left, "ToDateTimeUnspecified", new System.Type[] { }),
            //            Expression.Call(right, "ToDateTimeUnspecified", new System.Type[] { })
            //    );
            //}
            return base.VisitBinary(node);
        }
    }
}
