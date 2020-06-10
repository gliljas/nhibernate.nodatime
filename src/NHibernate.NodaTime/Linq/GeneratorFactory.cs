using NHibernate.Criterion;
using NHibernate.Linq.Functions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

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

        public static IReadOnlyList<IHqlGeneratorForProperty> CreatePropertyGeneratorsForTypes(params INodaTimeType[] types)
        {
            var generators = new List<IHqlGeneratorForProperty>();
            var groupedTypes = types.GroupBy(x => x.ReturnedType);
            foreach (var groupedType in groupedTypes)
            {
                var typesForType = groupedType.ToList();
                if (typesForType.Count > 1)
                {
                    var allTransformers = typesForType.SelectMany(x => GetProperties(x)).ToList();
                    var allMethods = typesForType.SelectMany(x => GetProperties(x).Select(y => new { Type = x, Member = y.Key, Transformer = y.Value })).GroupBy(x => x.Member);
                    foreach (var groupedMethodTransformer in allMethods)
                    {
                        var generatorWithTypeLookup = new GeneratorForPropertyWithTypeLookup(groupedMethodTransformer.Key, groupedMethodTransformer.ToDictionary(x => x.Type, x => x.Transformer));
                        generators.Add(generatorWithTypeLookup);
                    }
                }
                else
                {
                    var typeForType = typesForType.Single();
                    foreach (var propertyTransformers in GetProperties(typeForType))
                    {
                        var generator = new GeneratorForPropertyWithoutTypeLookup(propertyTransformers.Key, propertyTransformers.Value);
                        generators.Add(generator);
                    }
                }
            }
            return generators;
        }

        private static IDictionary<MethodInfo, IHqlMemberTransformer> GetMethods(INodaTimeType type)
        {
            var returnDict = new Dictionary<MethodInfo, IHqlMemberTransformer>();
            var supportLinqQueries = type as ISupportLinqQueries;
            if (supportLinqQueries != null)
            {
                returnDict = supportLinqQueries.SupportedQueryMembers.Where(x=>x.Member is MethodInfo).ToDictionary(x => (MethodInfo)x.Member, x => x.Transformer);
            }

            //var m = type.GetType().GetProperty("ExpressionsExposingPersisted");
            //if (m != null)
            //{
            //    var s = m.GetValue(type) as IEnumerable;
            //    if (s != null)
            //    {
            //        var expressions = s.OfType<LambdaExpression>();
            //        foreach (var lambda in expressions)
            //        {
            //            if (lambda.Body is MethodCallExpression methodCallExpression)
            //            {
            //                if (!returnDict.ContainsKey(methodCallExpression.Method))
            //                {
            //                    returnDict.Add(methodCallExpression.Method, new LoadAsTransformer(NHibernateUtil.GuessType(methodCallExpression.Type)));
            //                }
            //            }
            //        }
            //    }
            //}
            return returnDict;
        }

        private static IDictionary<MemberInfo, IHqlMemberTransformer> GetProperties(INodaTimeType type)
        {
            var supportLinqQueries = type as ISupportLinqQueries;
            var returnDict = new Dictionary<MemberInfo, IHqlMemberTransformer>();
            if (supportLinqQueries != null)
            {
                returnDict = supportLinqQueries.SupportedQueryMembers.Where(x=>x.Member is PropertyInfo).ToDictionary(x => x.Member, x => x.Transformer);
            }
            //var m = type.GetType().GetProperty("ExpressionsExposingPersisted");
            //if (m != null)
            //{
            //    var s = m.GetValue(type) as IEnumerable;
            //    if (s != null)
            //    {
            //        var expressions = s.OfType<LambdaExpression>();
            //        foreach (var lambda in expressions)
            //        {
            //            if (lambda.Body is MemberExpression memberExpression && memberExpression.Member is PropertyInfo propertyInfo)
            //            {
            //                if (!returnDict.ContainsKey(memberExpression.Member))
            //                {
            //                    returnDict.Add(memberExpression.Member, new LoadAsTransformer(NHibernateUtil.GuessType(propertyInfo.PropertyType)));
            //                }
            //            }
            //        }
            //    }
            //}
            return returnDict;
        }
    }
}
