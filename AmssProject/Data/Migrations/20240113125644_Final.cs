using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmssProject.Data.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calatorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destinatie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    GrupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calatorie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calatorie_Grup_GrupId",
                        column: x => x.GrupId,
                        principalTable: "Grup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cheltuiala",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipCheltuialaId = table.Column<int>(type: "int", nullable: false),
                    CalatorieId = table.Column<int>(type: "int", nullable: false),
                    UtilizatorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InitiatorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Moneda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCreare = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cheltuiala", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cheltuiala_AspNetUsers_InitiatorId",
                        column: x => x.InitiatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cheltuiala_Calatorie_CalatorieId",
                        column: x => x.CalatorieId,
                        principalTable: "Calatorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cheltuiala_TipCheltuiala_TipCheltuialaId",
                        column: x => x.TipCheltuialaId,
                        principalTable: "TipCheltuiala",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheltuieliCalatorie",
                columns: table => new
                {
                    CheltuialaId = table.Column<int>(type: "int", nullable: false),
                    CalatorieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheltuieliCalatorie", x => new { x.CheltuialaId, x.CalatorieId });
                    table.ForeignKey(
                        name: "FK_CheltuieliCalatorie_Calatorie_CalatorieId",
                        column: x => x.CalatorieId,
                        principalTable: "Calatorie",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CheltuieliCalatorie_Cheltuiala_CheltuialaId",
                        column: x => x.CheltuialaId,
                        principalTable: "Cheltuiala",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Datorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Suma = table.Column<float>(type: "real", nullable: false),
                    Stare = table.Column<bool>(type: "bit", nullable: false),
                    PentruUtilizatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeLaUtilizatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CheltuialaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datorie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Datorie_AspNetUsers_DeLaUtilizatorId",
                        column: x => x.DeLaUtilizatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Datorie_AspNetUsers_PentruUtilizatorId",
                        column: x => x.PentruUtilizatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Datorie_Cheltuiala_CheltuialaId",
                        column: x => x.CheltuialaId,
                        principalTable: "Cheltuiala",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notificare",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheltuialaId = table.Column<int>(type: "int", nullable: false),
                    UtilizatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Mesaj = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificare", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notificare_AspNetUsers_UtilizatorId",
                        column: x => x.UtilizatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notificare_Cheltuiala_CheltuialaId",
                        column: x => x.CheltuialaId,
                        principalTable: "Cheltuiala",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calatorie_GrupId",
                table: "Calatorie",
                column: "GrupId");

            migrationBuilder.CreateIndex(
                name: "IX_Cheltuiala_CalatorieId",
                table: "Cheltuiala",
                column: "CalatorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Cheltuiala_InitiatorId",
                table: "Cheltuiala",
                column: "InitiatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cheltuiala_TipCheltuialaId",
                table: "Cheltuiala",
                column: "TipCheltuialaId");

            migrationBuilder.CreateIndex(
                name: "IX_CheltuieliCalatorie_CalatorieId",
                table: "CheltuieliCalatorie",
                column: "CalatorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Datorie_CheltuialaId",
                table: "Datorie",
                column: "CheltuialaId");

            migrationBuilder.CreateIndex(
                name: "IX_Datorie_DeLaUtilizatorId",
                table: "Datorie",
                column: "DeLaUtilizatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Datorie_PentruUtilizatorId",
                table: "Datorie",
                column: "PentruUtilizatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificare_CheltuialaId",
                table: "Notificare",
                column: "CheltuialaId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificare_UtilizatorId",
                table: "Notificare",
                column: "UtilizatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheltuieliCalatorie");

            migrationBuilder.DropTable(
                name: "Datorie");

            migrationBuilder.DropTable(
                name: "Notificare");

            migrationBuilder.DropTable(
                name: "Cheltuiala");

            migrationBuilder.DropTable(
                name: "Calatorie");
        }
    }
}
