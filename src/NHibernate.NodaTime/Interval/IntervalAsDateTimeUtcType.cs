using NHibernate.Type;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.NodaTime
{
    public class IntervalAsDateTimeUtcType : AbstractIntervalAsInstantsType<InstantAsUtcDateTimeType>
    {
        
    }
}
