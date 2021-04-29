namespace Weeklys.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedMoneyFlowDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MoneyFlow", "TaxesSum", c => c.Double(nullable: false));
            AlterColumn("dbo.MoneyFlow", "Profit", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MoneyFlow", "Profit", c => c.Double());
            AlterColumn("dbo.MoneyFlow", "TaxesSum", c => c.Double());
        }
    }
}
