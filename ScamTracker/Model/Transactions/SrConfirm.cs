using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScamTracker.Model.Transactions
{
    public class SrConfirm
    {
        public string Address { get; set; }
        public string Name { get; set; }
        public int Block { get; set; }
        public string Url { get; set; }
    }
}
