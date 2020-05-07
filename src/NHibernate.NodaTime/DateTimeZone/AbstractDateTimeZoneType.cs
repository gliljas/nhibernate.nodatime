using NHibernate.NodaTime.Linq;
using NHibernate.Type;
using NodaTime;
using System.Collections.Generic;

namespace NHibernate.NodaTime
{
    public abstract class AbstractDateTimeZoneType : AbstractStructType<DateTimeZone, string>
    {
        DateTimeZone? _nullValue = null;
        public AbstractDateTimeZoneType() : base(TypeFactory.GetStringType(30))
        {
            
        }
        protected abstract IDateTimeZoneProvider DateTimeZoneProvider { get; }

        protected override string Wrap(DateTimeZone value) => value.Id;

        protected override DateTimeZone Unwrap(string value) => DateTimeZoneProvider[value];

        protected override object? NullValue => _nullValue;

        public override void SetParameterValues(IDictionary<string, string> parameters)
        {
            if (parameters != null)
            {
                if (parameters.TryGetValue("ZoneWhenNull", out var zoneWhenNull))
                {
                    _nullValue = DateTimeZoneProvider[zoneWhenNull];
                }
                base.SetParameterValues(parameters);
            }
        }

        public override IEnumerable<SupportedQueryProperty<DateTimeZone>> SupportedQueryProperties => new[] { 
            new SupportedQueryProperty<DateTimeZone>(x=>x.Id,new PropertyTransformer(""))
        };
    }
}
