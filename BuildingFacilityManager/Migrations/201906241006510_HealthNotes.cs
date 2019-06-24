namespace BuildingFacilityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HealthNotes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assets", "HealthNotes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assets", "HealthNotes");
        }
    }
}
