using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovePara.Migrations
{
    public partial class InitalDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "para",
                columns: table => new
                {
                    ParaId = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    ParaText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_para", x => x.ParaId);
                });

            migrationBuilder.CreateTable(
                name: "paraLeft",
                columns: table => new
                {
                    ParaId = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
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
                    ParaId = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
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

            migrationBuilder.CreateIndex(
                name: "IX_paraLeft_ParaId",
                table: "paraLeft",
                column: "ParaId");

            migrationBuilder.CreateIndex(
                name: "IX_paraRight_ParaId",
                table: "paraRight",
                column: "ParaId");
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
