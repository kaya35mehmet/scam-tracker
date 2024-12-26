using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScamTracker.Model.Accounts
{
    public class Token
    {
        public string TokenId { get; set; }
        public string Balance { get; set; }
        public string TokenName { get; set; }
        public string TokenAbbr { get; set; }
        public int TokenDecimal { get; set; }
        public int TokenCanShow { get; set; }
        public string TokenType { get; set; }
        public string TokenLogo { get; set; }
        public bool Vip { get; set; }
        public double TokenPriceInTrx { get; set; }
        public double Amount { get; set; }
        public long NrOfTokenHolders { get; set; }
        public long TransferCount { get; set; }
        public string OwnerAddress { get; set; }
    }
}
