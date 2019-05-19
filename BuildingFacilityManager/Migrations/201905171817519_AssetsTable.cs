namespace BuildingFacilityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssetsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(nullable: false),
                        AssetType = c.Int(nullable: false),
                        AssetStatus = c.Int(nullable: false),
                        SpaceId = c.Int(nullable: false),
                        Vendor = c.String(),
                        InstallationDate = c.DateTime(),
                        ManufacturedDate = c.DateTime(),
                        Price = c.Single(nullable: true),
                        Warranty = c.String(),
                        Asset_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Assets", t => t.Asset_Id)
                .ForeignKey("dbo.Spaces", t => t.SpaceId, cascadeDelete: true)
                .Index(t => t.SpaceId)
                .Index(t => t.Asset_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assets", "SpaceId", "dbo.Spaces");
            DropForeignKey("dbo.Assets", "Asset_Id", "dbo.Assets");
            DropIndex("dbo.Assets", new[] { "Asset_Id" });
            DropIndex("dbo.Assets", new[] { "SpaceId" });
            DropTable("dbo.Assets");
        }
    }
}
