using NHibernate.Cfg;
using NHibernate.Dialect.Function;
using NHibernate.NodaTime.Linq;
using NHibernate.Type;
using NodaTime;

namespace NHibernate.NodaTime
{
    public static class ConfigurationExtensions
    {
        public static Configuration AddNodaTime(this Configuration cfg) 
        {
            cfg.AddSqlFunction("tonodalocaldate", new SQLFunctionTemplate(new CustomType<LocalDateAsDateTimeType>(), "?1"));
            cfg.AddSqlFunction("tonodaoffsetdate", new SQLFunctionTemplate(new CustomType<OffsetDateAsDateTimeOffsetType>(), "?1"));
            cfg.AddSqlFunction("tonodalocaltime", new SQLFunctionTemplate(new CustomType<LocalTimeAsTimeType>(), "?1"));
            cfg.AddSqlFunction("tonodalocaldatetime", new SQLFunctionTemplate(new CustomType<LocalDateTimeAsDateTimeType>(), "?1"));
            cfg.AddSqlFunction("tonodainstant", new SQLFunctionTemplate(new CustomType<InstantAsUtcDateTimeType>(), "?1"));
            cfg.AddSqlFunction("nodafromdatetimeoffsettoinstant", new SQLFunctionTemplate(new CustomType<InstantAsDateTimeOffsetType>(), "?1"));
            cfg.AddSqlFunction("nodafromdatetimeoffsettolocaltime", new SQLFunctionTemplate(new CustomType<LocalDateAsDateTimeType>(), "?1"));
            cfg.AddSqlFunction("todatetime", new SQLFunctionTemplate(NHibernateUtil.Ticks, "?1"));
            cfg.AddSqlFunction("nodafromutctickstoutcdatetime", new SQLFunctionTemplate(NHibernateUtil.UtcDateTime, "DATEADD( NANOSECOND, ( ?1 % 10000000 ) * 100,DATEADD( SECOND, ( ?1 % 864000000000) / 10000000,DATEADD( DAY, ?1 / 864000000000, CAST('00010101' as datetime2))))"));
            cfg.AddSqlFunction("nodafromutctickstounixtimemilliseconds", new SQLFunctionTemplate(NHibernateUtil.Int64, $"CAST((?1 - {NodaConstants.UnixEpoch.ToDateTimeUtc().Ticks})/ 10000 as bigint)"));
            cfg.AddSqlFunction("nodafromutctickstounixtimeseconds", new SQLFunctionTemplate(NHibernateUtil.Int64, $"CAST((?1 - {NodaConstants.UnixEpoch.ToDateTimeUtc().Ticks}) / 10000000 as bigint)"));
            cfg.AddSqlFunction("nodafromutctickstounixtimeticks", new SQLFunctionTemplate(NHibernateUtil.Int64, $"?1 - {NodaConstants.UnixEpoch.ToDateTimeUtc().Ticks}"));
            
            cfg.AddSqlFunction("nodafromtickstoduration", new SQLFunctionTemplate(new CustomType<DurationAsTicksType>(), $"?1"));
            cfg.AddSqlFunction("nodafromnanosecondstoduration", new SQLFunctionTemplate(new CustomType<DurationAsInt64NanosecondsType>(), $"?1"));


            cfg.AddSqlFunction("switchoffset", new SQLFunctionTemplate(new EnhancedDateTimeOffsetNoMsType(), "switchoffset(?1,?2)"));
            cfg.AddSqlFunction("todatetimeoffsetnoms", new SQLFunctionTemplate(new EnhancedDateTimeOffsetNoMsType(), "?1"));
            cfg.AddSqlFunction("addhourstodatetime", new SQLFunctionTemplate(null, "dateadd(hour,?2,?1)"));
            cfg.AddSqlFunction("addminutestodatetime", new SQLFunctionTemplate(null, "dateadd(minute,?2,?1)"));
            cfg.AddSqlFunction("addsecondstodatetime", new SQLFunctionTemplate(null, "dateadd(second,?2,?1)"));
            cfg.AddSqlFunction("adddaystodatetime", new SQLFunctionTemplate(null, "dateadd(day,?2,?1)"));
            cfg.AddSqlFunction("addtickstodatetime", new SQLFunctionTemplate(null, "dateadd(ns,?2*100,?1)"));
            cfg.AddSqlFunction("addyearstodatetime", new SQLFunctionTemplate(null, "dateadd(year,?2,?1)"));
            cfg.AddSqlFunction("nodaisoweekday", new SQLFunctionTemplate(NHibernateUtil.Int32, "datediff(dd,0,?1) % 7 + 1"));
            cfg.AddSqlFunction("nodadayofyear", new SQLFunctionTemplate(NHibernateUtil.Int32, "datepart(dayofyear,?1)"));



            //cfg.AddSqlFunction("addsecondstodatetime", new SQLFunctionTemplate(null, $"?2*{},?1)"));
            cfg.AddSqlFunction("nodafromtickstoinstant", new SQLFunctionTemplate(new CustomType<InstantAsUtcTicksType>(), "?1"));
            cfg.AddSqlFunction("nodaticksfromdatetimeoffset", new SQLFunctionTemplate(NHibernateUtil.Int64, "DATEDIFF_BIG(mcs,'0001-01-01',?1) * 10"));
            cfg.AddSqlFunction("nodatickstotimespan", new SQLFunctionTemplate(NHibernateUtil.TimeSpan,"?1"));


            cfg.AddSqlFunction("withoffsetseconds", new SQLFunctionTemplate(new CompositeCustomType<OffsetDateTimeViaLocalDateTimeAsDateTimeNoMsAndOffsetAsInt32SecondsType>(), "?1,?2"));
    

            cfg.LinqQueryProvider<NodaTimeLinqQueryProvider>();
            cfg.LinqToHqlGeneratorsRegistry<LinqFunctions>();

            
            

            return cfg;
        }
    }
}
