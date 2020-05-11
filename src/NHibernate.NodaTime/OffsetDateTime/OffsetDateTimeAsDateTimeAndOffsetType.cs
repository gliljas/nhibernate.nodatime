using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    public class OffsetDateTimeAsDateTimeAndOffsetType : AbstractTwoPropertyStructType<OffsetDateTime, DateTime, Offset>
    {
        public OffsetDateTimeAsDateTimeAndOffsetType() : base(NHibernateUtil.DateTime, new CustomType<OffsetAsInt32SecondsType>())
        {
        }

        protected override string Property1Name => "DateTime";

        protected override string Property2Name => "Offset";

        protected override DateTime GetProperty1Value(OffsetDateTime value) => value.LocalDateTime.ToDateTimeUnspecified();

        protected override Offset GetProperty2Value(OffsetDateTime value) => value.Offset;

        protected override OffsetDateTime Unwrap(DateTime property1Value, Offset property2Value) => new OffsetDateTime(LocalDateTime.FromDateTime(property1Value), property2Value);

    }
}
