using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScamTracker.Model.Wallets
{
    public class TokenInfo
    {
        public string TokenId { get; set; }
        public string TokenAbbr { get; set; }
        public string TokenName { get; set; }
        public int TokenDecimal { get; set; }
        public int TokenCanShow { get; set; }
        public string TokenType { get; set; }
        public string TokenLogo { get; set; }
        public string TokenLevel { get; set; }
        public string IssuerAddr { get; set; }
        public bool Vip { get; set; }
    }
}
