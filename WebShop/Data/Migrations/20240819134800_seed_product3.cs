using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class seed_product3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "DiscountPrice", "ImageUrl", "IsDiscount", "Name", "Price", "QuantityInStore" },
                values: new object[,]
                {
                    { 1, 1, "Lorem Ipsum dolet...", 7700.0, "desktop-inspiron-3030-mt.jpg", false, "Dell Inspiron 3030 mt", 7700.0, 30 },
                    { 2, 1, "Lorem Ipsum dolet...", 8800.0, "desktop-inspiron-3910.jpg", false, "Dell Inspiron 3910", 8800.0, 50 },
                    { 3, 1, "Lorem Ipsum dolet...", 9900.0, "HP_Pavilion_Gaming_Desktop_TG01.jpg", false, "HP Pavilion Gaming TG01", 9900.0, 20 },
                    { 4, 1, "Lorem Ipsum dolet...", 6500.0, "HP_Pavilion_TP01_3042.jpg", false, "HP Pavilion TP01 3042", 6500.0, 10 },
                    { 5, 2, "Lorem Ipsum dolet...", 8300.0, "dell-vostro-3520-core-i5-16gb-512gb-156.jpg", false, "Dell Vostro 3520 core i5 16gb 512gb 15.6", 8300.0, 5 },
                    { 6, 2, "Lorem Ipsum dolet...", 5700.0, "hp_14_ep0875no.jpg", false, "HP ep0875no 14", 5700.0, 20 },
                    { 7, 2, "Lorem Ipsum dolet...", 4700.0, "hp-255-g8-ryzen-5-8gb-256gb-156.jpg", false, "HP 255 g8 ryzen 5 8gb 256gb 15.6", 4700.0, 15 },
                    { 8, 2, "Lorem Ipsum dolet...", 9900.0, "lenovo-thinkpad-l13-g3-ryzen-3-8gb-256gb-133.jpg", false, "Lenovo Thinkpad l13 g3 ryzen 3 8gb 256gb 13.3", 9900.0, 20 },
                    { 9, 2, "Lorem Ipsum dolet...", 12300.0, "Macbook_Air_Retina_A2179_8gb_256gb.jpg", false, "Macbook Air Retina A2179 8gb 256gb", 12300.0, 25 },
                    { 10, 2, "Lorem Ipsum dolet...", 9100.0, "msi-modern-14-c7m-ryzen-7-16gb-512gb-14.jpg", false, "Msi Modern 14c7m ryzen 7 16gb 512gb 14", 9100.0, 30 },
                    { 11, 2, "Lorem Ipsum dolet...", 6700.0, "samsung-galaxy-book3-pro-core-i7-16gb-512gb-14.jpg", false, "Samsung Galaxy book3 pro core i7 16gb 512gb14", 6700.0, 30 },
                    { 12, 3, "Lorem Ipsum dolet...", 5500.0, "samsung-tq55q70c-55-4k-qled-smart-tv-2023.jpg", false, "Samsung-tq55q70c-55-4k-qled-smart-tv-2023", 5500.0, 30 },
                    { 13, 3, "Lorem Ipsum dolet...", 4900.0, "samsung-tu65cu7105k-1651-cm-65-4k-ultra-hd-smart-tv.jpg", false, "Samsung-tu65cu7105k-1651-cm-65-4k-ultra-hd-smart-tv", 4900.0, 30 },
                    { 14, 4, "Lorem Ipsum dolet...", 2400.0, "Apple _AirPods_Pro_2nd_gen_ with MagSafe Charging_Case_(USB‑C).jpg", false, "Apple  AirPods Pro 2nd gen med MagSafe Charging case (USB‑C)", 2400.0, 30 },
                    { 15, 4, "Lorem Ipsum dolet...", 0.0, "iphone-6-head-phone_rs130.jpg", false, "Iphone 6 head-phone rs130", 1700.0, 25 },
                    { 16, 4, "Lorem Ipsum dolet...", 1170.0, "J917.jpg", false, "J917", 1170.0, 30 },
                    { 17, 4, "Lorem Ipsum dolet...", 1600.0, "vinnfier_elite_5BT_black.jpg", false, "Vinnfier Elite 5BT black", 1600.0, 30 },
                    { 18, 4, "Lorem Ipsum dolet...", 1600.0, "vinnfier_elite_5BT_white.jpg", false, "Vinnfier Elite 5BT white", 1600.0, 30 },
                    { 19, 5, "Kvalitets-tangentbord från HP", 0.0, "HP_Desktop_320K_keybord.jpg", false, "HP Desktop 320K keybord", 199.0, 20 },
                    { 20, 5, "Liten bärbar högtalare med imponerande ljudkvalitet både i bas och diskant", 1300.0, "samsung-hw-b660-soundbar.jpg", false, "Samsung hw b660 soundbar.jpg", 1300.0, 30 },
                    { 21, 5, "Sladdlös mus", 399.0, "voxicon-office-mus-m30wlb-rf-wireless.jpg", false, "Voxicon office mus m30wlb rf wireless", 399.0, 30 },
                    { 22, 5, "Fantastisk inomhus-router med den senaste säkerheten.Förberedd för 5G", 2200.0, "zyxel-nebula-fwa505-indoor-5g-router.jpg", false, "Zyxel Nebula fwa505 indoor 5g router", 2200.0, 15 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);
        }
    }
}
