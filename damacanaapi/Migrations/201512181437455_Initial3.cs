namespace damacanaapi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Cart_Id", "dbo.Carts");
            DropIndex("dbo.Products", new[] { "Cart_Id" });
            CreateTable(
                "dbo.CartDTOes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Products", "Cart_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Cart_Id", c => c.Int());
            DropTable("dbo.CartDTOes");
            CreateIndex("dbo.Products", "Cart_Id");
            AddForeignKey("dbo.Products", "Cart_Id", "dbo.Carts", "Id");
        }
    }
}
