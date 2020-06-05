using NHibernate.Hql.Ast;
using System.Collections.ObjectModel;

namespace NHibernate.NodaTime
{
    internal class AdditionTransformer : AbstractTransformer
    {
        private readonly AbstractTransformer _transformer1;
        private readonly AbstractTransformer _transformer2;

        public AdditionTransformer(AbstractTransformer transformer1, AbstractTransformer transformer2)
        {
            _transformer1 = transformer1;
            _transformer2 = transformer2;
        }

        public override HqlExpression BuildHql(HqlExpression expression, ReadOnlyCollection<HqlExpression> arguments, HqlTreeBuilder treeBuilder)
        {
            return treeBuilder.Add(_transformer1.BuildHql(expression,arguments,treeBuilder), _transformer2.BuildHql(expression, arguments, treeBuilder));
        }
    }
}