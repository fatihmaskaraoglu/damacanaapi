namespace damacanaapi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtry : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Cart_Id1", "dbo.Carts");
            DropIndex("dbo.Products", new[] { "Cart_Id1" });
            DropColumn("dbo.Products", "Cart_Id1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Cart_Id1", c => c.Int());
            CreateIndex("dbo.Products", "Cart_Id1");
            AddForeignKey("dbo.Products", "Cart_Id1", "dbo.Carts", "Id");
        }
    }
}
