using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database
{
    public class users
    {
        public int id { get; set; }
        public string firstname { set; get; }
        public string lastname { set; get; }
        public string email { set; get; }
        public string password { set; get; }
        public string connectionId { set; get; }
        public DateTime Lastonline { set; get; }
        public DateTime start { set; get; }
        public bool online { set; get; }
        public ICollection<messags> sended { get; set; }
        public ICollection<messags> input { get; set; }
    }
}
