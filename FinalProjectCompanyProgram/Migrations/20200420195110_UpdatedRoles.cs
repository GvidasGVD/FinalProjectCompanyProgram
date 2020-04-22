using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectCompanyProgram.Migrations
{
    public partial class UpdatedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e593d90-8148-42c1-bdf6-b7d912800ed4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd4ac93f-df09-4dfe-8ab9-df76f2b1e50d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f749f74c-022b-4a1a-b4d0-7bca365d3c27", "f2f30ee6-c005-4677-a5a7-ee89e8ad6f98", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1d8db79f-ef51-4cd2-99a1-835abeefe7e9", "96d136df-3476-407d-bdca-f32e781b3c63", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3ae48b8f-0f67-4f47-849a-2b714f516f25", "fa00d630-4b72-4f80-b7fc-ee0f2b09bdd1", "Owner", "OWNER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d8db79f-ef51-4cd2-99a1-835abeefe7e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ae48b8f-0f67-4f47-849a-2b714f516f25");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f749f74c-022b-4a1a-b4d0-7bca365d3c27");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9e593d90-8148-42c1-bdf6-b7d912800ed4", "2547616c-c072-42c7-86d4-35f74c43565e", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bd4ac93f-df09-4dfe-8ab9-df76f2b1e50d", "7a2f409b-1984-4f2c-9608-ad1acf24c31d", "Administrator", "ADMINISTRATOR" });
        }
    }
}
