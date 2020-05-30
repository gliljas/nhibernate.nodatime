using System;
using System.Linq.Expressions;
using System.Reflection;

namespace NHibernate.NodaTime.Linq
{
    public class MappedMemberExpression : Expression
    {
        private readonly Expression _expression;
        private readonly MemberInfo _member;

        internal MappedMemberExpression(Expression expression, MemberInfo member)
        {
            _expression = expression;
            _member = member;
        }

        //public override System.Type Type => _member.;
        public MemberInfo Member => _member;

        public Expression Expression => _expression;

        protected override Expression Accept(ExpressionVisitor visitor)
        {
            if (visitor is MappedExpressionVisitor mappedExpressionVisitor)
            {
                return mappedExpressionVisitor.VisitMappedMember(this);
            }
            throw new ArgumentException($"Can only be visited by a {nameof(MappedExpressionVisitor)}");
        }

        public override ExpressionType NodeType => CustomExpressionTypes.MappedMemberAccess;

        public MappedMemberExpression Update(Expression expression)
        {
            if (expression == Expression)
            {
                return this;
            }
            return new MappedMemberExpression(Expression, Member);
        }
    }

    public static class CustomExpressionTypes
    {
        public static ExpressionType MappedMemberAccess = (ExpressionType)90000;
    }

    public class MappedExpressionVisitor : ExpressionVisitor
    {
        public Expression VisitMappedMember(MappedMemberExpression mappedMemberExpression)
        {
            return mappedMemberExpression.Update(Visit(mappedMemberExpression.Expression));
        }
    }

    //public class SuperMongo : ExpressionVisitor
    //{
    //    protected override Expression VisitMember(MemberExpression node)
    //    {
    //        var expression = Visit(node.Expression);
    //        var mappingMetaData = GetMapping(node);
    //        return new MappedMemberExpression(node.Expression, node.Member);
    //    }

    //    private object GetMapping(MemberExpression node)
    //    {
    //        if (node.)
    //    }
    //}
}