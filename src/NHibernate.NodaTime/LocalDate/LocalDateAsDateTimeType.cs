﻿using NHibernate.SqlTypes;
using NHibernate.Type;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.NodaTime
{
    public class LocalDateAsDateTimeType : AbstractStructType<LocalDate, DateTime, DateTimeType>
    {
        protected override LocalDate Unwrap(DateTime value) => LocalDate.FromDateTime(value);

        protected override DateTime Wrap(LocalDate value) => value.ToDateTimeUnspecified();

    }
}
