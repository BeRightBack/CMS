using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class ApiSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[,]
                {
                    { 1, "Canada", "CA" },
                    { 2, "United State", "US" },
                    { 3, "Mexico", "MX" }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "Indiana", "http:frenzyzone.com.Indiana" },
                    { 2, "AppleBee", "http:frenzyzone.com.AppleBee" },
                    { 3, "TechnoHub", "http:frenzyzone.com.TechnoHub" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CountryId", "Name", "Rating" },
                values: new object[,]
                {
                    { 1, "Mtl", 1, "Down Town Resort and Spa", 4.5 },
                    { 2, "George Town", 2, "Comfort Suites", 4.2999999999999998 },
                    { 3, "Mexico City", 2, "Grand Palldium", 4.0 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "FullDescription", "Name", "Price", "ShortDescription", "StoreId" },
                values: new object[,]
                {
                    { 1, "Full description", "Down Town Resort and Spa", 100.0, "short description", 1 },
                    { 2, "Full description", "Comfort Suites", 10.0, "short description", 2 },
                    { 3, "Full description", "Grand Palldium", 1.0, "short description", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3);

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
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
