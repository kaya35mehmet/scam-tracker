using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScamTracker.Model.Transactions
{
    public class ContractInfoDetails : BaseContractInfo
    {
        public bool IsToken { get; set; }
        public string Tag1 { get; set; }
        public string Tag1Url { get; set; }
        public bool Risk { get; set; }
    }
}
