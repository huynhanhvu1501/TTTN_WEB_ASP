namespace TTTN_WEB_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedThongKe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ViewThongKes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ThoiGian = c.DateTime(nullable: false),
                        SoTruyCap = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.tb_Product", "ViewCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Product", "ViewCount");
            DropTable("dbo.ViewThongKes");
        }
    }
}
