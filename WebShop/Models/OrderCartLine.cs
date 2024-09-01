namespace WebShop.Models
{
    public class OrderCartLine
    {
        public int Id { get; set; }

        public int OrderId { get; set; }   // FK

        public int ProdId{ get; set; }

        public int Quantity { get; set; }

        public Order Order { get; set; }  // Nav
    }
}
