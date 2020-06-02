using NHibernate.NodaTime.Linq;
using NHibernate.Type;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NHibernate.NodaTime
{
    public abstract class AbstractDateTimeZoneType : AbstractStructType<DateTimeZone, string>
    {
        private DateTimeZone? _nullValue = null;

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

        //public override IEnumerable<ISupportedQueryProperty<DateTimeZone>> SupportedQueryProperties => new[] {
        //    new SupportedQueryProperty<DateTimeZone>(x=>x.Id,new PropertyTransformer(""))
        //};

        protected override DateTimeZone Cast(object value)
        {
            if (value is string zoneId)
            {
                return DateTimeZoneProvider[zoneId];
            }
            return base.Cast(value);
        }

        public override Expression<Func<DateTimeZone, string>>[] ExpressionsExposingPersisted => new Expression<Func<DateTimeZone, string>>[]
        {
            x => x.Id ,
            x => x.ToString()
        };
    }
}