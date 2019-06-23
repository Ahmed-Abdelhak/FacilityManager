namespace BuildingFacilityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseRequestNoteColumnInWorkOrderTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkOrders", "PurchaseRequestNotes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkOrders", "PurchaseRequestNotes");
        }
    }
}
