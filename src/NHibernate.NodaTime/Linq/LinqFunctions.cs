﻿using NHibernate.Hql.Ast;
using NHibernate.Linq.Functions;
using NHibernate.Linq.Visitors;
using NHibernate.NodaTime.Extensions;
using NHibernate.Type;
using NHibernate.Util;
using NodaTime;
using NodaTime.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;

namespace NHibernate.NodaTime.Linq
{
    public class LinqFunctions : DefaultLinqToHqlGeneratorsRegistry
    {
        public LinqFunctions()
        {
            //this.Merge(new OffsetDateDatePropertyGenerator());
            //this.Merge(new OffsetDateTimeDatePropertyGenerator());
            //this.Merge(new LocalDateYearPropertyGenerator());
            //this.Merge(new LocalDateWithOffsetMethodGenerator());

            this.Merge(new InstantPlusHoursGenerator());
            this.Merge(new InstantPlusMinutesGenerator());
            this.Merge(new InstantPlusSecondsGenerator());
            this.Merge(new InstantMaxGenerator());
            this.Merge(new InstantMinGenerator());

            this.Merge(new DateTimeOffsetOffsetGenerator());
            this.Merge(new DateTimeOffsetSubtractGenerator());
            this.Merge(new DateTimeOffsetSubtractTimeSpanGenerator());
            this.Merge(new DateTimeOffsetAddTicksGenerator());
            this.Merge(new DateTimeOffsetAddDaysGenerator());
            this.Merge(new DateTimeOffsetAddYearsGenerator());
            this.Merge(new DateTimeOffsetAddMinutesGenerator());
            this.Merge(new DateTimeOffsetAddSecondsGenerator());
            this.Merge(new DateTimeOffsetAddMillisecondsGenerator());
            this.Merge(new DateTimeOffsetDayOfWeekGenerator());
            this.Merge(new DateTimeOffsetDayOfYearGenerator());
            this.Merge(new DateTimeOffsetDateTimeGenerator());
            this.Merge(new DateTimeOffsetToInstantGenerator());
            this.Merge(new DateTimeOffsetToLocalTimeGenerator());
            this.Merge(new DateTimeOffsetTicksGenerator());
            this.Merge(new DateTimeOffsetUtcDateTimeGenerator());
            this.Merge(new DateTimeOffsetToUnixTimeSecondsGenerator());
            this.Merge(new DateTimeOffsetToUnixTimeMillisecondsGenerator());

            
            this.Merge(new OffsetSecondsGenerator());
            this.Merge(new OffsetMillisecondsGenerator());
            this.Merge(new OffsetNanosecondsGenerator());
            this.Merge(new OffsetTicksGenerator());
            this.Merge(new OffsetToTimeSpanGenerator());

            this.Merge(new LocalDateTimeToDateTimeUnspecifiedGenerator());
            this.Merge(new YearMonthYearGenerator());
            this.Merge(new YearMonthMonthGenerator());
            this.Merge(new InstantToDateTimeUtcGenerator());
            this.Merge(new InstantToUnixTimeMillisecondsGenerator());
            this.Merge(new InstantToUnixTimeSecondsGenerator());
            this.Merge(new InstantToUnixTimeTicksGenerator());
            this.Merge(new InstantMinusGenerator());
        }
    }

    public class OffsetMillisecondsGenerator : IHqlGeneratorForProperty
    {
        public IEnumerable<MemberInfo> SupportedProperties => new[] { ReflectHelper.GetProperty(() => new Offset().Milliseconds ) };

        public HqlTreeNode BuildHql(MemberInfo member, Expression expression, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(expression).AsExpression();
            return treeBuilder.TransparentCast(treeBuilder.Multiply(source, treeBuilder.Constant(NodaConstants.MillisecondsPerSecond)), typeof(long));
        }
    }

    public class OffsetNanosecondsGenerator : IHqlGeneratorForProperty
    {
        public IEnumerable<MemberInfo> SupportedProperties => new[] { ReflectHelper.GetProperty(() => new Offset().Nanoseconds) };

