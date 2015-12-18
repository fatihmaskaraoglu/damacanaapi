namespace damacanaapi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class try2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "Product_Id", c => c.Int());
            AddColumn("dbo.Purchases", "Cart_Id", c => c.Int());
            AddColumn("dbo.Purchases", "Product_Id", c => c.Int());
            CreateIndex("dbo.Carts", "Product_Id");
            CreateIndex("dbo.Purchases", "Cart_Id");
            CreateIndex("dbo.Purchases", "Product_Id");
            AddForeignKey("dbo.Carts", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Purchases", "Cart_Id", "dbo.Carts", "Id");
            AddForeignKey("dbo.Purchases", "Product_Id", "dbo.Products", "Id");
            DropColumn("dbo.Carts", "UserId");
            DropColumn("dbo.Purchases", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Purchases", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Carts", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Purchases", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Purchases", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.Carts", "Product_Id", "dbo.Products");
            DropIndex("dbo.Purchases", new[] { "Product_Id" });
            DropIndex("dbo.Purchases", new[] { "Cart_Id" });
            DropIndex("dbo.Carts", new[] { "Product_Id" });
            DropColumn("dbo.Purchases", "Product_Id");
            DropColumn("dbo.Purchases", "Cart_Id");
            DropColumn("dbo.Carts", "Product_Id");
        }
    }
}
