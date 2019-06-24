namespace BuildingFacilityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPurchaseDateColumn : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.PurchaseOrders", new[] { "WorkOrderID" });
            AddColumn("dbo.PurchaseOrders", "PurchaseDateTime", c => c.DateTime());
            CreateIndex("dbo.PurchaseOrders", "WorkOrderId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.PurchaseOrders", new[] { "WorkOrderId" });
            DropColumn("dbo.PurchaseOrders", "PurchaseDateTime");
            CreateIndex("dbo.PurchaseOrders", "WorkOrderID");
        }
    }
}
