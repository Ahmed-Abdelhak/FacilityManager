namespace BuildingFacilityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseDateOfAssetsIsDateTimeType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Assets", "PurchaseDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Assets", "PurchaseDate", c => c.String());
        }
    }
}
