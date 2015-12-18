namespace damacanaapi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "Product_Id", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "Product_Id" });
            RenameColumn(table: "dbo.Carts", name: "Product_Id", newName: "ProductID");
            AlterColumn("dbo.Carts", "ProductID", c => c.Int(nullable: false));
            CreateIndex("dbo.Carts", "ProductID");
            AddForeignKey("dbo.Carts", "ProductID", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "ProductID", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "ProductID" });
            AlterColumn("dbo.Carts", "ProductID", c => c.Int());
            RenameColumn(table: "dbo.Carts", name: "ProductID", newName: "Product_Id");
            CreateIndex("dbo.Carts", "Product_Id");
            AddForeignKey("dbo.Carts", "Product_Id", "dbo.Products", "Id");
        }
    }
}
