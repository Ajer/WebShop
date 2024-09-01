﻿namespace WebShop.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Email{ get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address{ get; set; }

        public string Zip{ get; set; }

        public string City{ get; set; }

        public string Country { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
