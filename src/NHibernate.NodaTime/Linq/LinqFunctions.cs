using NHibernate.Linq.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.NodaTime.Linq
{
    public class LinqFunctions  : DefaultLinqToHqlGeneratorsRegistry
    {
        public LinqFunctions()
        {
            this.Merge(new OffsetDateDatePropertyGenerator());
            this.Merge(new OffsetDateTimeDatePropertyGenerator());
            this.Merge(new LocalDateYearPropertyGenerator());
            this.Merge(new LocalDateWithOffsetMethodGenerator());
        }
    }
}
