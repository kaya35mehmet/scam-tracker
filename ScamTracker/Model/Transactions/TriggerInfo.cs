using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScamTracker.Model.Transactions
{
    public class TriggerInfo
    {
        public string Method { get; set; }
        public Parameter Parameter { get; set; }
        public string MethodId { get; set; }
        public string ContractAddress { get; set; }
        public int CallValue { get; set; }
    }
}
