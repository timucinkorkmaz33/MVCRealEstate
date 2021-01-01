namespace SmartAdminMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Portfolio_Detail", "Floor_Front");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Portfolio_Detail", "Floor_Front", c => c.Int(nullable: false));
        }
    }
}
