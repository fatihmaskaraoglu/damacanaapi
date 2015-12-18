using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace damacanaapi.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
       // public ICollection<Product> Product { get; set; }

        public List <Product> Product { get; set; }
    }
}