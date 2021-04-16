namespace Weeklys.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Paychecks",
                c => new
                    {
                        PaychecksID = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        AmountPaid = c.Double(nullable: false),
                        WeeklyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaychecksID)
                .ForeignKey("dbo.Weekly", t => t.WeeklyID, cascadeDelete: true)
                .Index(t => t.WeeklyID);
            
            CreateTable(
                "dbo.Taxes",
                c => new
                    {
                        TaxesID = c.Int(nullable: false),
                        State = c.Double(nullable: false),
                        Federal = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.TaxesID)
                .ForeignKey("dbo.Weekly", t => t.TaxesID)
                .Index(t => t.TaxesID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Taxes", "TaxesID", "dbo.Weekly");
            DropForeignKey("dbo.Paychecks", "WeeklyID", "dbo.Weekly");
            DropIndex("dbo.Taxes", new[] { "TaxesID" });
            DropIndex("dbo.Paychecks", new[] { "WeeklyID" });
            DropTable("dbo.Taxes");
            DropTable("dbo.Paychecks");
        }
    }
}
