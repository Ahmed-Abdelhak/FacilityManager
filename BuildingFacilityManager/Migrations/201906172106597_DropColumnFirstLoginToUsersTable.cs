namespace BuildingFacilityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropColumnFirstLoginToUsersTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "FirstLogin");
        }
        
        public override void Down()
        {
        }
    }
}
