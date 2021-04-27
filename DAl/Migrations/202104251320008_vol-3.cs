namespace DAl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vol3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.messags", "sendDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.users", "Lastonline", c => c.DateTime(nullable: false));
            AddColumn("dbo.users", "online", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.users", "online");
            DropColumn("dbo.users", "Lastonline");
            DropColumn("dbo.messags", "sendDate");
        }
    }
}
