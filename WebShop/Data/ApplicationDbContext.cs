using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebShop.Data.Migrations;
using WebShop.Models;
using WebShop.Dto;

namespace WebShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //List<Category> categories = new List<Category>()
            //{
            //    new Category()
            //    {
            //        Id = 1,
            //        Name = "Desktops",
            //        SwedishName = "Desktops"
            //    },
            //    new Category()
            //    {
            //        Id = 2,
            //        Name = "Laptops",
            //        SwedishName = "Laptops"
            //    },
            //    new Category()
            //    {
            //        Id = 3,
            //        Name = "TV",
            //        SwedishName = "TV"
            //    },
            //    new Category()
            //    {
            //        Id = 4,
            //        Name = "Earphones",
            //        SwedishName = "Hörlurar"
            //    },
            //    new Category()
            //    {
            //        Id = 5,
            //        Name = "Media",
            //        SwedishName = "Media"
            //    }
            //};

            //builder.Entity<Category>().HasData(categories);

            //List<Product> products = new List<Product>()
            //{
            //    new Product()
            //    {
            //        Id = 1,
            //        Name = "Dell Inspiron 3030 mt",
            //        CategoryId = 1,
            //        Price = 7700,
            //        DiscountPrice = 7700,
            //        IsDiscount = false,
            //        QuantityInStore = 30,
            //        Description = "Lorem Ipsum dolet...",
            //        ImageUrl = "desktop-inspiron-3030-mt.jpg"
            //    },
            //    new Product()
            //    {
            //        Id = 2,
            //        Name = "Dell Inspiron 3910",
            //        CategoryId = 1,
            //        Price = 8800,
            //        DiscountPrice = 8800,
            //        IsDiscount = false,
            //        QuantityInStore = 50,
            //        Description = "Lorem Ipsum dolet...",
            //        ImageUrl = "desktop-inspiron-3910.jpg"
            //    },
            //    new Product()
            //    {
            //        Id = 3,
            //        Name = "HP Pavilion Gaming TG01",
            //        CategoryId = 1,
            //        Price = 9900,
            //        DiscountPrice = 9900,
            //        IsDiscount = false,
            //        QuantityInStore = 20,
            //        Description = "Lorem Ipsum dolet...",
            //        ImageUrl = "HP_Pavilion_Gaming_Desktop_TG01.jpg"
            //    },
            //    new Product()
            //    {
            //        Id = 4,
            //        Name = "HP Pavilion TP01 3042",
            //        CategoryId = 1,
            //        Price = 6500,
            //        DiscountPrice = 6500,
            //        IsDiscount = false,
            //        QuantityInStore = 10,
            //        Description = "Lorem Ipsum dolet...",
            //        ImageUrl = "HP_Pavilion_TP01_3042.jpg"
            //    },
            //    new Product()
            //    {
            //        Id = 5,
            //        Name = "Dell Vostro 3520 core i5 16gb 512gb 15.6",
            //        CategoryId = 2,
            //        Price = 8300,
            //        DiscountPrice = 8300,
            //        IsDiscount = false,
            //        QuantityInStore = 5,
            //        Description = "Lorem Ipsum dolet...",
            //        ImageUrl = "dell-vostro-3520-core-i5-16gb-512gb-156.jpg"
            //    },
            //    new Product()
            //    {
            //        Id = 6,
            //        Name = "HP ep0875no 14",
            //        CategoryId = 2,
            //        Price = 5700,
            //        DiscountPrice = 5700,
            //        IsDiscount = false,
            //        QuantityInStore = 20,
            //        Description = "Lorem Ipsum dolet...",
            //        ImageUrl = "hp_14_ep0875no.jpg"
            //    },
            //    new Product()
            //    {
            //        Id = 7,
            //        Name = "HP 255 g8 ryzen 5 8gb 256gb 15.6",
            //        CategoryId = 2,
            //        Price = 4700,
            //        DiscountPrice = 4700,
            //        IsDiscount = false,
            //        QuantityInStore = 15,
            //        Description = "Lorem Ipsum dolet...",
            //        ImageUrl = "hp-255-g8-ryzen-5-8gb-256gb-156.jpg"
            //    },
            //    new Product()
            //    {
            //        Id = 8,
            //        Name = "Lenovo Thinkpad l13 g3 ryzen 3 8gb 256gb 13.3",
            //        CategoryId = 2,
            //        Price = 9900,
            //        DiscountPrice = 9900,
            //        IsDiscount = false,
            //        QuantityInStore = 20,
            //        Description = "Lorem Ipsum dolet...",
            //        ImageUrl = "lenovo-thinkpad-l13-g3-ryzen-3-8gb-256gb-133.jpg"
            //    },
            //    new Product()
            //    {
            //        Id = 9,
            //        Name = "Macbook Air Retina A2179 8gb 256gb",
            //        CategoryId = 2,
            //        Price = 12300,
            //        DiscountPrice = 12300,
            //        IsDiscount = false,
            //        QuantityInStore = 25,
            //        Description = "Lorem Ipsum dolet...",
            //        ImageUrl = "Macbook_Air_Retina_A2179_8gb_256gb.jpg"
            //    },
            //    new Product()
            //    {
            //        Id = 10,
            //        Name = "Msi Modern 14c7m ryzen 7 16gb 512gb 14",
            //        CategoryId = 2,
            //        Price = 9100,
            //        DiscountPrice = 9100,
            //        IsDiscount = false,
            //        QuantityInStore = 30,
            //        Description = "Lorem Ipsum dolet...",
            //        ImageUrl = "msi-modern-14-c7m-ryzen-7-16gb-512gb-14.jpg"
            //    },
            //    new Product()
            //    {
            //        Id = 11,
            //        Name = "Samsung Galaxy book3 pro core i7 16gb 512gb14",
            //        CategoryId = 2,
            //        Price = 6700,
            //        DiscountPrice = 6700,
            //        IsDiscount = false,
            //        QuantityInStore = 30,
            //        Description = "Lorem Ipsum dolet...",
            //        ImageUrl = "samsung-galaxy-book3-pro-core-i7-16gb-512gb-14.jpg"
            //    },
            //    new Product()
            //    {
            //        Id = 12,
            //        Name = "Samsung-tq55q70c-55-4k-qled-smart-tv-2023",
            //        CategoryId = 3,
            //        Price = 5500,
            //        DiscountPrice = 5500,
            //        IsDiscount = false,
            //        QuantityInStore = 30,
            //        Description = "Lorem Ipsum dolet...",
            //        ImageUrl = "samsung-tq55q70c-55-4k-qled-smart-tv-2023.jpg"
            //    },
            //    new Product()
            //    {
            //        Id = 13,
            //        Name = "Samsung-tu65cu7105k-1651-cm-65-4k-ultra-hd-smart-tv",
            //        CategoryId = 3,
            //        Price = 4900,
            //        DiscountPrice = 4900,
            //        IsDiscount = false,
            //        QuantityInStore = 30,
            //        Description = "Lorem Ipsum dolet...",
            //        ImageUrl = "samsung-tu65cu7105k-1651-cm-65-4k-ultra-hd-smart-tv.jpg"
            //    },
            //    new Product()
            //    {
            //        Id = 14,
            //        Name = "Apple  AirPods Pro 2nd gen med MagSafe Charging case (USB‑C)",
            //        CategoryId = 4,
            //        Price = 2400,
            //        DiscountPrice = 2400,
            //        IsDiscount = false,
            //        QuantityInStore = 30,
            //        Description = "Lorem Ipsum dolet...",
            //        ImageUrl = "Apple _AirPods_Pro_2nd_gen_ with MagSafe Charging_Case_(USB‑C).jpg"
            //    },
            //    new Product()
            //    {
            //        Id = 15,
            //        Name = "Iphone 6 head-phone rs130",
            //        CategoryId = 4,
            //        Price = 1700,
            //        DiscountPrice = 0,
            //        IsDiscount = false,
            //        QuantityInStore = 25,
            //        Description = "Lorem Ipsum dolet...",
            //        ImageUrl = "iphone-6-head-phone_rs130.jpg"
            //    },
            //    new Product()
            //    {
            //        Id = 16,
            //        Name = "J917",
            //        CategoryId = 4,
            //        Price = 1170,
            //        DiscountPrice = 1170,
            //        IsDiscount = false,
            //        QuantityInStore = 30,
            //        Description = "Lorem Ipsum dolet...",
            //        ImageUrl = "J917.jpg"
            //    },
            //    new Product()
            //    {
            //        Id = 17,
            //        Name = "Vinnfier Elite 5BT black",
            //        CategoryId = 4,
            //        Price = 1600,
            //        DiscountPrice = 1600,
            //        IsDiscount = false,
            //        QuantityInStore = 30,
            //        Description = "Lorem Ipsum dolet...",
            //        ImageUrl = "vinnfier_elite_5BT_black.jpg"
            //    },
            //    new Product()
            //    {
            //        Id = 18,
            //        Name = "Vinnfier Elite 5BT white",
            //        CategoryId = 4,
            //        Price = 1600,
            //        DiscountPrice = 1600,
            //        IsDiscount = false,
            //        QuantityInStore = 30,
            //        Description = "Lorem Ipsum dolet...",
            //        ImageUrl = "vinnfier_elite_5BT_white.jpg"
            //    },
            //    new Product()
            //    {
            //        Id = 19,
            //        Name = "HP Desktop 320K keybord",
            //        CategoryId = 5,
            //        Price = 199,
            //        DiscountPrice = 0,
            //        IsDiscount = false,
            //        QuantityInStore = 20,
            //        Description = "Kvalitets-tangentbord från HP",
            //        ImageUrl = "HP_Desktop_320K_keybord.jpg"
            //    },
            //    new Product()
            //    {
            //        Id = 20,
            //        Name = "Samsung hw b660 soundbar.jpg",
            //        CategoryId = 5,
            //        Price = 1300,
            //        DiscountPrice = 1300,
            //        IsDiscount = false,
            //        QuantityInStore = 30,
            //        Description = "Liten bärbar högtalare med imponerande ljudkvalitet både i bas och diskant",
            //        ImageUrl = "samsung-hw-b660-soundbar.jpg"
            //    },
            //    new Product()
            //    {
            //        Id = 21,
            //        Name = "Voxicon office mus m30wlb rf wireless",
            //        CategoryId = 5,
            //        Price = 399,
            //        DiscountPrice = 399,
            //        IsDiscount = false,
            //        QuantityInStore = 30,
            //        Description = "Sladdlös mus",
            //        ImageUrl = "voxicon-office-mus-m30wlb-rf-wireless.jpg"
            //    },
            //    new Product()
            //    {
            //        Id = 22,
            //        Name = "Zyxel Nebula fwa505 indoor 5g router",
            //        CategoryId = 5,
            //        Price = 2200,
            //        DiscountPrice = 2200,
            //        IsDiscount = false,
            //        QuantityInStore = 15,
            //        Description = "Fantastisk inomhus-router med den senaste säkerheten.Förberedd för 5G",
            //        ImageUrl = "zyxel-nebula-fwa505-indoor-5g-router.jpg"
            //    }
            //};

            //builder.Entity<Product>().HasData(products);


            List<OrderCartLine> orderCartLines = new List<OrderCartLine>
            {
                new OrderCartLine
                {
                    Id = 1,
                    OrderId = 1,
                    ProdId = 2,
                    Quantity = 1
                },
                new OrderCartLine
                {
                    Id = 2,
                    OrderId = 1,
                    ProdId = 15,
                    Quantity = 1
                }
            };
            builder.Entity<OrderCartLine>().HasData(orderCartLines);

            List<Customer> customers = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    FirstName = "Gunnar",
                    LastName = "Appelkvist",
                    Email = "gunnar@example.com",
                    Address = "Stadsborgaregatan 97",
                    Zip = "21192",
                    City = "Örebro",
                    Country = "Sweden"
                }
            };
            builder.Entity<Customer>().HasData(customers);

            List<Order> orders = new List<Order>
            {
                new Order
                {
                    Id = 1,
                    OrderDate = DateTime.Now,
                    TotOrderCost = 10549,
                    FreightCost = 49,
                    PaymentOption = "Invoice 30 days",
                    CustomerId = 1
                }
            };
            builder.Entity<Order>().HasData(orders);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<OrderCartLine> OrderCartLines { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
