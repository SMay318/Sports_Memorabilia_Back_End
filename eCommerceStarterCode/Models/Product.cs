using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eCommerceStarterCode.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }
        
        public decimal Price { get; set; }

        public string Category { get; set; }   
        
        public string Reviews { get; set; }

        public int Rating { get; set; }
    }
}
