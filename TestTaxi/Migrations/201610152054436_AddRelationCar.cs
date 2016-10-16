namespace TestTaxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationCar : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "CarID", "dbo.Cars");
            DropIndex("dbo.Orders", new[] { "CarID" });
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeCars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Cars", "BrandId", c => c.Int());
            AddColumn("dbo.Cars", "TypeCarId", c => c.Int());
            AddColumn("dbo.Drivers", "CarID", c => c.Int());
            CreateIndex("dbo.Cars", "BrandId");
            CreateIndex("dbo.Cars", "TypeCarId");
            CreateIndex("dbo.Drivers", "CarID");
            AddForeignKey("dbo.Cars", "BrandId", "dbo.Brands", "Id");
            AddForeignKey("dbo.Drivers", "CarID", "dbo.Cars", "Id");
            AddForeignKey("dbo.Cars", "TypeCarId", "dbo.TypeCars", "Id");
            DropColumn("dbo.Cars", "Bramd");
            DropColumn("dbo.Cars", "Type");
            DropColumn("dbo.Orders", "CarID");
            DropColumn("dbo.Drivers", "GosNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drivers", "GosNumber", c => c.String());
            AddColumn("dbo.Orders", "CarID", c => c.Int());
            AddColumn("dbo.Cars", "Type", c => c.String());
            AddColumn("dbo.Cars", "Bramd", c => c.String());
            DropForeignKey("dbo.Cars", "TypeCarId", "dbo.TypeCars");
            DropForeignKey("dbo.Drivers", "CarID", "dbo.Cars");
            DropForeignKey("dbo.Cars", "BrandId", "dbo.Brands");
            DropIndex("dbo.Drivers", new[] { "CarID" });
            DropIndex("dbo.Cars", new[] { "TypeCarId" });
            DropIndex("dbo.Cars", new[] { "BrandId" });
            DropColumn("dbo.Drivers", "CarID");
            DropColumn("dbo.Cars", "TypeCarId");
            DropColumn("dbo.Cars", "BrandId");
            DropTable("dbo.TypeCars");
            DropTable("dbo.Brands");
            CreateIndex("dbo.Orders", "CarID");
            AddForeignKey("dbo.Orders", "CarID", "dbo.Cars", "Id");
        }
    }
}
