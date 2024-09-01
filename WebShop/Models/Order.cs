using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate{ get; set; }

        public double TotOrderCost { get; set; }   // Including FreightCost

        public double FreightCost { get; set; }

        [MaxLength(100)]
        public string FreightOptionName { get; set; }   // I.e: DBSchenker Standard 2-3 dagar 19:-

        [MaxLength(100)]
        public string PaymentOption { get; set; }     //  I.e: Klarna Direktbetalning

        public List<OrderCartLine> Lines { get; set; } = new List<OrderCartLine>(); // Nav

        public int CustomerId{ get; set; }      // FK

        public Customer Customer { get; set; }  // Nav
    }
}
