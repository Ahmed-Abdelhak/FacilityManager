namespace BuildingFacilityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAssets : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Assets", name: "Asset_Id", newName: "Fk_AssetId");
            RenameIndex(table: "dbo.Assets", name: "IX_Asset_Id", newName: "IX_Fk_AssetId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Assets", name: "IX_Fk_AssetId", newName: "IX_Asset_Id");
            RenameColumn(table: "dbo.Assets", name: "Fk_AssetId", newName: "Asset_Id");
        }
    }
}
