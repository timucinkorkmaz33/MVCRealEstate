namespace SmartAdminMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Portfolio_General", "Credit", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Portfolio_General", "Credit", c => c.Boolean(nullable: false));
        }
    }
}
