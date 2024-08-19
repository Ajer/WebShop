using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public string? Description { get; set; }

        public double? Price { get; set; }

        public double? DiscountPrice { get; set; }

        public bool IsDiscount { get; set; }

        public string? ImageUrl { get; set; }

        public int CategoryId { get; set; }     // FK

        public Category Category { get; set; }
    }
}
