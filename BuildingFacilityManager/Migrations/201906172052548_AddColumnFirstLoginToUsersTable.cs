namespace BuildingFacilityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnFirstLoginToUsersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstLogin", c => c.Int(defaultValue: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "FirstLogin");
        }
    }
}
