namespace BuildingFacilityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnWorkOrderTypeInWorkOrderTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkOrders", "WorkOrderType", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkOrders", "WorkOrderType");
        }
    }
}
