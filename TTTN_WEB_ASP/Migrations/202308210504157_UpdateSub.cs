namespace TTTN_WEB_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSub : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Sub", "Name", c => c.String(nullable: false));
            DropColumn("dbo.tb_Sub", "CreatedBy");
            DropColumn("dbo.tb_Sub", "ModifiedDate");
            DropColumn("dbo.tb_Sub", "ModifiedBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Sub", "ModifiedBy", c => c.String());
            AddColumn("dbo.tb_Sub", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Sub", "CreatedBy", c => c.String());
            AlterColumn("dbo.tb_Sub", "Name", c => c.String());
        }
    }
}
