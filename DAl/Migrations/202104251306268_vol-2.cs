namespace DAl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vol2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.messags", "seen", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.messags", "seen");
        }
    }
}
