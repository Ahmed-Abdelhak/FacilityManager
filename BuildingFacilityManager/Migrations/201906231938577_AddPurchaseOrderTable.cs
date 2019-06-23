namespace BuildingFacilityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPurchaseOrderTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchaseOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Cost = c.Single(nullable: false),
                        WorkOrderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkOrders", t => t.WorkOrderID, cascadeDelete: true)
                .Index(t => t.WorkOrderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseOrders", "WorkOrderID", "dbo.WorkOrders");
            DropIndex("dbo.PurchaseOrders", new[] { "WorkOrderID" });
            DropTable("dbo.PurchaseOrders");
        }
    }
}
