namespace Weeklys.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LastMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Paychecks", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Taxes", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Taxes", "CreatedUtc");
            DropColumn("dbo.Paychecks", "CreatedUtc");
        }
    }
}
