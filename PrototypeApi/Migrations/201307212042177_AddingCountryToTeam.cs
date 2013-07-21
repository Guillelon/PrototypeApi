namespace PrototypeApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCountryToTeam : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teams", "Country", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teams", "Country");
        }
    }
}
