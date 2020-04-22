using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectCompanyProgram.Migrations
{
    public partial class DoorTableAdjusted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Doors",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Doors",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

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
    }
}
