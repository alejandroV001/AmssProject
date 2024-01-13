using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmssProject.Data.Migrations
{
    public partial class AddGrupAndRelationWithUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacitate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UtilizatoriGrupuri",
                columns: table => new
                {
                    UtilizatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GrupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilizatoriGrupuri", x => new { x.UtilizatorId, x.GrupId });
                    table.ForeignKey(
                        name: "FK_UtilizatoriGrupuri_AspNetUsers_UtilizatorId",
                        column: x => x.UtilizatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UtilizatoriGrupuri_Grup_GrupId",
                        column: x => x.GrupId,
                        principalTable: "Grup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UtilizatoriGrupuri_GrupId",
                table: "UtilizatoriGrupuri",
                column: "GrupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UtilizatoriGrupuri");

            migrationBuilder.DropTable(
                name: "Grup");
        }
    }
}
