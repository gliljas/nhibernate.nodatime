using NHibernate.Dialect.Function;
using NHibernate.Engine;
using NHibernate.Hql.Ast;
using NHibernate.SqlCommand;
using NHibernate.Type;
using System.Collections;
using System.Collections.ObjectModel;

namespace NHibernate.NodaTime.Linq
{
    internal class LoadAsTransformer : AbstractTransformer
    {
        private readonly IType _type;

        public LoadAsTransformer(IType type)
        {
            _type = type;
        }
        public override HqlExpression BuildHql(HqlExpression expression, ReadOnlyCollection<HqlExpression> arguments, HqlTreeBuilder treeBuilder)
        {
            return treeBuilder.CastToIType(_type, expression);
        }
    }

    internal class CastTransformer : AbstractTransformer
    {
        private readonly System.Type _type;

        public CastTransformer(System.Type type)
        {
            _type = type;
        }
        public override HqlExpression BuildHql(HqlExpression expression, ReadOnlyCollection<HqlExpression> arguments, HqlTreeBuilder treeBuilder)
        {
            return treeBuilder.Cast(expression, _type);
        }
    }

    public class CustomCast : ISQLFunction
    {
        private readonly IType _returnType;

        public CustomCast(IType returnType)
        {
            _returnType = returnType;
        }
        public bool HasArguments => true;

        public bool HasParenthesesIfNoArguments => true;

        public SqlString Render(IList args, ISessionFactoryImplementor factory)
        {
            return new SqlString("(" + args[0] + ")");
        }

        public IType ReturnType(IType columnType, IMapping mapping) => _returnType;
    }
}