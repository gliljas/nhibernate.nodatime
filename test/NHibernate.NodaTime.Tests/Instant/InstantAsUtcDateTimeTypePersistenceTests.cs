using Antlr.Runtime.Misc;
using FluentAssertions;
using NHibernate.Linq;
using NHibernate.NodaTime.Linq;
using NHibernate.NodaTime.Tests.Fixtures;
using NHibernate.Util;
using NodaTime;
using NodaTime.Extensions;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using Xunit;
using Tzdb = NodaTime.DateTimeZoneProviders;

namespace NHibernate.NodaTime.Tests
{
    public class InstantAsUtcDateTimeTypePersistenceTests : AbstractInstantPersistenceTests<InstantAsUtcDateTimeType>
    {
        public InstantAsUtcDateTimeTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {
        }

        [Theory]
        [NodaTimeAutoData]
        public void Something(List<TestEntity<Instant>> testEntities)
        {
            var zone = Tzdb.Tzdb.GetAllZones().First();
            var z = testEntities[0].TestProperty.InZone(zone);
            var count = testEntities.Where(x => x.TestProperty.InZone(zone) == z).Count();
            AddToDatabase(testEntities.ToArray());
            //ExecuteWithQueryable(q =>
            //{
            //    var count2 = q.Select(x => new { Entity = x, InZone = new { Instant = x.TestProperty, Zone = zone.MappedAs(new CustomType<TzdbDateTimeZoneType>()) } }).Where(x => x.InZone.Instant == z.ToInstant() && x.InZone.Zone == z.Zone.MappedAs(new CustomType<TzdbDateTimeZoneType>())).Count();
            //    count.Should().Be(count2);
            //});

            ExecuteWithQueryable(q =>
           {
               //var count2 = q.Where(x => x.TestProperty.InZone(zone)==z).ToList();

               var count2 = q.Select(x => new 
                {
                    Instance=x,
                    InZone = new ZonedDateTimeProxy { Instant = x.TestProperty, Zone = zone.MappedAs(new CustomType<TzdbDateTimeZoneType>()) }
                }
              ).Count();

               //var count3 = q.Select(x => new ExpandoObject(Dictionary<string, object>() { { "Instance", x } }//,
               //                                                                                               //{ "InZone", new ZonedDateTimeProxy { Instant = x.TestProperty, Zone = zone.MappedAs(new CustomType<TzdbDateTimeZoneType>()) }

               //).Where(x => ((Instant)x["Instance"]) != null).ToList();// Where(x => ((ZonedDateTimeProxy)x["InZone"]).Instant == z.ToInstant() && ((ZonedDateTimeProxy)x["InZone"]).Zone == z.Zone.MappedAs(new CustomType<TzdbDateTimeZoneType>())).Select(x => (TestEntity<Instant>)x["Instance"]).Count();
               //count.Should().Be(count3);

               var type = DynamicClassFactory.CreateType(new List<DynamicProperty>
               {
                   new DynamicProperty("Instance", typeof(TestEntity<Instant>)),
                   new DynamicProperty("InZone", typeof(ZonedDateTimeProxy))
               });

               var rParam = Expression.Parameter(typeof(TestEntity<Instant>));

               var select = ReflectHelper.GetMethod(() => Queryable.Select<object, object>(default, default(Expression<System.Func<object, object>>))).GetGenericMethodDefinition().MakeGenericMethod(q.ElementType, type);

               var countMethod = ReflectHelper.GetMethod(() => Queryable.Count<object>(default,default)).GetGenericMethodDefinition().MakeGenericMethod(type);



               var a = Expression.MemberInit(
                    Expression.New(type),
                    Expression.Bind(
                        type.GetProperty("Instance"),
                        rParam
                    ),
                    Expression.Bind(
                        type.GetProperty("InZone"),
                        Expression.MemberInit(
                            Expression.New(typeof(ZonedDateTimeProxy)),
                            Expression.Bind(
                                typeof(ZonedDateTimeProxy).GetProperty("Instant"),
                                Expression.Property(rParam, "TestProperty")
                            ),
                            Expression.Bind(
                                typeof(ZonedDateTimeProxy).GetProperty("Zone"),
                                Expression.Constant(z.Zone)
                            )
                        )
                    )
                );

               var lambda = Expression.Lambda(a, rParam);

               var pparam = Expression.Parameter(type);

               var clambda = Expression.Lambda(Expression.Equal(Expression.Property(Expression.Property(pparam, "InZone"), "Instant"), Expression.Constant(testEntities[0].TestProperty)), pparam);


               q.Provider.Execute(Expression.Call(countMethod,Expression.Call(select, Expression.Constant(q), lambda), clambda)); 

           });
        }
    }
}