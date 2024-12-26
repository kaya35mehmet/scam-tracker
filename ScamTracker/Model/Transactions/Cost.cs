using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScamTracker.Model.Transactions
{
    public class Cost
    {
        public int NetFeeCost { get; set; }
        public long DateCreated { get; set; }
        public int Fee { get; set; }
        public int EnergyFeeCost { get; set; }
        public int NetUsage { get; set; }
        public int MultiSignFee { get; set; }
        public int NetFee { get; set; }
        public int EnergyPenaltyTotal { get; set; }
        public int EnergyUsage { get; set; }
        public int EnergyFee { get; set; }
        public int EnergyUsageTotal { get; set; }
        public int MemoFee { get; set; }
        public int OriginEnergyUsage { get; set; }
    }
}
