using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public int CategoryId { get; set; }     // FK

        public Category Category { get; set; }
    }
}
