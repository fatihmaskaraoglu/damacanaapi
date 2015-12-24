namespace damacanaapi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Productincarts", "ProductId", "dbo.Products");
            DropIndex("dbo.Productincarts", new[] { "ProductId" });
            RenameColumn(table: "dbo.Productincarts", name: "ProductId", newName: "Product_Id");
            AlterColumn("dbo.Productincarts", "Product_Id", c => c.Int());
            CreateIndex("dbo.Productincarts", "Product_Id");
            AddForeignKey("dbo.Productincarts", "Product_Id", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productincarts", "Product_Id", "dbo.Products");
            DropIndex("dbo.Productincarts", new[] { "Product_Id" });
            AlterColumn("dbo.Productincarts", "Product_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Productincarts", name: "Product_Id", newName: "ProductId");
            CreateIndex("dbo.Productincarts", "ProductId");
            AddForeignKey("dbo.Productincarts", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
