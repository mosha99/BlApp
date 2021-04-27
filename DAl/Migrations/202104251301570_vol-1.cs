namespace DAl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vol1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.messags",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        messag = c.String(),
                        users_id = c.Int(),
                        users_id1 = c.Int(),
                        sender_id = c.Int(),
                        target_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.users", t => t.users_id)
                .ForeignKey("dbo.users", t => t.users_id1)
                .ForeignKey("dbo.users", t => t.sender_id)
                .ForeignKey("dbo.users", t => t.target_id)
                .Index(t => t.users_id)
                .Index(t => t.users_id1)
                .Index(t => t.sender_id)
                .Index(t => t.target_id);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        firstname = c.String(),
                        lastname = c.String(),
                        email = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.messags", "target_id", "dbo.users");
            DropForeignKey("dbo.messags", "sender_id", "dbo.users");
            DropForeignKey("dbo.messags", "users_id1", "dbo.users");
            DropForeignKey("dbo.messags", "users_id", "dbo.users");
            DropIndex("dbo.messags", new[] { "target_id" });
            DropIndex("dbo.messags", new[] { "sender_id" });
            DropIndex("dbo.messags", new[] { "users_id1" });
            DropIndex("dbo.messags", new[] { "users_id" });
            DropTable("dbo.users");
            DropTable("dbo.messags");
        }
    }
}
