using NHibernate.Hql.Ast;
using NHibernate.NodaTime.Linq;
using System.Collections.ObjectModel;

namespace NHibernate.NodaTime
{
    internal class FunctionTransformer : AbstractTransformer
    {
        private string v;

        public FunctionTransformer(string v)
        {
            this.v = v;
        }

        public override HqlExpression BuildHql(HqlExpression expression, ReadOnlyCollection<HqlExpression> arguments, HqlTreeBuilder treeBuilder)
        {
            return treeBuilder.MethodCall(v, expression);
        }
    }
}