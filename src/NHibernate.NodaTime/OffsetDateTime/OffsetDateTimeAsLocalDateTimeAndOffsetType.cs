using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    public class OffsetDateTimeAsLocalDateTimeAndOffsetType : AbstractTwoPropertyStructType<OffsetDateTime, LocalDateTime, Offset>
    {
        public OffsetDateTimeAsLocalDateTimeAndOffsetType() : base(new CustomType<LocalDateTimeAsDateTimeType>(), new CustomType<OffsetAsInt32SecondsType>())
        {
        }

        protected override string Property1Name => "LocalDateTime";

        protected override string Property2Name => "Offset";

        protected override LocalDateTime GetProperty1Value(OffsetDateTime value) => value.LocalDateTime;

        protected override Offset GetProperty2Value(OffsetDateTime value) => value.Offset;

        protected override OffsetDateTime Unwrap(LocalDateTime property1Value, Offset property2Value) => new OffsetDateTime(property1Value, property2Value);

    }
}
