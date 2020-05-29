using NHibernate.SqlTypes;
using NHibernate.Type;

namespace NHibernate.NodaTime
{
	public class EnhancedDateTimeOffsetType : DateTimeOffsetType
	{

		/// <summary>
		/// Default constructor.
		/// </summary>
		public EnhancedDateTimeOffsetType() : base()
		{
		}

		/// <summary>
		/// Constructor for specifying a datetimeoffset with a scale. Use <see cref="SqlTypeFactory.GetDateTimeOffset"/>.
		/// </summary>
		/// <param name="sqlType">The sql type to use for the type.</param>
		public EnhancedDateTimeOffsetType(DateTimeOffsetSqlType sqlType) : base(sqlType)
		{
		}
	}
}
