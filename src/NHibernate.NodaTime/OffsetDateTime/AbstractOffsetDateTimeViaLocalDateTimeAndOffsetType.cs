using NHibernate.UserTypes;
using NodaTime;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persists an <see cref="OffsetDateTime"/> as a <see cref="LocalDateTime"/> and a <see cref="Offset"/>, using <see cref="{TLocalDateTimeType}"/> and <see cref="OffsetAsInt32SecondsType"/>
    /// </summary>
    /// <typeparam name="TLocalDateTimeType"></typeparam>
    public abstract class AbstractOffsetDateTimeViaLocalDateTimeAndOffsetType<TLocalDateTimeType, TOffsetType> : AbstractTwoPropertyStructType<OffsetDateTime, LocalDateTime, Offset, CustomType<TLocalDateTimeType>, CustomType<TOffsetType>>
           where TLocalDateTimeType : IUserType
           where TOffsetType : IUserType

    {
        protected override string Property1Name => nameof(OffsetDateTime.LocalDateTime);

        protected override string Property2Name => nameof(OffsetDateTime.Offset);

        protected override LocalDateTime GetProperty1Value(OffsetDateTime value) => value.LocalDateTime;

        protected override Offset GetProperty2Value(OffsetDateTime value) => value.Offset;

        protected override OffsetDateTime Unwrap(LocalDateTime property1Value, Offset property2Value) => new OffsetDateTime(property1Value, property2Value);
    }
}