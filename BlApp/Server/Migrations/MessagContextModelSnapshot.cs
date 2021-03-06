// <auto-generated />
using System;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlApp.Server.Migrations
{
    [DbContext(typeof(MessagContext))]
    partial class MessagContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Database.messags", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("messag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("seen")
                        .HasColumnType("bit");

                    b.Property<DateTime>("sendDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("senderid")
                        .HasColumnType("int");

                    b.Property<int?>("targetid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("senderid");

                    b.HasIndex("targetid");

                    b.ToTable("messag");
                });

            modelBuilder.Entity("Database.users", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Lastonline")
                        .HasColumnType("datetime2");

                    b.Property<string>("connectionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("online")
                        .HasColumnType("bit");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("start")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("Database.messags", b =>
                {
                    b.HasOne("Database.users", "sender")
                        .WithMany("sended")
                        .HasForeignKey("senderid");

                    b.HasOne("Database.users", "target")
                        .WithMany("input")
                        .HasForeignKey("targetid");

                    b.Navigation("sender");

                    b.Navigation("target");
                });

            modelBuilder.Entity("Database.users", b =>
                {
                    b.Navigation("input");

                    b.Navigation("sended");
                });
#pragma warning restore 612, 618
        }
    }
}
