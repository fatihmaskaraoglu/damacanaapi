using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace damacanaapi.Models
{
    public class Cart
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }
        public Decimal TotalPrice { get; set; }

        public DateTime CreatedOn { get; set; }
       
        public virtual ICollection<Productincart> Productslist { get; set; }

     
    }
}