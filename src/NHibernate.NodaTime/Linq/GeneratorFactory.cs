using NHibernate.Linq.Functions;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.NodaTime.Linq
{
    public class GeneratorFactory
    {
        public static IReadOnlyList<IHqlGeneratorForMethod> CreateMethodGeneratorsForTypes(params INodaTimeType[] types)
        {
            var generators = new List<IHqlGeneratorForMethod>();
            var groupedTypes = types.GroupBy(x => x.ReturnedType);
            foreach (var groupedType in groupedTypes)
            {
                var typesForType = groupedType.ToList();
                if (typesForType.Count > 1)
                {
                    var allTransformers = typesForType.SelectMany(x => GetMethods(x)).ToList();
                    var allMethods = typesForType.SelectMany(x => GetMethods(x).Select(y => new { Type = x, Method = y.Key, Transformer = y.Value })).GroupBy(x => x.Method);
                    foreach (var groupedMethodTransformer in allMethods)
                    {
                        var generatorWithTypeLookup = new GeneratorForMethodWithTypeLookup(groupedMethodTransformer.Key, groupedMethodTransformer.ToDictionary(x => x.Type, x => x.Transformer));
                        generators.Add(generatorWithTypeLookup);
                    }
                }
                else
                {
                    var typeForType = typesForType.Single();
                    foreach (var methodTransformers in GetMethods(typeForType))
                    {
                        var generator = new GeneratorForMethodWithoutTypeLookup(methodTransformers.Key, methodTransformers.Value);
                        generators.Add(generator);
                    }
                }
            }
            return generators;
        }

        private static IDictionary<MethodInfo, IHqlMethodTransformer> GetMethods(INodaTimeType type)
        {
            var supportLinqQueries = type as ISupportLinqQueries<object>;
            if (supportLinqQueries != null)
            {
                return supportLinqQueries.SupportedQueryMethods.ToDictionary(x => x.Method, x => x.Transformer);
            }
            return new Dictionary<MethodInfo, IHqlMethodTransformer>();
        }
    }
}
