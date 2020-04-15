using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectCompanyProgram.Migrations.LoginDB
{
    public partial class LoginErrorColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LoginErrorMessage",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoginErrorMessage",
                table: "Users");
        }
    }
}
