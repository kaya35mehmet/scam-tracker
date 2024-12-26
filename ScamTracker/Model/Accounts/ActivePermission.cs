using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScamTracker.Model.Accounts
{
    public class ActivePermission
    {
        public string Operations { get; set; }
        public List<Key> Keys { get; set; }
        public int Threshold { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }
        public string PermissionName { get; set; }
    }
}
