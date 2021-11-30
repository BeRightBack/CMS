using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class addUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95194e5b-433f-42d4-8d41-74746f7f334b",
                column: "ConcurrencyStamp",
                value: "f31ea5d8-4c38-485a-8579-643856a9186f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6bb07ce-a39f-4ad0-b598-821b73034adc",
                column: "ConcurrencyStamp",
                value: "1a91c721-2634-429f-acbc-42941fcea89b");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "95194e5b-433f-42d4-8d41-74746f7f334b", 0, "6ff7115f-9a3a-4398-aeae-00179e2b57d1", "admin@frenzyzone.com", true, null, null, false, null, "ADMIN@FRENZYZONE.COM", "ADMIN@FRENZYZONE.COM", "AQAAAAEAACcQAAAAELeFlF2BpaCw1lH/e/Vl+WIOTjBlTSZyqyhOrH4doIOxatqrxe35duggGjshP8lFag==", null, false, "", false, "admin@frenzyzone.com" });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1,
                column: "Url",
                value: "http://frenzyzone.com.Indiana");

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2,
                column: "Url",
                value: "http://frenzyzone.com.AppleBee");

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 3,
                column: "Url",
                value: "http://frenzyzone.com.TechnoHub");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "95194e5b-433f-42d4-8d41-74746f7f334b", "95194e5b-433f-42d4-8d41-74746f7f334b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "95194e5b-433f-42d4-8d41-74746f7f334b", "95194e5b-433f-42d4-8d41-74746f7f334b" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "95194e5b-433f-42d4-8d41-74746f7f334b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95194e5b-433f-42d4-8d41-74746f7f334b",
                column: "ConcurrencyStamp",
                value: "122b92b5-eaf1-4e19-ad81-24b2819b0376");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6bb07ce-a39f-4ad0-b598-821b73034adc",
                column: "ConcurrencyStamp",
                value: "ecb59e92-13d9-4729-8c40-94096c5964ce");

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1,
                column: "Url",
                value: "http:frenzyzone.com.Indiana");

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2,
                column: "Url",
                value: "http:frenzyzone.com.AppleBee");

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 3,
                column: "Url",
                value: "http:frenzyzone.com.TechnoHub");
        }
    }
}
