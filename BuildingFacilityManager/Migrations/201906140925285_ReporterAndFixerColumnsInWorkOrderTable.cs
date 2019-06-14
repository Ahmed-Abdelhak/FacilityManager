namespace BuildingFacilityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReporterAndFixerColumnsInWorkOrderTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkOrders", "ReporterId", c => c.String(maxLength: 128));
            AddColumn("dbo.WorkOrders", "FixerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.WorkOrders", "ReporterId");
            CreateIndex("dbo.WorkOrders", "FixerId");
            AddForeignKey("dbo.WorkOrders", "FixerId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.WorkOrders", "ReporterId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkOrders", "ReporterId", "dbo.AspNetUsers");
            DropForeignKey("dbo.WorkOrders", "FixerId", "dbo.AspNetUsers");
            DropIndex("dbo.WorkOrders", new[] { "FixerId" });
            DropIndex("dbo.WorkOrders", new[] { "ReporterId" });
            DropColumn("dbo.WorkOrders", "FixerId");
            DropColumn("dbo.WorkOrders", "ReporterId");
        }
    }
}
