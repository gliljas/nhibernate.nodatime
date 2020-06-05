using NHibernate.Hql.Ast;
using NHibernate.NodaTime.Linq;
using System.Collections.ObjectModel;

namespace NHibernate.NodaTime
{
    internal abstract class AbstractTransformer : IHqlMemberTransformer
    {
        public abstract HqlExpression BuildHql(HqlExpression expression, ReadOnlyCollection<HqlExpression> arguments, HqlTreeBuilder treeBuilder);

        public static AbstractTransformer operator *(AbstractTransformer transformer, long factor)
        {
            return new MultiplicationTransformer(transformer,factor);
        }

        public static AbstractTransformer operator /(AbstractTransformer transformer, long factor)
        {
            return new DivisionTransformer(transformer,factor);
        }

        public static AbstractTransformer operator +(AbstractTransformer transformer1, AbstractTransformer transformer2)
        {
            return  new AdditionTransformer(transformer1, transformer2);
        }

        public static AbstractTransformer operator >(AbstractTransformer transformer1, AbstractTransformer transformer2)
        {
            return new CombinedTransformer(transformer1, transformer2);
        }

        public static AbstractTransformer operator <(AbstractTransformer transformer1, AbstractTransformer transformer2)
        {
            return new CombinedTransformer(transformer2, transformer1);
        }
    }
}