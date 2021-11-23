using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceStarterCode.Models
{
    public class Review
    {
        [Key, Column(Order = 1)]
        [ForeignKey("Product")]

        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Key]
        public int Id { get; set; } 

        public string Comment { get; set; }

        public int Rating { get; set; }

    }
}
