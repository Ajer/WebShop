namespace WebShop.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate{ get; set; }

        public double TotOrderCost { get; set; }

        public double FreightCost { get; set; }

        public string PaymentOption { get; set; }

        public List<OrderCartLine> Lines { get; set; } = new List<OrderCartLine>();

        public int CustomerId{ get; set; }      // FK

        public Customer Customer { get; set; }  // Nav
    }
}
