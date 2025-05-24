using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserPreferenceDTO
    {
        public int PreferenceID { get; set; }
        public int NotifyByEmail { get; set; }
        public int NotifyBySMS { get; set; }
        public int NotifyByPush { get; set; }
        public bool Digest { get; set; }
    }
}
