namespace TestTaxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelDisc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clients", "DiscountID", "dbo.Discounts");
            DropIndex("dbo.Clients", new[] { "DiscountID" });
           
        }
        
        public override void Down()
        {
         
            CreateIndex("dbo.Clients", "DiscountID");
            AddForeignKey("dbo.Clients", "DiscountID", "dbo.Discounts", "Id");
        }
    }
}
