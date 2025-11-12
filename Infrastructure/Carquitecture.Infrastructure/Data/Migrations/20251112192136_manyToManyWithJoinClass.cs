using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carquitecture.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class manyToManyWithJoinClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleOwner_Owner_OwnersId",
                table: "VehicleOwner");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleOwner_Vehicle_VehiclesId",
                table: "VehicleOwner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleOwner",
                table: "VehicleOwner");

            migrationBuilder.RenameTable(
                name: "VehicleOwner",
                newName: "OwnerVehicle");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleOwner_VehiclesId",
                table: "OwnerVehicle",
                newName: "IX_OwnerVehicle_VehiclesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OwnerVehicle",
                table: "OwnerVehicle",
                columns: new[] { "OwnersId", "VehiclesId" });

            migrationBuilder.CreateTable(
                name: "VehicleOwners",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "integer", nullable: false),
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
                    IsOwnerActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleOwners", x => new { x.VehicleId, x.OwnerId });
                    table.ForeignKey(
                        name: "FK_VehicleOwners_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleOwners_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleOwners_OwnerId",
                table: "VehicleOwners",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_OwnerVehicle_Owner_OwnersId",
                table: "OwnerVehicle",
                column: "OwnersId",
                principalTable: "Owner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnerVehicle_Vehicle_VehiclesId",
                table: "OwnerVehicle",
                column: "VehiclesId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OwnerVehicle_Owner_OwnersId",
                table: "OwnerVehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnerVehicle_Vehicle_VehiclesId",
                table: "OwnerVehicle");

            migrationBuilder.DropTable(
                name: "VehicleOwners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OwnerVehicle",
                table: "OwnerVehicle");

            migrationBuilder.RenameTable(
                name: "OwnerVehicle",
                newName: "VehicleOwner");

            migrationBuilder.RenameIndex(
                name: "IX_OwnerVehicle_VehiclesId",
                table: "VehicleOwner",
                newName: "IX_VehicleOwner_VehiclesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleOwner",
                table: "VehicleOwner",
                columns: new[] { "OwnersId", "VehiclesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleOwner_Owner_OwnersId",
                table: "VehicleOwner",
                column: "OwnersId",
                principalTable: "Owner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleOwner_Vehicle_VehiclesId",
                table: "VehicleOwner",
                column: "VehiclesId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
