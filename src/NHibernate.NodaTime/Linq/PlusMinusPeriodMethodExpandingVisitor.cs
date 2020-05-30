using NHibernate.Util;
using NodaTime;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace NHibernate.NodaTime.Linq
{
    public class PlusMinusPeriodMethodExpandingVisitor : ExpressionVisitor
    {
        private static readonly MethodInfo _localTimePlus = ReflectHelper.GetMethod<LocalTime>(x => x.Plus(Period.Zero));
        private static readonly MethodInfo _localTimePlusHours = ReflectHelper.GetMethod<LocalTime>(x => x.PlusHours(0));
        private static readonly MethodInfo _localTimePlusMinutes = ReflectHelper.GetMethod<LocalTime>(x => x.PlusMinutes(0));
        private static readonly MethodInfo _localTimePlusSeconds = ReflectHelper.GetMethod<LocalTime>(x => x.PlusSeconds(0));
        private static readonly MethodInfo _localTimePlusMilliseconds = ReflectHelper.GetMethod<LocalTime>(x => x.PlusMilliseconds(0));
        private static readonly MethodInfo _localTimePlusTicks = ReflectHelper.GetMethod<LocalTime>(x => x.PlusTicks(0));
        private static readonly MethodInfo _localTimePlusNanoseconds = ReflectHelper.GetMethod<LocalTime>(x => x.PlusNanoseconds(0));
        private static readonly MethodInfo _localTimeMinus = ReflectHelper.GetMethod<LocalTime>(x => x.Minus(Period.Zero));

        private static readonly MethodInfo _localDateTimePlus = ReflectHelper.GetMethod<LocalDateTime>(x => x.Plus(Period.Zero));
        private static readonly MethodInfo _localDateTimePlusYears = ReflectHelper.GetMethod<LocalDateTime>(x => x.PlusYears(0));
        private static readonly MethodInfo _localDateTimePlusMonths = ReflectHelper.GetMethod<LocalDateTime>(x => x.PlusMonths(0));
        private static readonly MethodInfo _localDateTimePlusWeeks = ReflectHelper.GetMethod<LocalDateTime>(x => x.PlusWeeks(0));
        private static readonly MethodInfo _localDateTimePlusDays = ReflectHelper.GetMethod<LocalDateTime>(x => x.PlusDays(0));
        private static readonly MethodInfo _localDateTimePlusHours = ReflectHelper.GetMethod<LocalDateTime>(x => x.PlusHours(0));
        private static readonly MethodInfo _localDateTimePlusMinutes = ReflectHelper.GetMethod<LocalDateTime>(x => x.PlusMinutes(0));
        private static readonly MethodInfo _localDateTimePlusSeconds = ReflectHelper.GetMethod<LocalDateTime>(x => x.PlusSeconds(0));
        private static readonly MethodInfo _localDateTimePlusMilliseconds = ReflectHelper.GetMethod<LocalDateTime>(x => x.PlusMilliseconds(0));
        private static readonly MethodInfo _localDateTimePlusTicks = ReflectHelper.GetMethod<LocalDateTime>(x => x.PlusTicks(0));
        private static readonly MethodInfo _localDateTimePlusNanoseconds = ReflectHelper.GetMethod<LocalDateTime>(x => x.PlusNanoseconds(0));
        private static readonly MethodInfo _localDateTimeMinus = ReflectHelper.GetMethod<LocalDateTime>(x => x.Minus(Period.Zero));

        private static readonly MethodInfo _localDatePlus = ReflectHelper.GetMethod<LocalDate>(x => x.Plus(Period.Zero));
        private static readonly MethodInfo _localDatePlusYears = ReflectHelper.GetMethod<LocalDate>(x => x.PlusYears(0));
        private static readonly MethodInfo _localDatePlusMonths = ReflectHelper.GetMethod<LocalDate>(x => x.PlusMonths(0));
        private static readonly MethodInfo _localDatePlusWeeks = ReflectHelper.GetMethod<LocalDate>(x => x.PlusWeeks(0));
        private static readonly MethodInfo _localDatePlusDays = ReflectHelper.GetMethod<LocalDate>(x => x.PlusDays(0));
        private static readonly MethodInfo _localDateMinus = ReflectHelper.GetMethod<LocalDate>(x => x.Minus(Period.Zero));

        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node.Left.Type == typeof(LocalDateTime) && node.Right.Type == typeof(Period))
            {
                if (node.NodeType == ExpressionType.Add)
                {
                    return Visit(Expression.Call(node.Left, _localDateTimePlus, node.Right));
                }
                if (node.NodeType == ExpressionType.Subtract)
                {
                    return Visit(Expression.Call(node.Left, _localDateTimeMinus, node.Right));
                }
            }

            if (node.Left.Type == typeof(LocalDate) && node.Right.Type == typeof(Period))
            {
                if (node.NodeType == ExpressionType.Add)
                {
                    return Visit(Expression.Call(node.Left, _localDatePlus, node.Right));
                }
                if (node.NodeType == ExpressionType.Subtract)
                {
                    return Visit(Expression.Call(node.Left, _localDateMinus, node.Right));
                }
            }

            if (node.Left.Type == typeof(LocalTime) && node.Right.Type == typeof(Period))
            {
                if (node.NodeType == ExpressionType.Add)
                {
                    return Visit(Expression.Call(node.Left, _localTimePlus, node.Right));
                }
                if (node.NodeType == ExpressionType.Subtract)
                {
                    return Visit(Expression.Call(node.Left, _localTimeMinus, node.Right));
                }
            }

            return base.VisitBinary(node);
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if ((node.Method == _localDateTimePlus || node.Method == _localDateTimeMinus) && node.Arguments.FirstOrDefault() is ConstantExpression constantPeriodExpressionLocalDateTime)
            {
                return LocalDateTimePlusToComponents(node, constantPeriodExpressionLocalDateTime);
            }

            if ((node.Method == _localDatePlus || node.Method == _localDateMinus) && node.Arguments.FirstOrDefault() is ConstantExpression constantPeriodExpressionLocalDate)
            {
                return LocalDatePlusToComponents(node, constantPeriodExpressionLocalDate);
            }

            if ((node.Method == _localTimePlus || node.Method == _localTimeMinus) && node.Arguments.FirstOrDefault() is ConstantExpression constantExpressionLocalTime)
            {
                return LocalTimePlusToComponents(node, constantExpressionLocalTime);
            }

            return base.VisitMethodCall(node);
        }

        private Expression LocalTimePlusToComponents(MethodCallExpression node, ConstantExpression constantExpression)
        {
            var objectExpression = Visit(node.Object);
            var period = (Period)constantExpression.Value;
            int factor = (node.Method == _localTimeMinus) ? -1 : 1;

            if (period.Hours != 0)
            {
                objectExpression = Expression.Call(objectExpression, _localTimePlusHours, Expression.Constant(factor * period.Hours));
            }
            if (period.Minutes != 0)
            {
                objectExpression = Expression.Call(objectExpression, _localTimePlusMinutes, Expression.Constant(factor * period.Minutes));
            }
            if (period.Seconds != 0)
            {
                objectExpression = Expression.Call(objectExpression, _localTimePlusSeconds, Expression.Constant(factor * period.Seconds));
            }
            if (period.Milliseconds != 0)
            {
                objectExpression = Expression.Call(objectExpression, _localTimePlusMilliseconds, Expression.Constant(factor * period.Milliseconds));
            }
            if (period.Ticks != 0)
            {
                objectExpression = Expression.Call(objectExpression, _localTimePlusTicks, Expression.Constant(factor * period.Ticks));
            }
            if (period.Nanoseconds != 0)
            {
                objectExpression = Expression.Call(objectExpression, _localTimePlusNanoseconds, Expression.Constant(factor * period.Milliseconds));
            }
            return objectExpression;
        }

        private Expression LocalDateTimePlusToComponents(MethodCallExpression node, ConstantExpression constantPeriodExpression)
        {
            var objectExpression = Visit(node.Object);
            var period = (Period)constantPeriodExpression.Value;
            int factor = (node.Method == _localDateTimeMinus) ? -1 : 1;
            if (period.Years != 0)
            {
                objectExpression = Expression.Call(objectExpression, _localDateTimePlusYears, Expression.Constant(factor * period.Years));
            }
            if (period.Months != 0)
            {
                objectExpression = Expression.Call(objectExpression, _localDateTimePlusMonths, Expression.Constant(factor * period.Months));
            }
            if (period.Weeks != 0)
            {
                objectExpression = Expression.Call(objectExpression, _localDateTimePlusWeeks, Expression.Constant(factor * period.Weeks));
            }
            if (period.Days != 0)
            {
                objectExpression = Expression.Call(objectExpression, _localDateTimePlusDays, Expression.Constant(factor * period.Days));
            }
            if (period.Hours != 0)
            {
                objectExpression = Expression.Call(objectExpression, _localDateTimePlusHours, Expression.Constant(factor * period.Hours));
            }
            if (period.Minutes != 0)
            {
                objectExpression = Expression.Call(objectExpression, _localDateTimePlusMinutes, Expression.Constant(factor * period.Minutes));
            }
            if (period.Seconds != 0)
            {
                objectExpression = Expression.Call(objectExpression, _localDateTimePlusSeconds, Expression.Constant(factor * period.Seconds));
            }
            if (period.Milliseconds != 0)
            {
                objectExpression = Expression.Call(objectExpression, _localDateTimePlusMilliseconds, Expression.Constant(factor * period.Milliseconds));
            }
            if (period.Ticks != 0)
            {
                objectExpression = Expression.Call(objectExpression, _localDateTimePlusTicks, Expression.Constant(factor * period.Ticks));
            }
            if (period.Nanoseconds != 0)
            {
                objectExpression = Expression.Call(objectExpression, _localDateTimePlusNanoseconds, Expression.Constant(factor * period.Milliseconds));
            }
            return objectExpression;
        }

        private Expression LocalDatePlusToComponents(MethodCallExpression node, ConstantExpression constantPeriodExpression)
        {
            var objectExpression = Visit(node.Object);
            var period = (Period)constantPeriodExpression.Value;
            int factor = (node.Method == _localDateMinus) ? -1 : 1;
            if (period.Years != 0)
            {
                objectExpression = Expression.Call(objectExpression, _localDatePlusYears, Expression.Constant(factor * period.Years));
            }
            if (period.Months != 0)
            {
                objectExpression = Expression.Call(objectExpression, _localDatePlusMonths, Expression.Constant(factor * period.Months));
            }
            if (period.Weeks != 0)
            {
                objectExpression = Expression.Call(objectExpression, _localDatePlusWeeks, Expression.Constant(factor * period.Weeks));
            }
            if (period.Days != 0)
            {
                objectExpression = Expression.Call(objectExpression, _localDatePlusDays, Expression.Constant(factor * period.Days));
            }

            return objectExpression;
        }
    }
}