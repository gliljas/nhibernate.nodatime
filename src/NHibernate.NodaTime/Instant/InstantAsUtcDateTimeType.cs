using NHibernate.NodaTime.Linq;
using NHibernate.Type;
using NodaTime;
using System;
using System.Collections.Generic;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persists an <see cref="Instant"/> as a <see cref="DateTime"/>, using <see cref="UtcDateTimeType"/>
    /// </summary>
    public class InstantAsUtcDateTimeType : AbstractInstantAsDateTimeType<UtcDateTimeType>
    {
        //public override IEnumerable<ISupportedQueryMember> SupportedQueryMembers
        //{
        //    get
        //    {
        //        //yield return SupportedQueryMethod.For<Instant, DateTimeOffset>(x => x.ToDateTimeOffset(), new ToDateTimeOffsetTransformer());
        //        yield return SupportedQueryMember.ForMethod<Instant, DateTime>(x => x.ToDateTimeUtc(), new LoadAsTransformer(NHibernateUtil.UtcDateTime));
        //        //yield return SupportedQueryMethod.For<Instant, double>(x => x.ToJulianDate(), new ToDateTimeUtcTransformer());
        //       // yield return SupportedQueryMethod.For<Instant, long>(x => x.ToUnixTimeMilliseconds(), new ToUnixTimeMillisecondsTransformer());
        //        //yield return SupportedQueryMethod.For<Instant, OffsetDateTime>(x => x.WithOffset(default), new DateTimeOffset);
        //        //yield return SupportedQueryMethod.For<Instant, OffsetDateTime>(x => x.WithOffsetSeconds(default), new GenericConversionTransformer<CustomType<OffsetDateAsDateTimeOffsetType>>());

        //    }
        //}
    }
}