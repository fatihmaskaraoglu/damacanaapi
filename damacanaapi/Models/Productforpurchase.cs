using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace damacanaapi.Models
{
    public class ProductforPurchase
    {
       
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }

        [Required]
        public int Price { get; set; }
        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [Required]
        public int PurchaseId { get; set; }


    }
}