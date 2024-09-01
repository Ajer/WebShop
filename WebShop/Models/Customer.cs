using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Email{ get; set; }


        [MaxLength(50)]
        public string FirstName { get; set; }


        [MaxLength(50)]
        public string LastName { get; set; }


        [MaxLength(150)]
        public string Address{ get; set; }


        [MaxLength(20)]
        public string Zip{ get; set; }


        [MaxLength(50)]
        public string City{ get; set; }


        [MaxLength(50)]
        public string Country { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();   //Nav
    }
}
