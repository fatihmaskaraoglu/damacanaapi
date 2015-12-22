using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace damacanaapi.Models
{
  
    public class Productincart
    {
        public int Id { get; set; }

       
        [Required]
        public int TotalPrice { get; set; }
      


        
        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Required]
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }


    }
}