        public HqlTreeNode BuildHql(MemberInfo member, Expression expression, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(expression).AsExpression();
            return treeBuilder.TransparentCast(treeBuilder.Multiply(source, treeBuilder.Constant(NodaConstants.NanosecondsPerSecond)), typeof(long));
        }
    }
    public class OffsetTicksGenerator : IHqlGeneratorForProperty
    {
        public IEnumerable<MemberInfo> SupportedProperties => new[] { ReflectHelper.GetProperty(() => new Offset().Ticks) };

        public HqlTreeNode BuildHql(MemberInfo member, Expression expression, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(expression).AsExpression();
            return treeBuilder.TransparentCast(treeBuilder.Multiply(source, treeBuilder.Constant(NodaConstants.TicksPerSecond)), typeof(long));
        }
    }

    public class OffsetToTimeSpanGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod(() => new Offset().ToTimeSpan()) };
        
        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(targetObject).AsExpression();
            return treeBuilder.MethodCall("nodatickstotimespan",treeBuilder.Multiply(source, treeBuilder.Cast(treeBuilder.Constant(NodaConstants.TicksPerSecond), typeof(long))));
        }
    }


    public class DateTimeOffsetTicksGenerator : IHqlGeneratorForProperty
    {
        public IEnumerable<MemberInfo> SupportedProperties => new[] { ReflectHelper.GetProperty(() => new DateTimeOffset().Ticks) };

        public HqlTreeNode BuildHql(MemberInfo member, Expression expression, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(expression).AsExpression();
            return
               treeBuilder.MethodCall("nodaticksfromdatetimeoffset", source);
        }
    }



    public class DateTimeOffsetUtcDateTimeGenerator : IHqlGeneratorForProperty
    {
        public IEnumerable<MemberInfo> SupportedProperties => new[] { ReflectHelper.GetProperty(() => new DateTimeOffset().UtcDateTime) };

        public HqlTreeNode BuildHql(MemberInfo member, Expression expression, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(expression).AsExpression();
            return treeBuilder.Cast(treeBuilder.MethodCall("switchoffset", source, treeBuilder.Constant("+00:00")), typeof(DateTime));
        }
    }

    public class DateTimeOffsetDayOfYearGenerator : IHqlGeneratorForProperty
    {
        public IEnumerable<MemberInfo> SupportedProperties => new[] { ReflectHelper.GetProperty(() => new DateTimeOffset().DayOfYear) };

        public HqlTreeNode BuildHql(MemberInfo member, Expression expression, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(expression).AsExpression();
            return
               treeBuilder.MethodCall("nodadayofyear", source);
        }
    }

    public class DateTimeOffsetDayOfWeekGenerator : IHqlGeneratorForProperty
    {
        public IEnumerable<MemberInfo> SupportedProperties => new[] { ReflectHelper.GetProperty(() => new DateTimeOffset().DayOfWeek) };

        public HqlTreeNode BuildHql(MemberInfo member, Expression expression, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(expression).AsExpression();
            return
               treeBuilder.MethodCall("nodaisoweekday", source);
        }
    }

    public class DateTimeOffsetDateTimeGenerator : IHqlGeneratorForProperty
    {
        public IEnumerable<MemberInfo> SupportedProperties => new[] { ReflectHelper.GetProperty(() => new DateTimeOffset().DateTime) };

        public HqlTreeNode BuildHql(MemberInfo member, Expression expression, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(expression).AsExpression();
            return treeBuilder.Cast(source, typeof(DateTime));
        }
    }

    public class DateTimeOffsetOffsetGenerator : IHqlGeneratorForProperty
    {
        public IEnumerable<MemberInfo> SupportedProperties => new[] { ReflectHelper.GetProperty(() => new DateTimeOffset().Offset) };

        public HqlTreeNode BuildHql(MemberInfo member, Expression expression, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(expression).AsExpression();
            return treeBuilder.MethodCall("nodaminutestotimespan", treeBuilder.MethodCall("nodagetoffsetfromdatetimeoffsetasminutes", source));
        }
    }

    public class DateTimeOffsetToInstantGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod<DateTimeOffset>(x => x.ToInstant()) };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(arguments[0]).AsExpression();
            return treeBuilder.MethodCall("nodafromdatetimeoffsettoinstant", source);
        }
    }

    public class DateTimeOffsetToLocalTimeGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod<DateTimeOffset>(x => x.ToLocalTime()) };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(targetObject).AsExpression();
            return treeBuilder.MethodCall("nodafromdatetimeoffsettolocaltime", source);
        }
    }

    public class DateTimeOffsetToUnixTimeSecondsGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod<DateTimeOffset>(x => x.ToUnixTimeSeconds()) };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(targetObject).AsExpression();
            return treeBuilder.MethodCall("nodafromdatetimeoffsettounixtimeseconds", source);
        }
    }

    public class DateTimeOffsetToUnixTimeMillisecondsGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod<DateTimeOffset>(x => x.ToUnixTimeMilliseconds()) };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(targetObject).AsExpression();
            return treeBuilder.MethodCall("nodafromdatetimeoffsettounixtimemilliseconds", source);
        }
    }

    public class DateTimeOffsetSubtractGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod<DateTimeOffset>(x => x.Subtract(default(DateTimeOffset))) };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(targetObject).AsExpression();
            var arg1 = visitor.Visit(arguments[0]).AsExpression();
            return
                treeBuilder.MethodCall("nodatickstotimespan",//treeBuilder.TransparentCast(
                treeBuilder.Subtract(
                    treeBuilder.MethodCall("nodaticksfromdatetimeoffset", source), treeBuilder.MethodCall("nodaticksfromdatetimeoffset", arg1))
                //, typeof(long))
                );
        }
    }

    public class DateTimeOffsetAddYearsGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod<DateTimeOffset>(x => x.AddYears(0)) };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(targetObject).AsExpression();
            var arg1 = visitor.Visit(arguments[0]).AsExpression();
            return
                treeBuilder.MethodCall("addyearstodatetime", source, arg1);
        }
    }

    public class DateTimeOffsetAddTicksGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod<DateTimeOffset>(x => x.AddTicks(0)) };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(targetObject).AsExpression();
            var arg1 = visitor.Visit(arguments[0]).AsExpression();
            return
                treeBuilder.MethodCall("addtickstodatetime", source, arg1);
        }
    }

    public class DateTimeOffsetAddDaysGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod<DateTimeOffset>(x => x.AddDays(0)) };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(targetObject).AsExpression();
            var arg1 = visitor.Visit(arguments[0]).AsExpression();
            return
                treeBuilder.MethodCall("adddaystodatetime", source, arg1);
        }
    }

    public class DateTimeOffsetAddMinutesGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod<DateTimeOffset>(x => x.AddMinutes(0)) };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(targetObject).AsExpression();
            var arg1 = visitor.Visit(arguments[0]).AsExpression();
            return
                treeBuilder.MethodCall("addminutestodatetime", source, arg1);
        }
    }

    public class DateTimeOffsetAddSecondsGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod<DateTimeOffset>(x => x.AddSeconds(0)) };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(targetObject).AsExpression();
            var arg1 = visitor.Visit(arguments[0]).AsExpression();
            return
                treeBuilder.MethodCall("addsecondstodatetime", source, arg1);
        }
    }

    public class DateTimeOffsetAddMillisecondsGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod<DateTimeOffset>(x => x.AddMilliseconds(0)) };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(targetObject).AsExpression();
            var arg1 = visitor.Visit(arguments[0]).AsExpression();
            return
                treeBuilder.MethodCall("addmillisecondstodatetime", source, arg1);
        }
    }

    public class DateTimeOffsetAddGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod<DateTimeOffset>(x => x.Add(TimeSpan.Zero)) };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(targetObject).AsExpression();
            var arg1 = visitor.Visit(arguments[0]).AsExpression();
            return
                treeBuilder.MethodCall("adddaystodatetime", source, arg1);
        }
    }

    public class DateTimeOffsetSubtractTimeSpanGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod<DateTimeOffset>(x => x.Subtract(default(TimeSpan))) };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            //Just use DATEADD
            var source = visitor.Visit(targetObject).AsExpression();
            var arg1 = visitor.Visit(arguments[0]).AsExpression();
            return
                treeBuilder.MethodCall("nodatickstotimespan",//treeBuilder.TransparentCast(
                treeBuilder.Subtract(
                    treeBuilder.MethodCall("nodaticksfromdatetimeoffset", source), arg1)
                //, typeof(long))
                );
        }
    }

    public class InstantToDateTimeOffsetGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod<Instant>(x => x.ToDateTimeOffset()) };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(targetObject).AsExpression();
            return treeBuilder.MethodCall("todatetimeoffsetnoms", source);
        }
    }

    public class InstantPlusHoursGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod(() => InstantExtensions.PlusHours(Instant.MinValue, 0)) };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(arguments[0]).AsExpression();
            var hours = visitor.Visit(arguments[1]).AsExpression();
            //return treeBuilder.MethodCall("tonodainstant",
            return treeBuilder.MethodCall("nodafromtickstoinstant", treeBuilder.Add(source, treeBuilder.Multiply(hours, treeBuilder.Constant(NodaConstants.TicksPerHour))));
            //   );
        }
    }

    public class InstantPlusMinutesGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod(() => InstantExtensions.PlusMinutes(Instant.MinValue, 0)) };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(arguments[0]).AsExpression();
            var minutes = visitor.Visit(arguments[1]).AsExpression();
            //return treeBuilder.MethodCall("tonodainstant",
            //   return treeBuilder.MethodCall("addminutestodatetime", treeBuilder.Cast(source,typeof(DateTime)), minutes);
            return treeBuilder.MethodCall("nodafromtickstoinstant", treeBuilder.Add(source, treeBuilder.Multiply(minutes, treeBuilder.Constant(NodaConstants.TicksPerMinute))));

            //   );
        }
    }

    public class InstantPlusSecondsGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod(() => InstantExtensions.PlusSeconds(Instant.MinValue, 0)) };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(arguments[0]).AsExpression();
            var seconds = visitor.Visit(arguments[1]).AsExpression();
            //return treeBuilder.MethodCall("tonodainstant",
            return treeBuilder.MethodCall("nodafromtickstoinstant", treeBuilder.Add(source, treeBuilder.Multiply(seconds, treeBuilder.Constant(NodaConstants.TicksPerSecond))));
            //return treeBuilder.MethodCall("addsecondstodatetime", source, seconds);
            //   );
        }
    }

    public class InstantPlusMillisecondsGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod(() => InstantExtensions.PlusMilliseconds(Instant.MinValue, 0)) };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(arguments[0]).AsExpression();
            var seconds = visitor.Visit(arguments[1]).AsExpression();
            //return treeBuilder.MethodCall("tonodainstant",
            return treeBuilder.MethodCall("nodafromtickstoinstant", treeBuilder.Add(source, treeBuilder.Multiply(seconds, treeBuilder.Constant(NodaConstants.TicksPerMillisecond))));
            //return treeBuilder.MethodCall("addsecondstodatetime", source, seconds);
            //   );
        }
    }

    public class InstantWithOffsetGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod(() => InstantExtensions.WithOffsetSeconds(Instant.MinValue, 0)) };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(arguments[0]).AsExpression();
            var seconds = visitor.Visit(arguments[1]).AsExpression();

            return treeBuilder.MethodCall("withoffsetseconds", source);
            //   );
        }
    }

    public class OffsetDateTimeWithOffsetGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod<OffsetDateTime>(x => x.WithOffset(Offset.Zero)) };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(targetObject).AsExpression();
            var offset = visitor.Visit(arguments[0]).AsExpression();

            return treeBuilder.MethodCall("withoffsetseconds", source, offset);
            //   );
        }
    }

    public class LocalDateTimeToDateTimeUnspecifiedGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod<LocalDateTime>(x => x.ToDateTimeUnspecified()) };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(targetObject).AsExpression();

            return treeBuilder.MethodCall("todatetime", source);
        }
    }

    public class ZonedDateTimeToInstantGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod<ZonedDateTime>(x => x.ToInstant()) };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(targetObject).AsExpression();

            return treeBuilder.MethodCall("todatetime", source);
        }
    }

    public class ZonedDateTimeToDateTimeOffsetGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod<ZonedDateTime>(x => x.ToDateTimeOffset()) };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(targetObject).AsExpression();

            return treeBuilder.MethodCall("todatetime", source);
        }
    }

    public class ZonedDateTimeToOffsetDateTimeGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod<ZonedDateTime>(x => x.ToOffsetDateTime()) };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(targetObject).AsExpression();

            return treeBuilder.MethodCall("todatetime", source);
        }
    }

    public class YearMonthYearGenerator : IHqlGeneratorForProperty
    {
        public IEnumerable<MemberInfo> SupportedProperties => new[] { ReflectHelper.GetProperty((YearMonth x) => x.Year) };

        public HqlTreeNode BuildHql(MemberInfo member, Expression expression, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(expression).AsExpression();
            return treeBuilder.MethodCall("year", source);
        }
    }

    public class YearMonthMonthGenerator : IHqlGeneratorForProperty
    {
        public IEnumerable<MemberInfo> SupportedProperties => new[] { ReflectHelper.GetProperty((YearMonth x) => x.Month) };

        public HqlTreeNode BuildHql(MemberInfo member, Expression expression, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(expression).AsExpression();
            return treeBuilder.MethodCall("month", source);
        }
    }

    public class InstantToDateTimeUtcGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod<Instant>(x => x.ToDateTimeUtc()) };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(targetObject).AsExpression();

            return treeBuilder.MethodCall("nodafromutctickstoutcdatetime", source);
        }
    }

    public class InstantToUnixTimeMillisecondsGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod<Instant>(x => x.ToUnixTimeMilliseconds()) };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(targetObject).AsExpression();

            return treeBuilder.MethodCall("nodafromutctickstounixtimemilliseconds", source);
        }
    }

    public class InstantToUnixTimeSecondsGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod<Instant>(x => x.ToUnixTimeSeconds()) };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(targetObject).AsExpression();

            return treeBuilder.MethodCall("nodafromutctickstounixtimeseconds", source);
        }
    }

    public class InstantToUnixTimeTicksGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod<Instant>(x => x.ToUnixTimeTicks()) };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(targetObject).AsExpression();

            return treeBuilder.TransparentCast(treeBuilder.Subtract(source, treeBuilder.Constant(NodaConstants.UnixEpoch.ToDateTimeUtc().Ticks)), typeof(long));
            //return treeBuilder.MethodCall("nodafromutctickstounixtimeticks", source);
        }
    }

    public class InstantMinusGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod<Instant>(x => x.Minus(Instant.MinValue)) };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(targetObject).AsExpression();
            var arg1 = visitor.Visit(arguments[0]).AsExpression();

            return treeBuilder.MethodCall("nodafromtickstoduration", treeBuilder.Subtract(source, arg1));
            //return treeBuilder.MethodCall("nodafromutctickstounixtimeticks", source);
        }
    }

    public class InstantMaxGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod(() => Instant.Max(Instant.MinValue, Instant.MinValue)) };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(arguments[0]).AsExpression();
            var arg1 = visitor.Visit(arguments[1]).AsExpression();

            //return treeBuilder.MethodCall("nodafromtickstoduration", treeBuilder.Subtract(source, arg1));

            return treeBuilder.Case(new[] {
                    treeBuilder.When(
                        treeBuilder.GreaterThanOrEqual(source, arg1), source) }, arg1);
        }
    }

    public class InstantMinGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod(() => Instant.Min(Instant.MinValue, Instant.MinValue)) };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var source = visitor.Visit(arguments[0]).AsExpression();
            var arg1 = visitor.Visit(arguments[1]).AsExpression();

            //return treeBuilder.MethodCall("nodafromtickstoduration", treeBuilder.Subtract(source, arg1));

            return treeBuilder.Case(new[] {
                    treeBuilder.When(
                        treeBuilder.LessThanOrEqual(source, arg1), source) }, arg1);
        }
    }

    //public static class HqlTreeBuilderExtensions
    //{
    //    public static HqlExpression CastToNHibernateType(this HqlTreeBuilder treeBuilder, HqlExpression expression, IType type)
    //    {
    //        return new HqlTransparentITypeCast(treeBuilder.Into().Factory, expression, type);
            
    //    }
    //}
}