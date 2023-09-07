namespace TTTN_WEB_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrderPay : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_OrderDetail", "Order_Id", "dbo.tb_Order");
            DropForeignKey("dbo.tb_OrderDetail", "Products_Id", "dbo.tb_Product");
            DropIndex("dbo.tb_OrderDetail", new[] { "Order_Id" });
            DropIndex("dbo.tb_OrderDetail", new[] { "Products_Id" });
            DropColumn("dbo.tb_OrderDetail", "OrderId");
            DropColumn("dbo.tb_OrderDetail", "ProductId");
            RenameColumn(table: "dbo.tb_OrderDetail", name: "Order_Id", newName: "OrderId");
            RenameColumn(table: "dbo.tb_OrderDetail", name: "Products_Id", newName: "ProductId");
            AlterColumn("dbo.tb_OrderDetail", "OrderId", c => c.Int(nullable: false));
            AlterColumn("dbo.tb_OrderDetail", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.tb_OrderDetail", "OrderId", c => c.Int(nullable: false));
            AlterColumn("dbo.tb_OrderDetail", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.tb_OrderDetail", "OrderId");
            CreateIndex("dbo.tb_OrderDetail", "ProductId");
            AddForeignKey("dbo.tb_OrderDetail", "OrderId", "dbo.tb_Order", "Id", cascadeDelete: true);
            AddForeignKey("dbo.tb_OrderDetail", "ProductId", "dbo.tb_Product", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_OrderDetail", "ProductId", "dbo.tb_Product");
            DropForeignKey("dbo.tb_OrderDetail", "OrderId", "dbo.tb_Order");
            DropIndex("dbo.tb_OrderDetail", new[] { "ProductId" });
            DropIndex("dbo.tb_OrderDetail", new[] { "OrderId" });
            AlterColumn("dbo.tb_OrderDetail", "ProductId", c => c.Int());
            AlterColumn("dbo.tb_OrderDetail", "OrderId", c => c.Int());
            AlterColumn("dbo.tb_OrderDetail", "ProductId", c => c.String());
            AlterColumn("dbo.tb_OrderDetail", "OrderId", c => c.String());
            RenameColumn(table: "dbo.tb_OrderDetail", name: "ProductId", newName: "Products_Id");
            RenameColumn(table: "dbo.tb_OrderDetail", name: "OrderId", newName: "Order_Id");
            AddColumn("dbo.tb_OrderDetail", "ProductId", c => c.String());
            AddColumn("dbo.tb_OrderDetail", "OrderId", c => c.String());
            CreateIndex("dbo.tb_OrderDetail", "Products_Id");
            CreateIndex("dbo.tb_OrderDetail", "Order_Id");
            AddForeignKey("dbo.tb_OrderDetail", "Products_Id", "dbo.tb_Product", "Id");
            AddForeignKey("dbo.tb_OrderDetail", "Order_Id", "dbo.tb_Order", "Id");
        }
    }
}
