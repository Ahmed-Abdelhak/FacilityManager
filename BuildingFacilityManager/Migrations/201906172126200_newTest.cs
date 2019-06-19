namespace BuildingFacilityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newTest : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "FirstLogin");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "FirstLogin", c => c.Int());
        }
    }
}
