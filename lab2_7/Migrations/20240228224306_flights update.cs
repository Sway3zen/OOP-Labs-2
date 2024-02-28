using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab2_7.Migrations
{
    /// <inheritdoc />
    public partial class flightsupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Flights",
                newName: "FirstPrice");

            migrationBuilder.AddColumn<int>(
                name: "BusinessPrice",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EconomyPrice",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessPrice",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "EconomyPrice",
                table: "Flights");

            migrationBuilder.RenameColumn(
                name: "FirstPrice",
                table: "Flights",
                newName: "Price");
        }
    }
}
