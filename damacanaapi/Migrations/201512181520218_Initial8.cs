namespace damacanaapi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "ProductID", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "ProductID" });
            RenameColumn(table: "dbo.Carts", name: "ProductID", newName: "Product_Id");
            AlterColumn("dbo.Carts", "Product_Id", c => c.Int());
            CreateIndex("dbo.Carts", "Product_Id");
            AddForeignKey("dbo.Carts", "Product_Id", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "Product_Id", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "Product_Id" });
            AlterColumn("dbo.Carts", "Product_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Carts", name: "Product_Id", newName: "ProductID");
            CreateIndex("dbo.Carts", "ProductID");
            AddForeignKey("dbo.Carts", "ProductID", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
