using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string? SwedishName { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();    
    }
}
