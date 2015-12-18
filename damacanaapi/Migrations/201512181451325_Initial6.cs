namespace damacanaapi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CartDTOes", "TotalPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CartDTOes", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
