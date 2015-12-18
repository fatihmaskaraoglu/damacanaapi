namespace damacanaapi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Productchange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Cart_Id1", c => c.Int());
            CreateIndex("dbo.Products", "Cart_Id1");
            AddForeignKey("dbo.Products", "Cart_Id1", "dbo.Carts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Cart_Id1", "dbo.Carts");
            DropIndex("dbo.Products", new[] { "Cart_Id1" });
            DropColumn("dbo.Products", "Cart_Id1");
        }
    }
}
