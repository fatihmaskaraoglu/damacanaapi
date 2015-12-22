namespace damacanaapi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Purchases", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.Purchases", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Products", "Purchase_Id", "dbo.Purchases");
            DropIndex("dbo.Products", new[] { "Purchase_Id" });
            DropIndex("dbo.Purchases", new[] { "Cart_Id" });
            DropIndex("dbo.Purchases", new[] { "Product_Id" });
            DropPrimaryKey("dbo.Purchases");
            CreateTable(
                "dbo.ProductforPurchases",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        PurchaseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Purchases", t => t.PurchaseId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.PurchaseId);
            
            AlterColumn("dbo.Purchases", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Purchases", "Id");
            DropColumn("dbo.Products", "Purchase_Id");
            DropColumn("dbo.Purchases", "Cart_Id");
            DropColumn("dbo.Purchases", "Product_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Purchases", "Product_Id", c => c.Int());
            AddColumn("dbo.Purchases", "Cart_Id", c => c.Int());
            AddColumn("dbo.Products", "Purchase_Id", c => c.Int());
            DropForeignKey("dbo.ProductforPurchases", "PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.ProductforPurchases", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductforPurchases", new[] { "PurchaseId" });
            DropIndex("dbo.ProductforPurchases", new[] { "ProductId" });
            DropPrimaryKey("dbo.Purchases");
            AlterColumn("dbo.Purchases", "Id", c => c.Int(nullable: false, identity: true));
            DropTable("dbo.ProductforPurchases");
            AddPrimaryKey("dbo.Purchases", "Id");
            CreateIndex("dbo.Purchases", "Product_Id");
            CreateIndex("dbo.Purchases", "Cart_Id");
            CreateIndex("dbo.Products", "Purchase_Id");
            AddForeignKey("dbo.Products", "Purchase_Id", "dbo.Purchases", "Id");
            AddForeignKey("dbo.Purchases", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Purchases", "Cart_Id", "dbo.Carts", "Id");
        }
    }
}
