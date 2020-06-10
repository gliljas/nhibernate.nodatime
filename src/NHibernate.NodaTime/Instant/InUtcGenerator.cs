using NHibernate.Hql.Ast;
using NHibernate.NodaTime.Linq;
using System.Collections.ObjectModel;

namespace NHibernate.NodaTime
{
    internal class InUtcGenerator : IHqlMemberTransformer
    {
        public HqlExpression BuildHql(HqlExpression expression, ReadOnlyCollection<HqlExpression> arguments, HqlTreeBuilder treeBuilder)
        {
            var ex= treeBuilder.CastToIType(new CompositeCustomType<TzdbZonedDateTimeAsUtcDateTimeType>(), expression);
            typeof(HqlTreeNode).GetMethod("SetText", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).Invoke(ex, new object[] { "method, method" });
            return ex;
        }
    }
}