using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Database
{
    public class users
    {
        [Key]
        public int id { get; set; }
        public string firstname { set; get; }
        public string lastname { set; get; }
        public string email { set; get; }
        public string password { set; get; }
        public string connectionId { set; get; }
        public DateTime Lastonline { set; get; }
        public DateTime start { set; get; }
        public bool online { set; get; }
        [InverseProperty("sender")]
        public ICollection<messags> sended { get; set; }
        [InverseProperty("target")]
        public ICollection<messags> input { get; set; }
    }
}
