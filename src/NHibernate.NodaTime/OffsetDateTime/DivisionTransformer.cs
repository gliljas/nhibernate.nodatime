using NHibernate.Hql.Ast;
using System.Collections.ObjectModel;

namespace NHibernate.NodaTime
{
    internal class DivisionTransformer : AbstractTransformer
    {
        private readonly AbstractTransformer? _transformer = null;
        private long _factor;

        public DivisionTransformer(AbstractTransformer transformer, long factor)
        {
            _transformer = transformer;
            _factor = factor;
        }

        public DivisionTransformer(long factor)
        {
            _factor = factor;
        }

        public override HqlExpression BuildHql(HqlExpression expression, ReadOnlyCollection<HqlExpression> arguments, HqlTreeBuilder treeBuilder)
        {
            HqlExpression factor = treeBuilder.Constant(_factor);
            if (_transformer != null)
            {
                return treeBuilder.Cast(treeBuilder.Divide(_transformer.BuildHql(expression, arguments, treeBuilder), factor), typeof(long));
            }
            return treeBuilder.Cast(treeBuilder.Divide(expression, factor), typeof(long));
        }
    }

    internal class MultiplicationTransformer : AbstractTransformer
    {
        private readonly AbstractTransformer? _transformer;
        private long _factor;

        public MultiplicationTransformer(AbstractTransformer transformer, long factor)
        {
            _transformer = transformer;
            _factor = factor;
        }

        public MultiplicationTransformer(long factor)
        {
            _factor = factor;
        }

        public override HqlExpression BuildHql(HqlExpression expression, ReadOnlyCollection<HqlExpression> arguments, HqlTreeBuilder treeBuilder)
        {
            HqlExpression factor = treeBuilder.Constant(_factor);
            if (_transformer != null)
            {
                return treeBuilder.Multiply(treeBuilder.Cast(_transformer.BuildHql(expression, arguments, treeBuilder), typeof(long)), factor);
            }
            return treeBuilder.Multiply(treeBuilder.Cast(expression, typeof(long)), factor);

        }
    }
}