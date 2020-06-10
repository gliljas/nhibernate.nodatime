using NHibernate.Hql.Ast;
using NHibernate.Type;
using NodaTime;
using System;
using System.Linq.Expressions;

namespace NHibernate.NodaTime
{
    public class DurationAsInt64NanosecondsType : AbstractDurationType<long, Int64Type>
    {
        protected override Duration Unwrap(long value) => Duration.FromNanoseconds(value);

        protected override long Wrap(Duration value) => value.ToInt64Nanoseconds();

        //public override Expression<Func<Duration, long>>[] ExpressionsExposingPersisted => new Expression<Func<Duration, long>>[]
        //{
        //    x => x.ToInt64Nanoseconds()
        //};

        private static NHTypeConverter<DurationAsInt64NanosecondsType, DurationAsTicksType> ToDurationAsTicksType()
        {
            return new MultiplicationConverter<DurationAsInt64NanosecondsType, DurationAsTicksType>(10);
        }
    }

    public abstract class NHTypeConverter<TInput, TOutput>
    {
        public abstract HqlExpression Convert(HqlTreeBuilder treeBuilder, HqlExpression input);
    }

    public class MultiplicationConverter<TInput, TOutput> : NHTypeConverter<TInput, TOutput>
    {
        private readonly int _factor;

        public MultiplicationConverter(int factor)
        {
            _factor = factor;
        }
        public override HqlExpression Convert(HqlTreeBuilder treeBuilder, HqlExpression input)
        {
            return treeBuilder.Multiply(input, treeBuilder.Constant(_factor));
        }
    }

    public class DurationAsTicksType : AbstractDurationType<long, Int64Type>
    {
        protected override Duration Unwrap(long value) => Duration.FromTicks(value);

        protected override long Wrap(Duration value) => value.BclCompatibleTicks;

        //public override Expression<Func<Duration, long>>[] ExpressionsExposingPersisted => new Expression<Func<Duration, long>>[]
        //{
        //    x => (long)x.BclCompatibleTicks
        //};
    }
}