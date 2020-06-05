using NHibernate.Hql.Ast;
using NHibernate.NodaTime.Linq;
using System.Collections.ObjectModel;

namespace NHibernate.NodaTime
{
    internal class RemoveTimeFromDateTimeOffsetTransformer : AbstractTransformer
    {
        public RemoveTimeFromDateTimeOffsetTransformer()
        {
        }

        public override HqlExpression BuildHql(HqlExpression expression, ReadOnlyCollection<HqlExpression> arguments, HqlTreeBuilder treeBuilder)
        {
            return treeBuilder.MethodCall("nodaremovetimefromdatetimeoffset", expression);
        }
    }

    internal class RemoveDateFromDateTimeOffsetTransformer : AbstractTransformer
    {
        public RemoveDateFromDateTimeOffsetTransformer()
        {
        }

        public override HqlExpression BuildHql(HqlExpression expression, ReadOnlyCollection<HqlExpression> arguments, HqlTreeBuilder treeBuilder)
        {
            return treeBuilder.MethodCall("nodaremovedatefromdatetimeoffset", expression);
        }
    }
}