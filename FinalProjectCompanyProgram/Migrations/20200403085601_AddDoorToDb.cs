using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectCompanyProgram.Migrations
{
    public partial class AddDoorToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    DoorLeaf = table.Column<string>(nullable: true),
                    DoorJamb = table.Column<string>(nullable: true),
                    Hinges = table.Column<string>(nullable: true),
                    Finish = table.Column<string>(nullable: true),
                    Height = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Additions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doors", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doors");
        }
    }
}
