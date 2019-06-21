namespace BuildingFacilityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditSpaceColumnsNames : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Spaces", "PositionX", c => c.Single(nullable: false));
            AlterColumn("dbo.Spaces", "PositionY", c => c.Single(nullable: false));
            AlterColumn("dbo.Spaces", "Width", c => c.Single(nullable: false));
            AlterColumn("dbo.Spaces", "Length", c => c.Single(nullable: false));
            AlterColumn("dbo.Spaces", "WallsHeight", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Spaces", "WallsHeight", c => c.Single());
            AlterColumn("dbo.Spaces", "Length", c => c.Single());
            AlterColumn("dbo.Spaces", "Width", c => c.Single());
            AlterColumn("dbo.Spaces", "PositionY", c => c.Single());
            AlterColumn("dbo.Spaces", "PositionX", c => c.Single());
        }
    }
}
