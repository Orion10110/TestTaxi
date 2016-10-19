namespace TestTaxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jk2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Discounts", "Name", c => c.String());
        }
        
        public override void Down()
        {
           
            AlterColumn("dbo.Discounts", "Name", c => c.Int(nullable: false));
        }
    }
}
