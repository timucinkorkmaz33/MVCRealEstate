namespace SmartAdminMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Portfolio_Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pg_Id = c.Int(nullable: false),
                        Country = c.String(nullable: false, maxLength: 50),
                        City = c.String(nullable: false, maxLength: 50),
                        District = c.String(nullable: false, maxLength: 500),
                        Address = c.String(nullable: false),
                        Site_Name = c.String(nullable: false, maxLength: 500),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        Portfolio_General_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Portfolio_General", t => t.Portfolio_General_Id)
                .Index(t => t.Portfolio_General_Id);
            
            CreateTable(
                "dbo.Portfolio_General",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Header = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false),
                        Area = c.Int(nullable: false),
                        Subscription = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Price_Type = c.Int(nullable: false),
                        Comment = c.String(nullable: false),
                        Credit = c.Boolean(nullable: false),
                        Personal_Id = c.Int(),
                        Portfolio_Personal_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Portfolio_Personal", t => t.Portfolio_Personal_Id)
                .Index(t => t.Portfolio_Personal_Id);
            
            CreateTable(
                "dbo.Portfolio_Detail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pg_Id = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Heating = c.Int(nullable: false),
                        Building_Floor = c.Int(nullable: false),
                        Floor = c.Int(nullable: false),
                        Floor_Change = c.Boolean(),
                        Bathroom_Number = c.Int(nullable: false),
                        Balcony_Number = c.Int(nullable: false),
                        Building_Age = c.Int(nullable: false),
                        Room_Number = c.Int(nullable: false),
                        Saloon_Number = c.Int(nullable: false),
                        Floor_Front = c.Int(nullable: false),
                        Image = c.String(),
                        Portfolio_General_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Portfolio_General", t => t.Portfolio_General_Id)
                .Index(t => t.Portfolio_General_Id);
            
            CreateTable(
                "dbo.Portfolio_ExtraDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pg_Id = c.Int(nullable: false),
                        Communication_Detail = c.Int(),
                        Outdoor_Detail = c.Int(),
                        Security_Detail = c.Int(),
                        Front_Detail = c.Int(),
                        Portfolio_General_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Portfolio_General", t => t.Portfolio_General_Id)
                .Index(t => t.Portfolio_General_Id);
            
            CreateTable(
                "dbo.Portfolio_Personal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 50),
                        Phone1 = c.String(nullable: false, maxLength: 11),
                        Phone2 = c.String(nullable: false, maxLength: 11),
                        Address = c.String(nullable: false),
                        TC = c.String(nullable: false, maxLength: 11),
                        BirthPlace = c.String(nullable: false, maxLength: 50),
                        BirthDate = c.DateTime(nullable: false),
                        Driving_Licence = c.String(nullable: false, maxLength: 50),
                        Image = c.String(nullable: false),
                        Department = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Portfolio_General", "Portfolio_Personal_Id", "dbo.Portfolio_Personal");
            DropForeignKey("dbo.Portfolio_ExtraDetail", "Portfolio_General_Id", "dbo.Portfolio_General");
            DropForeignKey("dbo.Portfolio_Detail", "Portfolio_General_Id", "dbo.Portfolio_General");
            DropForeignKey("dbo.Portfolio_Address", "Portfolio_General_Id", "dbo.Portfolio_General");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Portfolio_ExtraDetail", new[] { "Portfolio_General_Id" });
            DropIndex("dbo.Portfolio_Detail", new[] { "Portfolio_General_Id" });
            DropIndex("dbo.Portfolio_General", new[] { "Portfolio_Personal_Id" });
            DropIndex("dbo.Portfolio_Address", new[] { "Portfolio_General_Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Portfolio_Personal");
            DropTable("dbo.Portfolio_ExtraDetail");
            DropTable("dbo.Portfolio_Detail");
            DropTable("dbo.Portfolio_General");
            DropTable("dbo.Portfolio_Address");
        }
    }
}
