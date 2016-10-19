namespace TestTaxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Drivers", "District_Id", "dbo.Districts");
            DropForeignKey("dbo.Streets", "District_Id", "dbo.Districts");
            DropIndex("dbo.Drivers", new[] { "District_Id" });
            DropIndex("dbo.Streets", new[] { "District_Id" });
            DropColumn("dbo.Streets", "DistrictID");
            RenameColumn(table: "dbo.Streets", name: "District_Id", newName: "DistrictID");
            DropPrimaryKey("dbo.Districts");
            AlterColumn("dbo.Drivers", "District_Id", c => c.Int());
            AlterColumn("dbo.Districts", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Streets", "DistrictID", c => c.Int());
            AddPrimaryKey("dbo.Districts", "Id");
            CreateIndex("dbo.Drivers", "District_Id");
            CreateIndex("dbo.Streets", "DistrictID");
            AddForeignKey("dbo.Drivers", "District_Id", "dbo.Districts", "Id");
            AddForeignKey("dbo.Streets", "DistrictID", "dbo.Districts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Streets", "DistrictID", "dbo.Districts");
            DropForeignKey("dbo.Drivers", "District_Id", "dbo.Districts");
            DropIndex("dbo.Streets", new[] { "DistrictID" });
            DropIndex("dbo.Drivers", new[] { "District_Id" });
            DropPrimaryKey("dbo.Districts");
            AlterColumn("dbo.Streets", "DistrictID", c => c.String(maxLength: 128));
            AlterColumn("dbo.Districts", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Drivers", "District_Id", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Districts", "Id");
            RenameColumn(table: "dbo.Streets", name: "DistrictID", newName: "District_Id");
            AddColumn("dbo.Streets", "DistrictID", c => c.Int());
            CreateIndex("dbo.Streets", "District_Id");
            CreateIndex("dbo.Drivers", "District_Id");
            AddForeignKey("dbo.Streets", "District_Id", "dbo.Districts", "Id");
            AddForeignKey("dbo.Drivers", "District_Id", "dbo.Districts", "Id");
        }
    }
}
