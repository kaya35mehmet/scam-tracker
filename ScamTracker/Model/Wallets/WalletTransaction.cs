using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using ScamTracker.Model.Wallets;

namespace ScamTracker.model.Wallets
{
    public class WalletTransaction
    {
        public Dictionary<string, bool> ContractMap { get; set; }
        public TokenInfo TokenInfo { get; set; }
        public int PageSize { get; set; }
        public int Code { get; set; }
        public List<TransactionData> Data { get; set; }
    }
}
