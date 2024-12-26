using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScamTracker.Model.Accounts
{
    public class Bandwidth
    {
        public long EnergyRemaining { get; set; }
        public long TotalEnergyLimit { get; set; }
        public long TotalEnergyWeight { get; set; }
        public long NetUsed { get; set; }
        public long StorageLimit { get; set; }
        public long StoragePercentage { get; set; }
        public Dictionary<string, Asset> Assets { get; set; }
        public double NetPercentage { get; set; }
        public long StorageUsed { get; set; }
        public long StorageRemaining { get; set; }
        public long FreeNetLimit { get; set; }
        public long EnergyUsed { get; set; }
        public long FreeNetRemaining { get; set; }
        public long NetLimit { get; set; }
        public long NetRemaining { get; set; }
        public long EnergyLimit { get; set; }
        public long FreeNetUsed { get; set; }
        public long TotalNetWeight { get; set; }
        public double FreeNetPercentage { get; set; }
        public double EnergyPercentage { get; set; }
        public long TotalNetLimit { get; set; }
    }
}
