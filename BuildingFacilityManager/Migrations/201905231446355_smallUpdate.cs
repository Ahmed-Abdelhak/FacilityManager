namespace BuildingFacilityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class smallUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WorkOrders", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WorkOrders", "Description", c => c.String());
        }
    }
}
