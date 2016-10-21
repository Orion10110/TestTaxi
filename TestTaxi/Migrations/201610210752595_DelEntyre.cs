namespace TestTaxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DelEntyre : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LocationOrders", "Id", "dbo.Orders");
            DropForeignKey("dbo.LocationOrders", "StreetFromID", "dbo.Streets");
            DropForeignKey("dbo.LocationOrders", "StreetToID", "dbo.Streets");
            DropForeignKey("dbo.ValueTaximeters", "Id", "dbo.Orders");
            DropIndex("dbo.LocationOrders", new[] { "Id" });
            DropIndex("dbo.LocationOrders", new[] { "StreetFromID" });
            DropIndex("dbo.LocationOrders", new[] { "StreetToID" });
            DropIndex("dbo.ValueTaximeters", new[] { "Id" });
            DropTable("dbo.LocationOrders");
            DropTable("dbo.ValueTaximeters");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ValueTaximeters",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        StartValue = c.Int(),
                        EndValue = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LocationOrders",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        DateOrder = c.DateTime(nullable: false),
                        DateComeFrom = c.DateTime(nullable: false),
                        DateComeIn = c.DateTime(nullable: false),
                        AddressFrom = c.String(),
                        AddressTo = c.String(),
                        StreetFromID = c.Int(),
                        StreetToID = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.ValueTaximeters", "Id");
            CreateIndex("dbo.LocationOrders", "StreetToID");
            CreateIndex("dbo.LocationOrders", "StreetFromID");
            CreateIndex("dbo.LocationOrders", "Id");
            AddForeignKey("dbo.ValueTaximeters", "Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.LocationOrders", "StreetToID", "dbo.Streets", "Id");
            AddForeignKey("dbo.LocationOrders", "StreetFromID", "dbo.Streets", "Id");
            AddForeignKey("dbo.LocationOrders", "Id", "dbo.Orders", "Id");
        }
    }
}
