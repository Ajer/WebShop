﻿using WebShop.Models;

namespace WebShop.Dto
{
    public class CartDto
    {
        public Cart Cart { get; set; }

        public int? TotQuantityInCart { get; set; }
    }
}
