using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EjemploRazor.Migrations
{
    public partial class EspecializacionV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especializacion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    profession = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    elite = table.Column<bool>(type: "bit", nullable: false),
                    icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    background = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especializacion", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Especializacion");
        }
    }
}
