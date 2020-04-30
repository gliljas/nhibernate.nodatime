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
    public class InstantAsDateTimeUtcType : AbstractStructType<Instant,DateTime>
    {
        protected override IType ValueType => NHibernateUtil.DateTime;

        protected override SqlType SqlType => SqlTypeFactory.DateTime;

        protected override Instant Unwrap(DateTime value) => Instant.FromDateTimeUtc(DateTime.SpecifyKind(value, DateTimeKind.Utc));

        protected override DateTime Wrap(Instant value) => value.ToDateTimeUtc();
    }
}