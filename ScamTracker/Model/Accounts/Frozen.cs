using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScamTracker.Model.Accounts
{
    public class Frozen
    {
        public long Total { get; set; }
        public List<object> Balances { get; set; }
    }
}
