using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScamTracker.Model.Wallets
{
    public class TransactionData : BaseData
    {
        public string Amount { get; set; }
        public string Approval_Amount { get; set; }
        public string Contract_Type { get; set; }
        public int ContractType { get; set; }
        public int Revert { get; set; }
        public string Contract_Ret { get; set; }
        public string Event_Type { get; set; }
        public string Issue_Address { get; set; }
        public int Decimals { get; set; }
        public string Token_Name { get; set; }
        public string Id { get; set; }
        public int Direction { get; set; }
        public decimal Balance { get; set; }
    }


}
