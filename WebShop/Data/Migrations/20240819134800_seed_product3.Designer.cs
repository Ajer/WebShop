﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebShop.Data;

#nullable disable

namespace WebShop.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240819134800_seed_product3")]
    partial class seed_product3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("WebShop.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SwedishName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("WebShop.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("DiscountPrice")
                        .HasColumnType("float");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDiscount")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("QuantityInStore")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Lorem Ipsum dolet...",
                            DiscountPrice = 7700.0,
                            ImageUrl = "desktop-inspiron-3030-mt.jpg",
                            IsDiscount = false,
                            Name = "Dell Inspiron 3030 mt",
                            Price = 7700.0,
                            QuantityInStore = 30
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "Lorem Ipsum dolet...",
                            DiscountPrice = 8800.0,
                            ImageUrl = "desktop-inspiron-3910.jpg",
                            IsDiscount = false,
                            Name = "Dell Inspiron 3910",
                            Price = 8800.0,
                            QuantityInStore = 50
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "Lorem Ipsum dolet...",
                            DiscountPrice = 9900.0,
                            ImageUrl = "HP_Pavilion_Gaming_Desktop_TG01.jpg",
                            IsDiscount = false,
                            Name = "HP Pavilion Gaming TG01",
                            Price = 9900.0,
                            QuantityInStore = 20
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Description = "Lorem Ipsum dolet...",
                            DiscountPrice = 6500.0,
                            ImageUrl = "HP_Pavilion_TP01_3042.jpg",
                            IsDiscount = false,
                            Name = "HP Pavilion TP01 3042",
                            Price = 6500.0,
                            QuantityInStore = 10
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Description = "Lorem Ipsum dolet...",
                            DiscountPrice = 8300.0,
                            ImageUrl = "dell-vostro-3520-core-i5-16gb-512gb-156.jpg",
                            IsDiscount = false,
                            Name = "Dell Vostro 3520 core i5 16gb 512gb 15.6",
                            Price = 8300.0,
                            QuantityInStore = 5
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Description = "Lorem Ipsum dolet...",
                            DiscountPrice = 5700.0,
                            ImageUrl = "hp_14_ep0875no.jpg",
                            IsDiscount = false,
                            Name = "HP ep0875no 14",
                            Price = 5700.0,
                            QuantityInStore = 20
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            Description = "Lorem Ipsum dolet...",
                            DiscountPrice = 4700.0,
                            ImageUrl = "hp-255-g8-ryzen-5-8gb-256gb-156.jpg",
                            IsDiscount = false,
                            Name = "HP 255 g8 ryzen 5 8gb 256gb 15.6",
                            Price = 4700.0,
                            QuantityInStore = 15
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 2,
                            Description = "Lorem Ipsum dolet...",
                            DiscountPrice = 9900.0,
                            ImageUrl = "lenovo-thinkpad-l13-g3-ryzen-3-8gb-256gb-133.jpg",
                            IsDiscount = false,
                            Name = "Lenovo Thinkpad l13 g3 ryzen 3 8gb 256gb 13.3",
                            Price = 9900.0,
                            QuantityInStore = 20
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 2,
                            Description = "Lorem Ipsum dolet...",
                            DiscountPrice = 12300.0,
                            ImageUrl = "Macbook_Air_Retina_A2179_8gb_256gb.jpg",
                            IsDiscount = false,
                            Name = "Macbook Air Retina A2179 8gb 256gb",
                            Price = 12300.0,
                            QuantityInStore = 25
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 2,
                            Description = "Lorem Ipsum dolet...",
                            DiscountPrice = 9100.0,
                            ImageUrl = "msi-modern-14-c7m-ryzen-7-16gb-512gb-14.jpg",
                            IsDiscount = false,
                            Name = "Msi Modern 14c7m ryzen 7 16gb 512gb 14",
                            Price = 9100.0,
                            QuantityInStore = 30
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 2,
                            Description = "Lorem Ipsum dolet...",
                            DiscountPrice = 6700.0,
                            ImageUrl = "samsung-galaxy-book3-pro-core-i7-16gb-512gb-14.jpg",
                            IsDiscount = false,
                            Name = "Samsung Galaxy book3 pro core i7 16gb 512gb14",
                            Price = 6700.0,
                            QuantityInStore = 30
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 3,
                            Description = "Lorem Ipsum dolet...",
                            DiscountPrice = 5500.0,
                            ImageUrl = "samsung-tq55q70c-55-4k-qled-smart-tv-2023.jpg",
                            IsDiscount = false,
                            Name = "Samsung-tq55q70c-55-4k-qled-smart-tv-2023",
                            Price = 5500.0,
                            QuantityInStore = 30
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 3,
                            Description = "Lorem Ipsum dolet...",
                            DiscountPrice = 4900.0,
                            ImageUrl = "samsung-tu65cu7105k-1651-cm-65-4k-ultra-hd-smart-tv.jpg",
                            IsDiscount = false,
                            Name = "Samsung-tu65cu7105k-1651-cm-65-4k-ultra-hd-smart-tv",
                            Price = 4900.0,
                            QuantityInStore = 30
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 4,
                            Description = "Lorem Ipsum dolet...",
                            DiscountPrice = 2400.0,
                            ImageUrl = "Apple _AirPods_Pro_2nd_gen_ with MagSafe Charging_Case_(USB‑C).jpg",
                            IsDiscount = false,
                            Name = "Apple  AirPods Pro 2nd gen med MagSafe Charging case (USB‑C)",
                            Price = 2400.0,
                            QuantityInStore = 30
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 4,
                            Description = "Lorem Ipsum dolet...",
                            DiscountPrice = 0.0,
                            ImageUrl = "iphone-6-head-phone_rs130.jpg",
                            IsDiscount = false,
                            Name = "Iphone 6 head-phone rs130",
                            Price = 1700.0,
                            QuantityInStore = 25
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 4,
                            Description = "Lorem Ipsum dolet...",
                            DiscountPrice = 1170.0,
                            ImageUrl = "J917.jpg",
                            IsDiscount = false,
                            Name = "J917",
                            Price = 1170.0,
                            QuantityInStore = 30
                        },
                        new
                        {
                            Id = 17,
                            CategoryId = 4,
                            Description = "Lorem Ipsum dolet...",
                            DiscountPrice = 1600.0,
                            ImageUrl = "vinnfier_elite_5BT_black.jpg",
                            IsDiscount = false,
                            Name = "Vinnfier Elite 5BT black",
                            Price = 1600.0,
                            QuantityInStore = 30
                        },
                        new
                        {
                            Id = 18,
                            CategoryId = 4,
                            Description = "Lorem Ipsum dolet...",
                            DiscountPrice = 1600.0,
                            ImageUrl = "vinnfier_elite_5BT_white.jpg",
                            IsDiscount = false,
                            Name = "Vinnfier Elite 5BT white",
                            Price = 1600.0,
                            QuantityInStore = 30
                        },
                        new
                        {
                            Id = 19,
                            CategoryId = 5,
                            Description = "Kvalitets-tangentbord från HP",
                            DiscountPrice = 0.0,
                            ImageUrl = "HP_Desktop_320K_keybord.jpg",
                            IsDiscount = false,
                            Name = "HP Desktop 320K keybord",
                            Price = 199.0,
                            QuantityInStore = 20
                        },
                        new
                        {
                            Id = 20,
                            CategoryId = 5,
                            Description = "Liten bärbar högtalare med imponerande ljudkvalitet både i bas och diskant",
                            DiscountPrice = 1300.0,
                            ImageUrl = "samsung-hw-b660-soundbar.jpg",
                            IsDiscount = false,
                            Name = "Samsung hw b660 soundbar.jpg",
                            Price = 1300.0,
                            QuantityInStore = 30
                        },
                        new
                        {
                            Id = 21,
                            CategoryId = 5,
                            Description = "Sladdlös mus",
                            DiscountPrice = 399.0,
                            ImageUrl = "voxicon-office-mus-m30wlb-rf-wireless.jpg",
                            IsDiscount = false,
                            Name = "Voxicon office mus m30wlb rf wireless",
                            Price = 399.0,
                            QuantityInStore = 30
                        },
                        new
                        {
                            Id = 22,
                            CategoryId = 5,
                            Description = "Fantastisk inomhus-router med den senaste säkerheten.Förberedd för 5G",
                            DiscountPrice = 2200.0,
                            ImageUrl = "zyxel-nebula-fwa505-indoor-5g-router.jpg",
                            IsDiscount = false,
                            Name = "Zyxel Nebula fwa505 indoor 5g router",
                            Price = 2200.0,
                            QuantityInStore = 15
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebShop.Models.Product", b =>
                {
                    b.HasOne("WebShop.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("WebShop.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
