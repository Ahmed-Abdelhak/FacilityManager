namespace BuildingFacilityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTasksTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InspectionTasks", "InspectionStatus", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InspectionTasks", "InspectionStatus");
        }
    }
}
