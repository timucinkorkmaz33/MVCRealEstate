namespace SmartAdminMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Portfolio_General", "Type_State", c => c.Int(nullable: false));
            AddColumn("dbo.Portfolio_General", "Area_Brut", c => c.Int(nullable: false));
            AddColumn("dbo.Portfolio_General", "Area_Net", c => c.Int(nullable: false));
            AddColumn("dbo.Portfolio_ExtraDetail", "North", c => c.Boolean(nullable: false));
            AddColumn("dbo.Portfolio_ExtraDetail", "Sourth", c => c.Boolean(nullable: false));
            AddColumn("dbo.Portfolio_ExtraDetail", "East", c => c.Boolean(nullable: false));
            AddColumn("dbo.Portfolio_ExtraDetail", "West", c => c.Boolean(nullable: false));
            AddColumn("dbo.Portfolio_ExtraDetail", "Fiber", c => c.Boolean(nullable: false));
            AddColumn("dbo.Portfolio_ExtraDetail", "Satellite", c => c.Boolean(nullable: false));
            AddColumn("dbo.Portfolio_ExtraDetail", "Cable_tv", c => c.Boolean(nullable: false));
            AddColumn("dbo.Portfolio_ExtraDetail", "Adsl", c => c.Boolean(nullable: false));
            AddColumn("dbo.Portfolio_ExtraDetail", "Fax", c => c.Boolean(nullable: false));
            AddColumn("dbo.Portfolio_ExtraDetail", "Phone", c => c.Boolean(nullable: false));
            AddColumn("dbo.Portfolio_ExtraDetail", "WiFi", c => c.Boolean(nullable: false));
            AddColumn("dbo.Portfolio_ExtraDetail", "Elevator", c => c.Boolean(nullable: false));
            AddColumn("dbo.Portfolio_ExtraDetail", "Pool", c => c.Boolean(nullable: false));
            AddColumn("dbo.Portfolio_ExtraDetail", "Child_Park", c => c.Boolean(nullable: false));
            AddColumn("dbo.Portfolio_ExtraDetail", "Garage", c => c.Boolean(nullable: false));
            AddColumn("dbo.Portfolio_ExtraDetail", "Garden", c => c.Boolean(nullable: false));
            AddColumn("dbo.Portfolio_ExtraDetail", "Fire_Stairs", c => c.Boolean(nullable: false));
            AddColumn("dbo.Portfolio_ExtraDetail", "Securityman", c => c.Boolean(nullable: false));
            AddColumn("dbo.Portfolio_ExtraDetail", "Generator", c => c.Boolean(nullable: false));
            AddColumn("dbo.Portfolio_ExtraDetail", "Camera", c => c.Boolean(nullable: false));
            AddColumn("dbo.Portfolio_ExtraDetail", "Fire_Alarm", c => c.Boolean(nullable: false));
            AddColumn("dbo.Portfolio_ExtraDetail", "Thief_Alarm", c => c.Boolean(nullable: false));
            AddColumn("dbo.Portfolio_ExtraDetail", "Sea", c => c.Boolean(nullable: false));
            AddColumn("dbo.Portfolio_ExtraDetail", "Throat", c => c.Boolean(nullable: false));
            AddColumn("dbo.Portfolio_ExtraDetail", "Mountain", c => c.Boolean(nullable: false));
            AddColumn("dbo.Portfolio_ExtraDetail", "City", c => c.Boolean(nullable: false));
            AddColumn("dbo.Portfolio_ExtraDetail", "Nature", c => c.Boolean(nullable: false));
            AddColumn("dbo.Portfolio_ExtraDetail", "Lake", c => c.Boolean(nullable: false));
            DropColumn("dbo.Portfolio_General", "Area");
            DropColumn("dbo.Portfolio_ExtraDetail", "Communication_Detail");
            DropColumn("dbo.Portfolio_ExtraDetail", "Outdoor_Detail");
            DropColumn("dbo.Portfolio_ExtraDetail", "Security_Detail");
            DropColumn("dbo.Portfolio_ExtraDetail", "Front_Detail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Portfolio_ExtraDetail", "Front_Detail", c => c.Int());
            AddColumn("dbo.Portfolio_ExtraDetail", "Security_Detail", c => c.Int());
            AddColumn("dbo.Portfolio_ExtraDetail", "Outdoor_Detail", c => c.Int());
            AddColumn("dbo.Portfolio_ExtraDetail", "Communication_Detail", c => c.Int());
            AddColumn("dbo.Portfolio_General", "Area", c => c.Int(nullable: false));
            DropColumn("dbo.Portfolio_ExtraDetail", "Lake");
            DropColumn("dbo.Portfolio_ExtraDetail", "Nature");
            DropColumn("dbo.Portfolio_ExtraDetail", "City");
            DropColumn("dbo.Portfolio_ExtraDetail", "Mountain");
            DropColumn("dbo.Portfolio_ExtraDetail", "Throat");
            DropColumn("dbo.Portfolio_ExtraDetail", "Sea");
            DropColumn("dbo.Portfolio_ExtraDetail", "Thief_Alarm");
            DropColumn("dbo.Portfolio_ExtraDetail", "Fire_Alarm");
            DropColumn("dbo.Portfolio_ExtraDetail", "Camera");
            DropColumn("dbo.Portfolio_ExtraDetail", "Generator");
            DropColumn("dbo.Portfolio_ExtraDetail", "Securityman");
            DropColumn("dbo.Portfolio_ExtraDetail", "Fire_Stairs");
            DropColumn("dbo.Portfolio_ExtraDetail", "Garden");
            DropColumn("dbo.Portfolio_ExtraDetail", "Garage");
            DropColumn("dbo.Portfolio_ExtraDetail", "Child_Park");
            DropColumn("dbo.Portfolio_ExtraDetail", "Pool");
            DropColumn("dbo.Portfolio_ExtraDetail", "Elevator");
            DropColumn("dbo.Portfolio_ExtraDetail", "WiFi");
            DropColumn("dbo.Portfolio_ExtraDetail", "Phone");
            DropColumn("dbo.Portfolio_ExtraDetail", "Fax");
            DropColumn("dbo.Portfolio_ExtraDetail", "Adsl");
            DropColumn("dbo.Portfolio_ExtraDetail", "Cable_tv");
            DropColumn("dbo.Portfolio_ExtraDetail", "Satellite");
            DropColumn("dbo.Portfolio_ExtraDetail", "Fiber");
            DropColumn("dbo.Portfolio_ExtraDetail", "West");
            DropColumn("dbo.Portfolio_ExtraDetail", "East");
            DropColumn("dbo.Portfolio_ExtraDetail", "Sourth");
            DropColumn("dbo.Portfolio_ExtraDetail", "North");
            DropColumn("dbo.Portfolio_General", "Area_Net");
            DropColumn("dbo.Portfolio_General", "Area_Brut");
            DropColumn("dbo.Portfolio_General", "Type_State");
        }
    }
}
