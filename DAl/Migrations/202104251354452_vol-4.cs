namespace DAl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vol4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.users", "connectionId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.users", "connectionId");
        }
    }
}
