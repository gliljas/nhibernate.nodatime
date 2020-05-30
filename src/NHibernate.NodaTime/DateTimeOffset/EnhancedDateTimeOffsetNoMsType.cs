using NHibernate.Engine;
using NHibernate.SqlTypes;
using System;
using System.Data.Common;

namespace NHibernate.NodaTime
{
    internal class EnhancedDateTimeOffsetNoMsType : EnhancedDateTimeOffsetType
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public EnhancedDateTimeOffsetNoMsType() : base(SqlTypeFactory.GetDateTimeOffset(0))
        {
        }

        /// <summary>
        /// Constructor for specifying a datetimeoffset with a scale. Use <see cref="SqlTypeFactory.GetDateTimeOffset"/>.
        /// </summary>
        /// <param name="sqlType">The sql type to use for the type.</param>
        public EnhancedDateTimeOffsetNoMsType(DateTimeOffsetSqlType sqlType) : base(sqlType)
        {
        }

        public override object Get(DbDataReader rs, int index, ISessionImplementor session)
        {
            return AdjustDateTimeOffset((DateTimeOffset)base.Get(rs, index, session));
        }

        public override void Set(DbCommand st, object value, int index, ISessionImplementor session)
        {
            base.Set(st, AdjustDateTimeOffset((DateTimeOffset)value), index, session);
        }

        protected DateTimeOffset AdjustDateTimeOffset(DateTimeOffset dateValue) => new DateTimeOffset(dateValue.Year, dateValue.Month, dateValue.Day, dateValue.Hour, dateValue.Minute, dateValue.Second, dateValue.Offset);

        public override bool IsEqual(object x, object y)
        {
            if (x == y)
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            var dateTimeOffset1 = (DateTimeOffset)x;
            var dateTimeOffset2 = (DateTimeOffset)y;

            if (dateTimeOffset1.Equals(dateTimeOffset2))
                return true;

            return (dateTimeOffset1.Equals(dateTimeOffset2) ||
                    dateTimeOffset1.Year == dateTimeOffset2.Year &&
                    dateTimeOffset1.Month == dateTimeOffset2.Month &&
                    dateTimeOffset1.Day == dateTimeOffset2.Day &&
                    dateTimeOffset1.Hour == dateTimeOffset2.Hour &&
                    dateTimeOffset1.Minute == dateTimeOffset2.Minute &&
                    dateTimeOffset1.Second == dateTimeOffset2.Second &&
                    (int)dateTimeOffset1.Offset.TotalMinutes == (int)dateTimeOffset2.Offset.TotalMinutes);
        }

        /// <inheritdoc />
        public override int GetHashCode(object x)
        {
            // Custom hash code implementation because DateTimeType is only accurate
            // up to seconds.
            var dateTimeOffset = (DateTimeOffset)x;
            var hashCode = 1;
            unchecked
            {
                hashCode = 31 * hashCode + dateTimeOffset.Second;
                hashCode = 31 * hashCode + dateTimeOffset.Minute;
                hashCode = 31 * hashCode + dateTimeOffset.Hour;
                hashCode = 31 * hashCode + dateTimeOffset.Day;
                hashCode = 31 * hashCode + dateTimeOffset.Month;
                hashCode = 31 * hashCode + dateTimeOffset.Year;
                hashCode = 31 * hashCode + (int)dateTimeOffset.Offset.TotalMinutes;
            }

            return hashCode;
        }
    }
}