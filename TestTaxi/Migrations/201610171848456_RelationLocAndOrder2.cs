namespace TestTaxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationLocAndOrder2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "LocationOrder_Id", "dbo.LocationOrders");
            DropIndex("dbo.Orders", new[] { "LocationOrder_Id" });
            AddColumn("dbo.Discounts", "Name", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "LocationOrder_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "LocationOrder_Id", c => c.Int());
            DropColumn("dbo.Discounts", "Name");
            CreateIndex("dbo.Orders", "LocationOrder_Id");
            AddForeignKey("dbo.Orders", "LocationOrder_Id", "dbo.LocationOrders", "Id");
        }
    }
}
