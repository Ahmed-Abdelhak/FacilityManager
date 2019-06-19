namespace BuildingFacilityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnFirstLoginToUsersTableInMyDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstLogin", c => c.Int(defaultValueSql: "'1'"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "FirstLogin");
        }
    }
}
