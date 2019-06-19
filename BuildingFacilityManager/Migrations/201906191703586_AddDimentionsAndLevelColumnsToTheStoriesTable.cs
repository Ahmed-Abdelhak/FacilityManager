namespace BuildingFacilityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDimentionsAndLevelColumnsToTheStoriesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Storeys", "Width", c => c.Single());
            AddColumn("dbo.Storeys", "Length", c => c.Single());
            AddColumn("dbo.Storeys", "Level", c => c.Single());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Storeys", "Level");
            DropColumn("dbo.Storeys", "Length");
            DropColumn("dbo.Storeys", "Width");
        }
    }
}
