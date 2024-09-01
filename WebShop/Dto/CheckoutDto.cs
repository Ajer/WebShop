using WebShop.Models;

namespace WebShop.Dto
{
    public class CheckoutDto
    {

        public Cart Cart { get; set; }                // Cart.TotValue() total product-cost

        public int? TotQuantityInCart { get; set; }   // Total number of products in cart

        public double TotOrderCost { get; set; }    // With freight-cost


        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Zip { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public double FreightCost { get; set; }

        public string PaymentMethod { get; set; }
    }
}
