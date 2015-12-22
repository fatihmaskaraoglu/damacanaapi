namespace damacanaapi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Purchases", "Cart_Id", "dbo.Carts");
            DropIndex("dbo.Carts", new[] { "Product_Id" });
            DropPrimaryKey("dbo.Carts");
            CreateTable(
                "dbo.Productincarts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalPrice = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        CartId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carts", t => t.CartId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.CartId);
            
            AddColumn("dbo.Carts", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Carts", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Carts", "Id");
            AddForeignKey("dbo.Purchases", "Cart_Id", "dbo.Carts", "Id");
            DropColumn("dbo.CartDTOes", "ProductID");
            DropColumn("dbo.Carts", "Product_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "Product_Id", c => c.Int());
            AddColumn("dbo.CartDTOes", "ProductID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Purchases", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.Productincarts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Productincarts", "CartId", "dbo.Carts");
            DropIndex("dbo.Productincarts", new[] { "CartId" });
            DropIndex("dbo.Productincarts", new[] { "ProductId" });
            DropPrimaryKey("dbo.Carts");
            AlterColumn("dbo.Carts", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Carts", "CreatedOn");
            DropTable("dbo.Productincarts");
            AddPrimaryKey("dbo.Carts", "Id");
            CreateIndex("dbo.Carts", "Product_Id");
            AddForeignKey("dbo.Purchases", "Cart_Id", "dbo.Carts", "Id");
            AddForeignKey("dbo.Carts", "Product_Id", "dbo.Products", "Id");
        }
    }
}
