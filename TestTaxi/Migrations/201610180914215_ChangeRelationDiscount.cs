namespace TestTaxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRelationDiscount : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DistrictDrivers", "District_Id", "dbo.Districts");
            DropForeignKey("dbo.DistrictDrivers", "Driver_Id", "dbo.Drivers");
            DropIndex("dbo.DistrictDrivers", new[] { "District_Id" });
            DropIndex("dbo.DistrictDrivers", new[] { "Driver_Id" });
            AddColumn("dbo.Drivers", "DistricrID", c => c.Int());
            AddColumn("dbo.Drivers", "District_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Drivers", "District_Id");
            AddForeignKey("dbo.Drivers", "District_Id", "dbo.Districts", "Id");
            DropTable("dbo.DistrictDrivers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DistrictDrivers",
                c => new
                    {
                        District_Id = c.String(nullable: false, maxLength: 128),
                        Driver_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.District_Id, t.Driver_Id });
            
            DropForeignKey("dbo.Drivers", "District_Id", "dbo.Districts");
            DropIndex("dbo.Drivers", new[] { "District_Id" });
            DropColumn("dbo.Drivers", "District_Id");
            DropColumn("dbo.Drivers", "DistricrID");
            CreateIndex("dbo.DistrictDrivers", "Driver_Id");
            CreateIndex("dbo.DistrictDrivers", "District_Id");
            AddForeignKey("dbo.DistrictDrivers", "Driver_Id", "dbo.Drivers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DistrictDrivers", "District_Id", "dbo.Districts", "Id", cascadeDelete: true);
        }
    }
}
