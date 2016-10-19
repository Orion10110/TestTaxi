namespace TestTaxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class my1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "DiscountID", c => c.Int());
            CreateIndex("dbo.Clients", "DiscountID");
            AddForeignKey("dbo.Clients", "DiscountID", "dbo.Discounts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "DiscountID", "dbo.Discounts");
            DropIndex("dbo.Clients", new[] { "DiscountID" });
            DropColumn("dbo.Clients", "DiscountID");
        }
    }
}
