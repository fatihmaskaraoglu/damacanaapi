using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace damacanaapi.Models
{
    public class damacanaapiContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public damacanaapiContext() : base("name=damacanaapiContext")
        {
        }

        public System.Data.Entity.DbSet<damacanaapi.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<damacanaapi.Models.Purchase> Purchases { get; set; }

        public System.Data.Entity.DbSet<damacanaapi.Models.Cart> Carts { get; set; }

        public System.Data.Entity.DbSet<damacanaapi.Models.CartDTO> CartDTOes { get; set; }
    
    }
}
