using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceStarterCode.Models
{
    public class ShoppingCart
    {
        [Key, Column(Order = 1)]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Key, Column(Order = 2)]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        public int Quantity { get; set; }

    }
}



