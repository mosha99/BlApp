using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Database
{
    public class messags
    {
        [Key]
        public int id { get; set; }

        public string messag{ get; set; }
        public bool seen { set; get; }
        public DateTime sendDate { get; set; }

        [InverseProperty("sended")]
        public users sender { get; set; }

        [InverseProperty("input")]
        public users target { get; set; }
    }
}
