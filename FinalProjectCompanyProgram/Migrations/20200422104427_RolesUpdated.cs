using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectCompanyProgram.Migrations
{
    public partial class RolesUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f49e7de6-b261-4405-960c-06ca97d6e848", "a71a5bf5-fdbe-492b-aeaf-1e9dbe59f133", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d19a0938-cf60-49c1-a046-8cba9ca9cd9a", "62268bf3-b39f-467f-8a28-496c3df03200", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "458d49c6-19f9-4a91-9195-a435b77258c3", "9943deb8-630f-46e6-b5d9-0593e0743cb4", "Owner", "OWNER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "458d49c6-19f9-4a91-9195-a435b77258c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d19a0938-cf60-49c1-a046-8cba9ca9cd9a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f49e7de6-b261-4405-960c-06ca97d6e848");
        }
    }
}
