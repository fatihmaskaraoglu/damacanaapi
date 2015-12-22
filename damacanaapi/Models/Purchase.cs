using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace damacanaapi.Models
{
    public class Purchase
    { 
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }

         [Required]
        public DateTime CreatedOn { get; set; }
            [Required]
        public decimal TotalPrice { get; set; }

     
    }
 
}