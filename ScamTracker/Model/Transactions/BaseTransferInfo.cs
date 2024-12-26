using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScamTracker.Model.Transactions
{
    public class BaseTransferInfo
    {
        public string Icon_Url { get; set; }
        public string Symbol { get; set; }
        public string Level { get; set; }
        public string To_Address { get; set; }
        public string Contract_Address { get; set; }
        public string Type { get; set; }
        public int Decimals { get; set; }
        public string Name { get; set; }
        public bool Vip { get; set; }
        public string TokenType { get; set; }
        public string From_Address { get; set; }
        public string Amount_Str { get; set; }
        public int Status { get; set; }
    }
}
