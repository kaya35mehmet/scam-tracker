using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScamTracker.Model
{
    public abstract class BaseData
    {
        public int Status { get; set; }
        public string Hash { get; set; }
        public int Block { get; set; }
        public long Block_Timestamp { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Confirmed { get; set; }
    }

}
