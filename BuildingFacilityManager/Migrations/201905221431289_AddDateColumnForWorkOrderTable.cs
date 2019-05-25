namespace BuildingFacilityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateColumnForWorkOrderTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkOrders", "Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkOrders", "Date");
        }
    }
}
