namespace TestTaxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LocationOrders", "Street_Id", "dbo.Streets");
            DropIndex("dbo.LocationOrders", new[] { "Street_Id" });
            AddColumn("dbo.Orders", "PhoneNumber", c => c.String());
            AddColumn("dbo.Orders", "DateOrder", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "StreetFromID", c => c.Int());
            AddColumn("dbo.Orders", "StreetToID", c => c.Int());
            AddColumn("dbo.Orders", "StartValue", c => c.Int());
            AddColumn("dbo.Orders", "EndValue", c => c.Int());
            AddColumn("dbo.Orders", "Street_Id", c => c.Int());
            CreateIndex("dbo.Orders", "StreetFromID");
            CreateIndex("dbo.Orders", "StreetToID");
            CreateIndex("dbo.Orders", "Street_Id");
            AddForeignKey("dbo.Orders", "StreetFromID", "dbo.Streets", "Id");
            AddForeignKey("dbo.Orders", "StreetToID", "dbo.Streets", "Id");
            AddForeignKey("dbo.Orders", "Street_Id", "dbo.Streets", "Id");
            DropColumn("dbo.LocationOrders", "Street_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LocationOrders", "Street_Id", c => c.Int());
            DropForeignKey("dbo.Orders", "Street_Id", "dbo.Streets");
            DropForeignKey("dbo.Orders", "StreetToID", "dbo.Streets");
            DropForeignKey("dbo.Orders", "StreetFromID", "dbo.Streets");
            DropIndex("dbo.Orders", new[] { "Street_Id" });
            DropIndex("dbo.Orders", new[] { "StreetToID" });
            DropIndex("dbo.Orders", new[] { "StreetFromID" });
            DropColumn("dbo.Orders", "Street_Id");
            DropColumn("dbo.Orders", "EndValue");
            DropColumn("dbo.Orders", "StartValue");
            DropColumn("dbo.Orders", "StreetToID");
            DropColumn("dbo.Orders", "StreetFromID");
            DropColumn("dbo.Orders", "DateOrder");
            DropColumn("dbo.Orders", "PhoneNumber");
            CreateIndex("dbo.LocationOrders", "Street_Id");
            AddForeignKey("dbo.LocationOrders", "Street_Id", "dbo.Streets", "Id");
        }
    }
}
