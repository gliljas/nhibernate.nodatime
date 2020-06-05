using NHibernate.Hql.Ast;
using System.Collections.ObjectModel;

namespace NHibernate.NodaTime
{
    internal class SubPropertyTransformer : AbstractTransformer
    {
        private readonly string _subProperty;

        public SubPropertyTransformer(string subProperty)
        {
            _subProperty = subProperty;
        }
        public override HqlExpression BuildHql(HqlExpression expression, ReadOnlyCollection<HqlExpression> arguments, HqlTreeBuilder treeBuilder)
        {
            return treeBuilder.Dot(expression, treeBuilder.Ident(_subProperty));
        }
    }
}