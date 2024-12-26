using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScamTracker.Model.Accounts
{
    public class Asset
    {
        public double NetPercentage { get; set; }
        public long NetLimit { get; set; }
        public long NetRemaining { get; set; }
        public long NetUsed { get; set; }
    }
}
