using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    public class OffsetDateAsDateTimeOffsetType : AbstractOffsetDateType<DateTimeOffset, DateTimeOffsetType>
    {
        protected override OffsetDate Unwrap(DateTimeOffset value) => OffsetDateTime.FromDateTimeOffset(value).ToOffsetDate();


        protected override DateTimeOffset Wrap(OffsetDate value) => value.At(LocalTime.MinValue).ToDateTimeOffset();

       
    }
}
