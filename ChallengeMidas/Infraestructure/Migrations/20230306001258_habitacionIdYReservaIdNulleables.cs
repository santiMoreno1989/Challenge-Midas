using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class habitacionIdYReservaIdNulleables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Huesped_ReservaId",
                table: "Huesped");

            migrationBuilder.AlterColumn<int>(
                name: "ReservaId",
                table: "Huesped",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HabitacionId",
                table: "Huesped",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Huesped_ReservaId",
                table: "Huesped",
                column: "ReservaId",
                unique: true,
                filter: "[ReservaId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Huesped_ReservaId",
                table: "Huesped");

            migrationBuilder.AlterColumn<int>(
                name: "ReservaId",
                table: "Huesped",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HabitacionId",
                table: "Huesped",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Huesped_ReservaId",
                table: "Huesped",
                column: "ReservaId",
                unique: true);
        }
    }
}
