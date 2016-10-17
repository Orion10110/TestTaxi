namespace TestTaxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationLocAndOrder3 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.LocationOrders");
            AlterColumn("dbo.LocationOrders", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.LocationOrders", "Id");
            CreateIndex("dbo.LocationOrders", "Id");
            AddForeignKey("dbo.LocationOrders", "Id", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LocationOrders", "Id", "dbo.Orders");
            DropIndex("dbo.LocationOrders", new[] { "Id" });
            DropPrimaryKey("dbo.LocationOrders");
            AlterColumn("dbo.LocationOrders", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.LocationOrders", "Id");
        }
    }
}
