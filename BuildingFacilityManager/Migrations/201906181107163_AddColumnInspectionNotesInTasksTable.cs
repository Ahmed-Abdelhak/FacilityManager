namespace BuildingFacilityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnInspectionNotesInTasksTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InspectionTasks", "InspectionNotes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InspectionTasks", "InspectionNotes");
        }
    }
}
