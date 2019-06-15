namespace BuildingFacilityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTasksTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InspectionTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        InspectorId = c.String(maxLength: 128),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        PeriodicInspection = c.Int(),
                        InspectionType = c.Int(),
                        StoreyInspectionId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.InspectorId)
                .ForeignKey("dbo.Storeys", t => t.StoreyInspectionId)
                .Index(t => t.InspectorId)
                .Index(t => t.StoreyInspectionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InspectionTasks", "StoreyInspectionId", "dbo.Storeys");
            DropForeignKey("dbo.InspectionTasks", "InspectorId", "dbo.AspNetUsers");
            DropIndex("dbo.InspectionTasks", new[] { "StoreyInspectionId" });
            DropIndex("dbo.InspectionTasks", new[] { "InspectorId" });
            DropTable("dbo.InspectionTasks");
        }
    }
}
