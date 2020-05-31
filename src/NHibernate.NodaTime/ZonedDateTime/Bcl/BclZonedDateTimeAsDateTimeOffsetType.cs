#if NETFRAMEWORK

using NHibernate.NodaTime.Linq;
using NHibernate.Type;
using NodaTime;
using System;
using System.Collections.Generic;

namespace NHibernate.NodaTime
{
    public class BclZonedDateTimeAsDateTimeOffsetType : AbstractDateTimeOffsetBackedZonedDateTimeType<EnhancedDateTimeOffsetType, BclDateTimeZoneType>
    {
    
    }
}

#endif