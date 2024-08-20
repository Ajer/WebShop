using System.ComponentModel.DataAnnotations;

namespace WebShop.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? CatName { get; set; }

        public string? SwedishCatName { get; set; }

        public string? Description { get; set; }

        public double? Price { get; set; }

        public double? DiscountPrice { get; set; }

        public bool IsDiscount { get; set; }

        public int? QuantityInStore { get; set; }

        public string? ImageUrl { get; set; }

    }
}
