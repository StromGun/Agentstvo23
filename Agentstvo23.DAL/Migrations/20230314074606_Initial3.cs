using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agentstvo23.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CadastralNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApartmentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApartmentValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    CadastralCostValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostPerMeter = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AssignationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingCadastralNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apartments");
        }
    }
}
