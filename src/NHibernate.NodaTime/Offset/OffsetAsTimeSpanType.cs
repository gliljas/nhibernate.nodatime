using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persist an <see cref="Offset"/> as its corresponding number of seconds, using <see cref="Int32Type"/>
    /// </summary>
    public class OffsetAsTimeSpanType : AbstractOffsetType<TimeSpan, TimeSpanType>
    {
        protected override Offset Unwrap(TimeSpan value) => Offset.FromTimeSpan(value);

        protected override TimeSpan Wrap(Offset value) => value.ToTimeSpan();
    }

}
