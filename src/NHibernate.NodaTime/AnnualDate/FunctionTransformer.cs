using NHibernate.NodaTime.Linq;

namespace NHibernate.NodaTime
{
    internal class FunctionTransformer : IHqlPropertyTransformer
    {
        private string _functionName;

        public FunctionTransformer(string functionName)
        {
            _functionName = functionName;
        }
    }
}