
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database
{
    public class MessagContext : DbContext
    {
        public MessagContext()
        {
        }
        public MessagContext(DbContextOptions<MessagContext> options) : base(options)

        {

        }

        public DbSet<users> user { get; set; }
        public DbSet<messags> messag { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=Messager;User ID=messager;Password=ms8492");
            //optionsBuilder.UseSqlServer(@"Data Source =.; Initial Catalog = Messager; Integrated Security = True; MultipleActiveResultSets = False; ");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<users>()
                .HasKey(x => x.id);

            modelBuilder.Entity<messags>()
                .HasKey(x => x.id);
            /*
            modelBuilder.Entity<MessageEnum>()
                .HasKey(x => new { x.MessageMetaId, x.EnumMetaId });
            modelBuilder.Entity<MessageEnum>()
                .HasOne(x => x.MessageMeta)
                .WithMany(m => m.EnumMetas)
                .HasForeignKey(x => x.MessageMetaId);
            modelBuilder.Entity<MessageEnum>()
                .HasOne(x => x.EnumMeta)
                .WithMany(e => e.MessageMetas)
                .HasForeignKey(x => x.EnumMetaId);*/
        }
    }
}
