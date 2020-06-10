using NodaTime;
using Remotion.Linq.Parsing;
using System;
using System.Linq.Expressions;

namespace NHibernate.NodaTime.Linq
{
    public class CompositeTypeExpandingVisitor : RelinqExpressionVisitor
    {
        public CompositeTypeExpandingVisitor()
        {
        }

        internal static Expression Rewrite(Expression expression)
        {
            return new CompositeTypeExpandingVisitor().Visit(expression);
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            //if (node.Type == typeof(ZonedDateTime))
            //{
            //    //if (node.Method.Name == "InUtc")
            //    //{
            //    //    return Expression.MemberInit(Expression.New(typeof(ZonedDateTimeStub)),
            //    //        Expression.MemberBind(Expression.Property()))
            //    //}
            //    if (node.Method.Name == "InZone" && node.Object.Type == typeof(Instant))
            //    {
            //        //return Expression.MemberInit(Expression.New(typeof(ZonedDateTimeStub)),Expression.MemberBind(Expression.Property()))
            //    }
            //}
            return base.VisitMethodCall(node);
        }
    }

    public class ZonedDateTimeProxy// : IEquatable<ZonedDateTime>
    {
        public Instant Instant { get; set; }
        public DateTimeZone Zone { get; set; }

        //public bool Equals(ZonedDateTime other)
        //{
        //    return other.ToInstant() == Instant && other.Zone == Zone;
        //}

        //public static explicit operator ZonedDateTime(ZonedDateTimeStub stub) => new ZonedDateTime(stub.Instant, stub.Zone);
        //public static explicit operator ZonedDateTimeStub(ZonedDateTime d) => new ZonedDateTimeStub { Instant = d.ToInstant(), Zone = d.Zone };
    }
}