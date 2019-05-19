namespace BuildingFacilityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditColumnDescriptionWorkOrderTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WorkOrders", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WorkOrders", "Description", c => c.Int(nullable: false));
        }
    }
}
