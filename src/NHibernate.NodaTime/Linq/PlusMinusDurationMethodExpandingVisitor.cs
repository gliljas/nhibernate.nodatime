using NHibernate.Linq;
using NHibernate.NodaTime.Extensions;
using NHibernate.Util;
using NodaTime;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace NHibernate.NodaTime.Linq
{
    public class PlusMinusDurationMethodExpandingVisitor : ExpressionVisitor
    {
        private static readonly MethodInfo _instantPlus = ReflectHelper.GetMethod<Instant>(x => x.Plus(Duration.Zero));
        private static readonly MethodInfo _instantPlusHoursExtension = ReflectHelper.GetMethod(() => InstantExtensions.PlusHours(Instant.MinValue, 0));
        private static readonly MethodInfo _instantPlusMinutesExtension = ReflectHelper.GetMethod(() => InstantExtensions.PlusMinutes(Instant.MinValue, 0));
        private static readonly MethodInfo _instantPlusSecondsExtension = ReflectHelper.GetMethod(() => InstantExtensions.PlusSeconds(Instant.MinValue, 0));
        private static readonly MethodInfo _instantPlusMillisecondsExtension = ReflectHelper.GetMethod(() => InstantExtensions.PlusMilliseconds(Instant.MinValue, 0));
        private static readonly MethodInfo _instantPlusTicks = ReflectHelper.GetMethod<Instant>(x => x.PlusTicks(0));
        private static readonly MethodInfo _instantPlusNanoseconds = ReflectHelper.GetMethod<Instant>(x => x.PlusNanoseconds(0));
        private static readonly MethodInfo _instantMinus = ReflectHelper.GetMethod<Instant>(x => x.Minus(Duration.Zero));
        private static readonly MethodInfo _instantWithOffset = ReflectHelper.GetMethod<Instant>(x => x.WithOffset(Offset.Zero));
        private static readonly MethodInfo _instantWithOffsetSecondsExtension = ReflectHelper.GetMethod(() => InstantExtensions.WithOffsetSeconds(Instant.MinValue, 0));

        private static readonly MethodInfo _zonedDateTimePlus = ReflectHelper.GetMethod<ZonedDateTime>(x => x.Plus(Duration.Zero));
        private static readonly MethodInfo _zonedDateTimePlusTicks = ReflectHelper.GetMethod<ZonedDateTime>(x => x.PlusTicks(0));
        private static readonly MethodInfo _zonedDateTimePlusNanoseconds = ReflectHelper.GetMethod<ZonedDateTime>(x => x.PlusNanoseconds(0));
        private static readonly MethodInfo _zonedDateTimeMinus = ReflectHelper.GetMethod<ZonedDateTime>(x => x.Minus(Duration.Zero));

        private static readonly MethodInfo _offsetDateTimePlus = ReflectHelper.GetMethod<OffsetDateTime>(x => x.Plus(Duration.Zero));
        private static readonly MethodInfo _offsetDateTimePlusHours = ReflectHelper.GetMethod<OffsetDateTime>(x => x.PlusHours(0));
        private static readonly MethodInfo _offsetDateTimePlusMinutes = ReflectHelper.GetMethod<OffsetDateTime>(x => x.PlusMinutes(0));
        private static readonly MethodInfo _offsetDateTimePlusSeconds = ReflectHelper.GetMethod<OffsetDateTime>(x => x.PlusSeconds(0));
        private static readonly MethodInfo _offsetDateTimePlusMilliseconds = ReflectHelper.GetMethod<OffsetDateTime>(x => x.PlusMilliseconds(0));
        private static readonly MethodInfo _offsetDateTimePlusTicks = ReflectHelper.GetMethod<OffsetDateTime>(x => x.PlusTicks(0));
        private static readonly MethodInfo _offsetDateTimePlusNanoseconds = ReflectHelper.GetMethod<OffsetDateTime>(x => x.PlusNanoseconds(0));
        private static readonly MethodInfo _offsetDateTimeMinus = ReflectHelper.GetMethod<OffsetDateTime>(x => x.Minus(Duration.Zero));

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if ((node.Method == _instantPlus || node.Method == _instantMinus) && node.Arguments.FirstOrDefault() is ConstantExpression constantDurationExpressionInstant)
            {
                return InstantPlusToComponents(node, constantDurationExpressionInstant);
            }

            if ((node.Method == _zonedDateTimePlus || node.Method == _zonedDateTimeMinus) && node.Arguments.FirstOrDefault() is ConstantExpression constantDurationExpressionZonedDateTime)
            {
                return ZonedDateTimePlusToComponents(node, constantDurationExpressionZonedDateTime);
            }

            if ((node.Method == _offsetDateTimePlus || node.Method == _offsetDateTimeMinus) && node.Arguments.FirstOrDefault() is ConstantExpression constantDurationExpressionOffsetDateTime)
            {
                return OffsetDateTimePlusToComponents(node, constantDurationExpressionOffsetDateTime);
            }

            if (node.Method == _instantWithOffset && node.Arguments.FirstOrDefault() is ConstantExpression c)
            {
                var objectExpression = Visit(node.Object);
                var period = (Offset)c.Value;
                return Expression.Call(_instantWithOffsetSecondsExtension, objectExpression, Expression.Constant((int)(period.Seconds)));
            }

            return base.VisitMethodCall(node);
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (node.Type == typeof(TimeSpan))
            {
                return Expression.Call(ReflectHelper.GetMethod(() => LinqExtensionMethods.MappedAs<object>(null, null)).GetGenericMethodDefinition().MakeGenericMethod(typeof(TimeSpan)), node, Expression.Constant(NHibernateUtil.TimeSpan));
            }
            return base.VisitConstant(node);
        }

        private Expression InstantPlusToComponents(MethodCallExpression node, ConstantExpression constantDurationExpression)
        {
            var objectExpression = Visit(node.Object);
            var duration = (Duration)constantDurationExpression.Value;
            int factor = (node.Method == _instantMinus) ? -1 : 1;

            if (duration.Hours != 0)
            {
                objectExpression = Expression.Call(_instantPlusHoursExtension, objectExpression, Expression.Constant(factor * duration.Hours));
            }
            if (duration.Minutes != 0)
            {
                objectExpression = Expression.Call(_instantPlusMinutesExtension, objectExpression, Expression.Constant(factor * duration.Minutes));
            }
            if (duration.Seconds != 0)
            {
                objectExpression = Expression.Call(_instantPlusSecondsExtension, objectExpression, Expression.Constant(factor * duration.Seconds));
            }
            if (duration.Milliseconds != 0)
            {
                objectExpression = Expression.Call(_instantPlusMillisecondsExtension, objectExpression, Expression.Constant(factor * duration.Milliseconds));
            }

            //if (period.Days != 0)
            //{
            //    objectExpression = Expression.Call(objectExpression, _localDatePlusDays, Expression.Constant(factor * period.Days));
            //}

            //period
            //    objectExpression = Expression.Call(_instantPlusSecondsExtension, objectExpression, Expression.Constant((int)(factor * period.TotalSeconds)));

            //if (period. != 0)
            //{
            //    objectExpression = Expression.Call(_instantPlusMinutesExtension, objectExpression, Expression.Constant((factor * period.Minutes)));
            //}

            return objectExpression;
        }

        private Expression ZonedDateTimePlusToComponents(MethodCallExpression node, ConstantExpression constantDurationExpression)
        {
            var objectExpression = Visit(node.Object);
            var period = (Duration)constantDurationExpression.Value;
            int factor = (node.Method == _zonedDateTimeMinus) ? -1 : 1;
            if (period.Hours != 0)
            {
                objectExpression = Expression.Call(objectExpression, _zonedDateTimePlusNanoseconds, Expression.Constant(factor * period.TotalNanoseconds));
            }

            return objectExpression;
        }

        private Expression OffsetDateTimePlusToComponents(MethodCallExpression node, ConstantExpression constantDurationExpression)
        {
            var objectExpression = Visit(node.Object);
            var period = (Duration)constantDurationExpression.Value;
            int factor = (node.Method == _offsetDateTimeMinus) ? -1 : 1;
            if (period.TotalNanoseconds != 0)
            {
                objectExpression = Expression.Call(objectExpression, _offsetDateTimePlusNanoseconds, Expression.Constant(factor * period.TotalNanoseconds));
            }

            return objectExpression;
        }
    }
}