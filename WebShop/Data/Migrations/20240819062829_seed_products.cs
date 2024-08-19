using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class seed_products : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "DiscountPrice", "ImageUrl", "IsDiscount", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Lorem Ipsum dolet...", 0.0, "desktop-inspiron-3030-mt.jpg", false, "Desktop-inspiron-3030-mt", 7700.0 },
                    { 2, 1, "Lorem Ipsum dolet...", 0.0, "desktop-inspiron-3910.jpg", false, "Desktop-inspiron-3910", 8800.0 },
                    { 3, 1, "Lorem Ipsum dolet...", 0.0, "HP_Pavilion_Gaming_Desktop_TG01.jpg", false, "HP_Pavilion_Gaming_Desktop_TG01", 9900.0 },
                    { 4, 1, "Lorem Ipsum dolet...", 0.0, "HP_Pavilion_TP01_3042.jpg", false, "HP_Pavilion_TP01_3042", 6500.0 },
                    { 5, 2, "Lorem Ipsum dolet...", 0.0, "dell-vostro-3520-core-i5-16gb-512gb-156.jpg", false, "Dell-vostro-3520-core-i5-16gb-512gb-156", 8300.0 },
                    { 6, 2, "Lorem Ipsum dolet...", 0.0, "hp_14_ep0875no.jpg", false, "HP_14_ep0875no", 5700.0 },
                    { 7, 2, "Lorem Ipsum dolet...", 0.0, "hp-255-g8-ryzen-5-8gb-256gb-156.jpg", false, "HP-255-g8-ryzen-5-8gb-256gb-156", 4700.0 },
                    { 8, 2, "Lorem Ipsum dolet...", 0.0, "lenovo-thinkpad-l13-g3-ryzen-3-8gb-256gb-133.jpg", false, "Lenovo-thinkpad-l13-g3-ryzen-3-8gb-256gb-133", 9900.0 },
                    { 9, 2, "Lorem Ipsum dolet...", 0.0, "Macbook_Air_Retina_A2179_8gb_256gb.jpg", false, "Macbook_Air_Retina_A2179_8gb_256gb", 12300.0 },
                    { 10, 2, "Lorem Ipsum dolet...", 0.0, "msi-modern-14-c7m-ryzen-7-16gb-512gb-14.jpg", false, "Msi-modern-14-c7m-ryzen-7-16gb-512gb-14", 9100.0 },
                    { 11, 2, "Lorem Ipsum dolet...", 0.0, "samsung-galaxy-book3-pro-core-i7-16gb-512gb-14.jpg", false, "Samsung-galaxy-book3-pro-core-i7-16gb-512gb-14", 6700.0 },
                    { 12, 3, "Lorem Ipsum dolet...", 0.0, "samsung-tq55q70c-55-4k-qled-smart-tv-2023.jpg", false, "Samsung-tq55q70c-55-4k-qled-smart-tv-2023", 5500.0 },
                    { 13, 3, "Lorem Ipsum dolet...", 0.0, "samsung-tu65cu7105k-1651-cm-65-4k-ultra-hd-smart-tv.jpg", false, "Samsung-tu65cu7105k-1651-cm-65-4k-ultra-hd-smart-tv", 4900.0 },
                    { 14, 4, "Lorem Ipsum dolet...", 0.0, "Apple _AirPods_Pro_2nd_gen_ with MagSafe Charging_Case_(USB‑C).jpg", false, "Apple _AirPods_Pro_2nd_gen_ with MagSafe Charging_Case_(USB‑C)", 2400.0 },
                    { 15, 4, "Lorem Ipsum dolet...", 0.0, "iphone-6-head-phone_rs130.jpg", false, "Iphone-6-head-phone_rs130", 1700.0 },
                    { 16, 4, "Lorem Ipsum dolet...", 0.0, "J917.jpg", false, "J917", 1170.0 },
                    { 17, 4, "Lorem Ipsum dolet...", 0.0, "vinnfier_elite_5BT_black.jpg", false, "Vinnfier_elite_5BT_black", 1600.0 },
                    { 18, 4, "Lorem Ipsum dolet...", 0.0, "vinnfier_elite_5BT_white.jpg", false, "Vinnfier_elite_5BT_white", 1600.0 },
                    { 19, 5, "Kvalitets-tangentbord från HP", 0.0, "HP_Desktop_320K_keybord.jpg", false, "HP_Desktop_320K_keybord", 199.0 },
                    { 20, 5, "Liten bärbar högtalare med imponerande ljudkvalitet både i bas och diskant", 0.0, "samsung-hw-b660-soundbar.jpg", false, "Samsung-hw-b660-soundbar.jpg", 1300.0 },
                    { 21, 5, "Sladdlös mus", 0.0, "voxicon-office-mus-m30wlb-rf-wireless.jpg", false, "Voxicon-office-mus-m30wlb-rf-wireless", 399.0 },
                    { 22, 5, "Fantastisk inomhus-router med den senaste säkerheten.Förberedd för 5G", 0.0, "zyxel-nebula-fwa505-indoor-5g-router.jpg", false, "Zyxel-nebula-fwa505-indoor-5g-router", 2200.0 }
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
