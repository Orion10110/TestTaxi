namespace TestTaxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Bramd = c.String(),
                        Name = c.String(),
                        Type = c.String(),
                        Place = c.Int(),
                        GosNumbet = c.String(),
                        Stars = c.String(),
                        Active = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        status = c.Int(nullable: false),
                        ClientID = c.Int(),
                        DriverID = c.Int(),
                        CarID = c.Int(),
                        ApplicationUserID = c.String(maxLength: 128),
                        LocationOrder_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarID)
                .ForeignKey("dbo.Clients", t => t.ClientID)
                .ForeignKey("dbo.Drivers", t => t.DriverID)
                .ForeignKey("dbo.LocationOrders", t => t.LocationOrder_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .Index(t => t.ClientID)
                .Index(t => t.DriverID)
                .Index(t => t.CarID)
                .Index(t => t.ApplicationUserID)
                .Index(t => t.LocationOrder_Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        Patronymic = c.String(),
                        PhoneNumber = c.String(),
                        DiscountID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Discounts", t => t.DiscountID)
                .Index(t => t.DiscountID);
            
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Percent = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        Patronymic = c.String(),
                        PhoneNumber = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        DateOfEmployment = c.DateTime(nullable: false),
                        Category = c.Int(),
                        GosNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Streets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DistrictID = c.Int(),
                        District_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Districts", t => t.District_Id)
                .Index(t => t.District_Id);
            
            CreateTable(
                "dbo.LocationOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(),
                        DateOrder = c.DateTime(nullable: false),
                        DateComeFrom = c.DateTime(nullable: false),
                        DateComeIn = c.DateTime(nullable: false),
                        AddressFrom = c.String(),
                        AddressTo = c.String(),
                        StreetFromID = c.Int(),
                        StreetToID = c.Int(),
                        Street_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Streets", t => t.StreetFromID)
                .ForeignKey("dbo.Streets", t => t.StreetToID)
                .ForeignKey("dbo.Streets", t => t.Street_Id)
                .Index(t => t.StreetFromID)
                .Index(t => t.StreetToID)
                .Index(t => t.Street_Id);
            
            CreateTable(
                "dbo.ValueTaximeters",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        StartValue = c.Int(),
                        EndValue = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
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
            
            CreateTable(
                "dbo.DistrictDrivers",
                c => new
                    {
                        District_Id = c.String(nullable: false, maxLength: 128),
                        Driver_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.District_Id, t.Driver_Id })
                .ForeignKey("dbo.Districts", t => t.District_Id, cascadeDelete: true)
                .ForeignKey("dbo.Drivers", t => t.Driver_Id, cascadeDelete: true)
                .Index(t => t.District_Id)
                .Index(t => t.Driver_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "ApplicationUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ValueTaximeters", "Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "LocationOrder_Id", "dbo.LocationOrders");
            DropForeignKey("dbo.Orders", "DriverID", "dbo.Drivers");
            DropForeignKey("dbo.LocationOrders", "Street_Id", "dbo.Streets");
            DropForeignKey("dbo.LocationOrders", "StreetToID", "dbo.Streets");
            DropForeignKey("dbo.LocationOrders", "StreetFromID", "dbo.Streets");
            DropForeignKey("dbo.Streets", "District_Id", "dbo.Districts");
            DropForeignKey("dbo.DistrictDrivers", "Driver_Id", "dbo.Drivers");
            DropForeignKey("dbo.DistrictDrivers", "District_Id", "dbo.Districts");
            DropForeignKey("dbo.Orders", "ClientID", "dbo.Clients");
            DropForeignKey("dbo.Clients", "DiscountID", "dbo.Discounts");
            DropForeignKey("dbo.Orders", "CarID", "dbo.Cars");
            DropIndex("dbo.DistrictDrivers", new[] { "Driver_Id" });
            DropIndex("dbo.DistrictDrivers", new[] { "District_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ValueTaximeters", new[] { "Id" });
            DropIndex("dbo.LocationOrders", new[] { "Street_Id" });
            DropIndex("dbo.LocationOrders", new[] { "StreetToID" });
            DropIndex("dbo.LocationOrders", new[] { "StreetFromID" });
            DropIndex("dbo.Streets", new[] { "District_Id" });
            DropIndex("dbo.Clients", new[] { "DiscountID" });
            DropIndex("dbo.Orders", new[] { "LocationOrder_Id" });
            DropIndex("dbo.Orders", new[] { "ApplicationUserID" });
            DropIndex("dbo.Orders", new[] { "CarID" });
            DropIndex("dbo.Orders", new[] { "DriverID" });
            DropIndex("dbo.Orders", new[] { "ClientID" });
            DropTable("dbo.DistrictDrivers");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ValueTaximeters");
            DropTable("dbo.LocationOrders");
            DropTable("dbo.Streets");
            DropTable("dbo.Districts");
            DropTable("dbo.Drivers");
            DropTable("dbo.Discounts");
            DropTable("dbo.Clients");
            DropTable("dbo.Orders");
            DropTable("dbo.Cars");
        }
    }
}
