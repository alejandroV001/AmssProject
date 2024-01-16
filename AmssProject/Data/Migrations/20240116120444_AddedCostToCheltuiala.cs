using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmssProject.Data.Migrations
{
    public partial class AddedCostToCheltuiala : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<decimal>(
                name: "CostTotal",
                table: "Cheltuiala",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostTotal",
                table: "Cheltuiala");

            
        }
    }
}
