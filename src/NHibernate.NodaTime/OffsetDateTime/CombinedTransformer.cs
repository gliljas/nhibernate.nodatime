using NHibernate.Hql.Ast;
using System.Collections.ObjectModel;

namespace NHibernate.NodaTime
{
    internal class CombinedTransformer : AbstractTransformer
    {
        private readonly AbstractTransformer _transformer1;
        private readonly AbstractTransformer _transformer2;

        public CombinedTransformer(AbstractTransformer transformer1, AbstractTransformer transformer2)
        {
            _transformer1 = transformer1;
            _transformer2 = transformer2;
        }

        public override HqlExpression BuildHql(HqlExpression expression, ReadOnlyCollection<HqlExpression> arguments, HqlTreeBuilder treeBuilder)
        {
            return _transformer2.BuildHql(_transformer1.BuildHql(expression, arguments, treeBuilder), arguments, treeBuilder);
        }
    }
}