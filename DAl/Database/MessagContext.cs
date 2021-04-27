
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Database
{
    public class MessagContext:DbContext
    {
            public MessagContext() : base("Messag")
            {

            }
            public DbSet<users> user { get; set; }
            public DbSet<messags> messag { get; set; }
        
    }
}
