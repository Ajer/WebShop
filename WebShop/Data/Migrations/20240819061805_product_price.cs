using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class product_price : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<double>(
                name: "DiscountPrice",
                table: "Products",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDiscount",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Products",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDiscount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Lorem Ipsum dolet...", "desktop-inspiron-3030-mt.jpg", "Desktop-inspiron-3030-mt" },
                    { 2, 1, "Lorem Ipsum dolet...", "desktop-inspiron-3910.jpg", "Desktop-inspiron-3910" },
                    { 3, 1, "Lorem Ipsum dolet...", "HP_Pavilion_Gaming_Desktop_TG01.jpg", "HP_Pavilion_Gaming_Desktop_TG01" },
                    { 4, 1, "Lorem Ipsum dolet...", "HP_Pavilion_TP01_3042.jpg", "HP_Pavilion_TP01_3042" },
                    { 5, 2, "Lorem Ipsum dolet...", "dell-vostro-3520-core-i5-16gb-512gb-156.jpg", "Dell-vostro-3520-core-i5-16gb-512gb-156" },
                    { 6, 2, "Lorem Ipsum dolet...", "hp_14_ep0875no.jpg", "HP_14_ep0875no" },
                    { 7, 2, "Lorem Ipsum dolet...", "hp-255-g8-ryzen-5-8gb-256gb-156.jpg", "HP-255-g8-ryzen-5-8gb-256gb-156" },
                    { 8, 2, "Lorem Ipsum dolet...", "lenovo-thinkpad-l13-g3-ryzen-3-8gb-256gb-133.jpg", "Lenovo-thinkpad-l13-g3-ryzen-3-8gb-256gb-133" },
                    { 9, 2, "Lorem Ipsum dolet...", "Macbook_Air_Retina_A2179_8gb_256gb.jpg", "Macbook_Air_Retina_A2179_8gb_256gb" },
                    { 10, 2, "Lorem Ipsum dolet...", "msi-modern-14-c7m-ryzen-7-16gb-512gb-14.jpg", "Msi-modern-14-c7m-ryzen-7-16gb-512gb-14" },
                    { 11, 2, "Lorem Ipsum dolet...", "samsung-galaxy-book3-pro-core-i7-16gb-512gb-14.jpg", "Samsung-galaxy-book3-pro-core-i7-16gb-512gb-14" },
                    { 12, 3, "Lorem Ipsum dolet...", "samsung-tq55q70c-55-4k-qled-smart-tv-2023.jpg", "Samsung-tq55q70c-55-4k-qled-smart-tv-2023" },
                    { 13, 3, "Lorem Ipsum dolet...", "samsung-tu65cu7105k-1651-cm-65-4k-ultra-hd-smart-tv.jpg", "Samsung-tu65cu7105k-1651-cm-65-4k-ultra-hd-smart-tv" },
                    { 14, 4, "Lorem Ipsum dolet...", "Apple _AirPods_Pro_2nd_gen_ with MagSafe Charging_Case_(USB‑C).jpg", "Apple _AirPods_Pro_2nd_gen_ with MagSafe Charging_Case_(USB‑C)" },
                    { 15, 4, "Lorem Ipsum dolet...", "iphone-6-head-phone_rs130.jpg", "Iphone-6-head-phone_rs130" },
                    { 16, 4, "Lorem Ipsum dolet...", "J917.jpg", "J917" },
                    { 17, 4, "Lorem Ipsum dolet...", "vinnfier_elite_5BT_black.jpg", "Vinnfier_elite_5BT_black" },
                    { 18, 4, "Lorem Ipsum dolet...", "vinnfier_elite_5BT_white.jpg", "Vinnfier_elite_5BT_white" },
                    { 19, 5, "Lorem Ipsum dolet...", "HP_Desktop_320K_keybord.jpg", "HP_Desktop_320K_keybord" },
                    { 20, 5, "Lorem Ipsum dolet...", "samsung-hw-b660-soundbar.jpg", "Samsung-hw-b660-soundbar.jpg" },
                    { 21, 5, "Lorem Ipsum dolet...", "voxicon-office-mus-m30wlb-rf-wireless.jpg", "Voxicon-office-mus-m30wlb-rf-wireless" },
                    { 22, 5, "Lorem Ipsum dolet...", "zyxel-nebula-fwa505-indoor-5g-router.jpg", "Zyxel-nebula-fwa505-indoor-5g-router" }
                });
        }
    }
}
