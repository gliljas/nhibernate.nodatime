using NHibernate.Engine;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.NodaTime.Linq
{
    public class NodaTimeLinqQueryProvider : DefaultQueryProvider
    {
        public NodaTimeLinqQueryProvider(ISessionImplementor session) : base(session)
        {
        }

        
    }
}
