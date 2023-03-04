using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habitacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoHabitacionEnum = table.Column<int>(type: "int", nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recepcionista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Apellido = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Legajo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recepcionista", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duracion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HabitacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reserva_Habitacion_HabitacionId",
                        column: x => x.HabitacionId,
                        principalTable: "Habitacion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Huesped",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Apellido = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    ReservaId = table.Column<int>(type: "int", nullable: false),
                    HabitacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huesped", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Huesped_Habitacion_HabitacionId",
                        column: x => x.HabitacionId,
                        principalTable: "Habitacion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Huesped_Reserva_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reserva",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Habitacion",
                columns: new[] { "Id", "Capacidad", "Precio", "TipoHabitacionEnum" },
                values: new object[,]
                {
                    { 1, 2, 10.500m, 1 },
                    { 2, 3, 14.900m, 2 },
                    { 3, 2, 18.900m, 3 },
                    { 4, 3, 26.500m, 4 }
                });

            migrationBuilder.InsertData(
                table: "Recepcionista",
                columns: new[] { "Id", "Apellido", "Legajo", "Nombre" },
                values: new object[,]
                {
                    { 1, "Moreno", 13417, "Santiago" },
                    { 2, "Iglesias", 13419, "Gala" },
                    { 3, "Olivier", 13717, "Osvaldo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Huesped_HabitacionId",
                table: "Huesped",
                column: "HabitacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Huesped_ReservaId",
                table: "Huesped",
                column: "ReservaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_HabitacionId",
                table: "Reserva",
                column: "HabitacionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Huesped");

            migrationBuilder.DropTable(
                name: "Recepcionista");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Habitacion");
        }
    }
}
