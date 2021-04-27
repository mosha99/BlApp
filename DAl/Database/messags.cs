using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database
{
    public class messags
    {
        public int id { get; set; }
        public users sender { get; set; }
        public users target { get; set; }
        public string messag{ get; set; }
        public bool seen { set; get; }
        public DateTime sendDate { get; set; }
    }
}
