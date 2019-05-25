namespace BuildingFacilityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPurchaseDateColumnToAssetsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assets", "PurchaseDate", c => c.String());
            AddColumn("dbo.Assets", "ExpectedLife", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assets", "ExpectedLife");
            DropColumn("dbo.Assets", "PurchaseDate");
        }
    }
}
