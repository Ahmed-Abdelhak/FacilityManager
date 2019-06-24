namespace BuildingFacilityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HealthColumnForAssets : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assets", "VendorContact", c => c.String());
            AddColumn("dbo.Assets", "HealthMeasurement", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assets", "HealthMeasurement");
            DropColumn("dbo.Assets", "VendorContact");
        }
    }
}
