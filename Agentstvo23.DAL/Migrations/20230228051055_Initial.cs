using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agentstvo23.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CadastralNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    CadastralCostValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostPerMeter = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AssignationBuilding = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CadastralBlock = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearBuilt = table.Column<int>(type: "int", nullable: false),
                    Floors = table.Column<int>(type: "int", nullable: false),
                    UndergroundFloors = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buildings");
        }
    }
}
