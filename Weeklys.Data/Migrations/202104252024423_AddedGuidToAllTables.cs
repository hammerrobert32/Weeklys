namespace Weeklys.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGuidToAllTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MoneyFlow", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Paychecks", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Taxes", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Taxes", "OwnerId");
            DropColumn("dbo.Paychecks", "OwnerId");
            DropColumn("dbo.MoneyFlow", "OwnerId");
        }
    }
}
