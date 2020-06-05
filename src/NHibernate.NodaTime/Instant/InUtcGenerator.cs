using NHibernate.Hql.Ast;
using NHibernate.NodaTime.Linq;
using System.Collections.ObjectModel;

namespace NHibernate.NodaTime
{
    internal class InUtcGenerator : IHqlMemberTransformer
    {
        public HqlExpression BuildHql(HqlExpression expression, ReadOnlyCollection<HqlExpression> arguments, HqlTreeBuilder treeBuilder)
        {
            return treeBuilder.CastToIType(new CompositeCustomType<TzdbZonedDateTimeAsUtcDateTimeType>(), expression, treeBuilder.Constant("UTC"));
        }
    }
}