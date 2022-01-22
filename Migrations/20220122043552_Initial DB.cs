using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovePara.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "para",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParaId = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    ParaText = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_para", x => x.ParaId);
                });

            migrationBuilder.CreateTable(
                name: "paraLeft",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParaId = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paraLeft", x => x.ParaId);
                    table.ForeignKey(
                        name: "FK_paraLeft_para_ParaId",
                        column: x => x.ParaId,
                        principalTable: "para",
                        principalColumn: "ParaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "paraRight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParaId = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paraRight", x => x.ParaId);
                    table.ForeignKey(
                        name: "FK_paraRight_para_ParaId",
                        column: x => x.ParaId,
                        principalTable: "para",
                        principalColumn: "ParaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "para",
                columns: new[] { "ParaId", "ParaText" },
                values: new object[,]
                {
                    { "A", "This is Para A" },
                    { "B", "This is Para B" },
                    { "C", "This is Para C" },
                    { "D", "This is Para D" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "paraLeft");

            migrationBuilder.DropTable(
                name: "paraRight");

            migrationBuilder.DropTable(
                name: "para");
        }
    }
}
