using NHibernate.Hql.Ast;
using NHibernate.Linq.Visitors;
using NHibernate.NodaTime.Linq;
using NHibernate.Type;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;

namespace NHibernate.NodaTime
{
    public class GenericConversionTransformer<T> : IHqlMemberTransformer where T : IType, new()
    {
        public HqlExpression BuildHql(HqlExpression expression, ReadOnlyCollection<HqlExpression> arguments, HqlTreeBuilder treeBuilder)
        {
            return treeBuilder.CastToIType(new T(), expression);
        }
    }
}