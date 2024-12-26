using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScamTracker.Model.Accounts
{
    public class Representative
    {
        public long LastWithDrawTime { get; set; }
        public long Allowance { get; set; }
        public bool Enabled { get; set; }
        public string Url { get; set; }
    }
}
