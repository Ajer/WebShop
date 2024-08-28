using WebShop.Models;

namespace WebShop.Dto
{
    public class CheckoutDto
    {
        public Cart Cart { get; set; }

        public int? TotQuantityInCart { get; set; }

        public double TotOrderCost { get; set; }    // With freight-cost
    }
}
