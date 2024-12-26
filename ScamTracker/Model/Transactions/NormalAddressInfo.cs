using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScamTracker.Model.Transactions
{
    public class NormalAddressInfo
    {
        public Dictionary<string, RiskInfo> Addresses { get; set; }
    }
}
