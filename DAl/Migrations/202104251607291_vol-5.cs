namespace DAl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vol5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.users", "start", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.users", "start");
        }
    }
}
