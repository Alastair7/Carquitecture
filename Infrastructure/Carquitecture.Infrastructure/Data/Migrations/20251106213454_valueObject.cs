using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carquitecture.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class valueObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LicensePlate",
                table: "Vehicle",
                newName: "LicensePlate_PlateNumber");

            migrationBuilder.AddColumn<string>(
                name: "LicensePlate_Country",
                table: "Vehicle",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LicensePlate_Country",
                table: "Vehicle");

            migrationBuilder.RenameColumn(
                name: "LicensePlate_PlateNumber",
                table: "Vehicle",
                newName: "LicensePlate");
        }
    }
}
