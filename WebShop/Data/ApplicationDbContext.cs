using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebShop.Models;

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

            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "Desktop-inspiron-3030-mt",
                    CategoryId = 1,
                    Price = 7700,
                    DiscountPrice = 0,
                    IsDiscount = false,
                    Description = "Lorem Ipsum dolet...",
                    ImageUrl = "desktop-inspiron-3030-mt.jpg"
                },
                new Product()
                {
                    Id = 2,
                    Name = "Desktop-inspiron-3910",
                    CategoryId = 1,
                    Price = 8800,
                    DiscountPrice = 0,
                    IsDiscount = false,
                    Description = "Lorem Ipsum dolet...",
                    ImageUrl = "desktop-inspiron-3910.jpg"
                },
                new Product()
                {
                    Id = 3,
                    Name = "HP_Pavilion_Gaming_Desktop_TG01",
                    CategoryId = 1,
                    Price = 9900,
                    DiscountPrice = 0,
                    IsDiscount = false,
                    Description = "Lorem Ipsum dolet...",
                    ImageUrl = "HP_Pavilion_Gaming_Desktop_TG01.jpg"
                },
                new Product()
                {
                    Id = 4,
                    Name = "HP_Pavilion_TP01_3042",
                    CategoryId = 1,
                    Price = 6500,
                    DiscountPrice = 0,
                    IsDiscount = false,
                    Description = "Lorem Ipsum dolet...",
                    ImageUrl = "HP_Pavilion_TP01_3042.jpg"
                },
                new Product()
                {
                    Id = 5,
                    Name = "Dell-vostro-3520-core-i5-16gb-512gb-156",
                    CategoryId = 2,
                    Price = 8300,
                    DiscountPrice = 0,
                    IsDiscount = false,
                    Description = "Lorem Ipsum dolet...",
                    ImageUrl = "dell-vostro-3520-core-i5-16gb-512gb-156.jpg"
                },
                new Product()
                {
                    Id = 6,
                    Name = "HP_14_ep0875no",
                    CategoryId = 2,
                    Price = 5700,
                    DiscountPrice = 0,
                    IsDiscount = false,
                    Description = "Lorem Ipsum dolet...",
                    ImageUrl = "hp_14_ep0875no.jpg"
                },
                new Product()
                {
                    Id = 7,
                    Name = "HP-255-g8-ryzen-5-8gb-256gb-156",
                    CategoryId = 2,
                    Price = 4700,
                    DiscountPrice = 0,
                    IsDiscount = false,
                    Description = "Lorem Ipsum dolet...",
                    ImageUrl = "hp-255-g8-ryzen-5-8gb-256gb-156.jpg"
                },
                new Product()
                {
                    Id = 8,
                    Name = "Lenovo-thinkpad-l13-g3-ryzen-3-8gb-256gb-133",
                    CategoryId = 2,
                    Price = 9900,
                    DiscountPrice = 0,
                    IsDiscount = false,
                    Description = "Lorem Ipsum dolet...",
                    ImageUrl = "lenovo-thinkpad-l13-g3-ryzen-3-8gb-256gb-133.jpg"
                },
                new Product()
                {
                    Id = 9,
                    Name = "Macbook_Air_Retina_A2179_8gb_256gb",
                    CategoryId = 2,
                    Price = 12300,
                    DiscountPrice = 0,
                    IsDiscount = false,
                    Description = "Lorem Ipsum dolet...",
                    ImageUrl = "Macbook_Air_Retina_A2179_8gb_256gb.jpg"
                },
                new Product()
                {
                    Id = 10,
                    Name = "Msi-modern-14-c7m-ryzen-7-16gb-512gb-14",
                    CategoryId = 2,
                    Price = 9100,
                    DiscountPrice = 0,
                    IsDiscount = false,
                    Description = "Lorem Ipsum dolet...",
                    ImageUrl = "msi-modern-14-c7m-ryzen-7-16gb-512gb-14.jpg"
                },
                new Product()
                {
                    Id = 11,
                    Name = "Samsung-galaxy-book3-pro-core-i7-16gb-512gb-14",
                    CategoryId = 2,
                    Price = 6700,
                    DiscountPrice = 0,
                    IsDiscount = false,
                    Description = "Lorem Ipsum dolet...",
                    ImageUrl = "samsung-galaxy-book3-pro-core-i7-16gb-512gb-14.jpg"
                },
                new Product()
                {
                    Id = 12,
                    Name = "Samsung-tq55q70c-55-4k-qled-smart-tv-2023",
                    CategoryId = 3,
                    Price = 5500,
                    DiscountPrice = 0,
                    IsDiscount = false,
                    Description = "Lorem Ipsum dolet...",
                    ImageUrl = "samsung-tq55q70c-55-4k-qled-smart-tv-2023.jpg"
                },
                new Product()
                {
                    Id = 13,
                    Name = "Samsung-tu65cu7105k-1651-cm-65-4k-ultra-hd-smart-tv",
                    CategoryId = 3,
                    Price = 4900,
                    DiscountPrice = 0,
                    IsDiscount = false,
                    Description = "Lorem Ipsum dolet...",
                    ImageUrl = "samsung-tu65cu7105k-1651-cm-65-4k-ultra-hd-smart-tv.jpg"
                },
                new Product()
                {
                    Id = 14,
                    Name = "Apple _AirPods_Pro_2nd_gen_ with MagSafe Charging_Case_(USB‑C)",
                    CategoryId = 4,
                    Price = 2400,
                    DiscountPrice = 0,
                    IsDiscount = false,
                    Description = "Lorem Ipsum dolet...",
                    ImageUrl = "Apple _AirPods_Pro_2nd_gen_ with MagSafe Charging_Case_(USB‑C).jpg"
                },
                new Product()
                {
                    Id = 15,
                    Name = "Iphone-6-head-phone_rs130",
                    CategoryId = 4,
                    Price = 1700,
                    DiscountPrice = 0,
                    IsDiscount = false,
                    Description = "Lorem Ipsum dolet...",
                    ImageUrl = "iphone-6-head-phone_rs130.jpg"
                },
                new Product()
                {
                    Id = 16,
                    Name = "J917",
                    CategoryId = 4,
                    Price = 1170,
                    DiscountPrice = 0,
                    IsDiscount = false,
                    Description = "Lorem Ipsum dolet...",
                    ImageUrl = "J917.jpg"
                },
                new Product()
                {
                    Id = 17,
                    Name = "Vinnfier_elite_5BT_black",
                    CategoryId = 4,
                    Price = 1600,
                    DiscountPrice = 0,
                    IsDiscount = false,
                    Description = "Lorem Ipsum dolet...",
                    ImageUrl = "vinnfier_elite_5BT_black.jpg"
                },
                new Product()
                {
                    Id = 18,
                    Name = "Vinnfier_elite_5BT_white",
                    CategoryId = 4,
                    Price = 1600,
                    DiscountPrice = 0,
                    IsDiscount = false,
                    Description = "Lorem Ipsum dolet...",
                    ImageUrl = "vinnfier_elite_5BT_white.jpg"
                },
                new Product()
                {
                    Id = 19,
                    Name = "HP_Desktop_320K_keybord",
                    CategoryId = 5,
                    Price = 199,
                    DiscountPrice = 0,
                    IsDiscount = false,
                    Description = "Kvalitets-tangentbord från HP",
                    ImageUrl = "HP_Desktop_320K_keybord.jpg"
                },
                new Product()
                {
                    Id = 20,
                    Name = "Samsung-hw-b660-soundbar.jpg",
                    CategoryId = 5,
                    Price = 1300,
                    DiscountPrice = 0,
                    IsDiscount = false,
                    Description = "Liten bärbar högtalare med imponerande ljudkvalitet både i bas och diskant",
                    ImageUrl = "samsung-hw-b660-soundbar.jpg"
                },
                new Product()
                {
                    Id = 21,
                    Name = "Voxicon-office-mus-m30wlb-rf-wireless",
                    CategoryId = 5,
                    Price = 399,
                    DiscountPrice = 0,
                    IsDiscount = false,
                    Description = "Sladdlös mus",
                    ImageUrl = "voxicon-office-mus-m30wlb-rf-wireless.jpg"
                },
                new Product()
                {
                    Id = 22,
                    Name = "Zyxel-nebula-fwa505-indoor-5g-router",
                    CategoryId = 5,
                    Price = 2200,
                    DiscountPrice = 0,
                    IsDiscount = false,
                    Description = "Fantastisk inomhus-router med den senaste säkerheten.Förberedd för 5G",
                    ImageUrl = "zyxel-nebula-fwa505-indoor-5g-router.jpg"
                }
            };

            builder.Entity<Product>().HasData(products);
        }

        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }
    }
}
