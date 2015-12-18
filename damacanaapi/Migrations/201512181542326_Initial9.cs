namespace damacanaapi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial9 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Carts", new[] { "Product_Id" });
            RenameColumn(table: "dbo.Products", name: "Product_Id", newName: "Cart_Id");
            CreateIndex("dbo.Products", "Cart_Id");
            DropColumn("dbo.CartDTOes", "ProductID");
            DropColumn("dbo.Carts", "Product_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "Product_Id", c => c.Int());
            AddColumn("dbo.CartDTOes", "ProductID", c => c.Int(nullable: false));
            DropIndex("dbo.Products", new[] { "Cart_Id" });
            RenameColumn(table: "dbo.Products", name: "Cart_Id", newName: "Product_Id");
            CreateIndex("dbo.Carts", "Product_Id");
        }
    }
}
