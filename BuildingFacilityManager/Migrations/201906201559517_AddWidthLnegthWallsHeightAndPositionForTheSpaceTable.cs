namespace BuildingFacilityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWidthLnegthWallsHeightAndPositionForTheSpaceTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Spaces", "PositionX", c => c.Single());
            AddColumn("dbo.Spaces", "PositionY", c => c.Single());
            AddColumn("dbo.Spaces", "Width", c => c.Single());
            AddColumn("dbo.Spaces", "Length", c => c.Single());
            AddColumn("dbo.Spaces", "WallsHeight", c => c.Single());
            AlterColumn("dbo.Storeys", "Width", c => c.Single(nullable: false));
            AlterColumn("dbo.Storeys", "Length", c => c.Single(nullable: false));
            AlterColumn("dbo.Storeys", "Level", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Storeys", "Level", c => c.Single());
            AlterColumn("dbo.Storeys", "Length", c => c.Single());
            AlterColumn("dbo.Storeys", "Width", c => c.Single());
            DropColumn("dbo.Spaces", "WallsHeight");
            DropColumn("dbo.Spaces", "Length");
            DropColumn("dbo.Spaces", "Width");
            DropColumn("dbo.Spaces", "PositionY");
            DropColumn("dbo.Spaces", "PositionX");
        }
    }
}
