namespace Weeklys.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Paychecks", "WeeklyID", "dbo.Weekly");
            DropForeignKey("dbo.Taxes", "TaxesID", "dbo.Weekly");
            DropIndex("dbo.Paychecks", new[] { "WeeklyID" });
            CreateTable(
                "dbo.MoneyFlow",
                c => new
                    {
                        MoneyFlowID = c.Int(nullable: false, identity: true),
                        Revenue = c.Double(nullable: false),
                        Expenses = c.Double(nullable: false),
                        TaxesSum = c.Double(),
                        Profit = c.Double(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.MoneyFlowID);
            
            AddColumn("dbo.Paychecks", "MoneyFlowID", c => c.Int(nullable: false));
            CreateIndex("dbo.Paychecks", "MoneyFlowID");
            AddForeignKey("dbo.Paychecks", "MoneyFlowID", "dbo.MoneyFlow", "MoneyFlowID", cascadeDelete: true);
            AddForeignKey("dbo.Taxes", "TaxesID", "dbo.MoneyFlow", "MoneyFlowID");
            DropColumn("dbo.Paychecks", "WeeklyID");
            DropTable("dbo.Weekly");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Weekly",
                c => new
                    {
                        WeeklyID = c.Int(nullable: false, identity: true),
                        Revenue = c.Double(nullable: false),
                        Expenses = c.Double(nullable: false),
                        TaxesSum = c.Double(),
                        Profit = c.Double(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.WeeklyID);
            
            AddColumn("dbo.Paychecks", "WeeklyID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Taxes", "TaxesID", "dbo.MoneyFlow");
            DropForeignKey("dbo.Paychecks", "MoneyFlowID", "dbo.MoneyFlow");
            DropIndex("dbo.Paychecks", new[] { "MoneyFlowID" });
            DropColumn("dbo.Paychecks", "MoneyFlowID");
            DropTable("dbo.MoneyFlow");
            CreateIndex("dbo.Paychecks", "WeeklyID");
            AddForeignKey("dbo.Taxes", "TaxesID", "dbo.Weekly", "WeeklyID");
            AddForeignKey("dbo.Paychecks", "WeeklyID", "dbo.Weekly", "WeeklyID", cascadeDelete: true);
        }
    }
}
