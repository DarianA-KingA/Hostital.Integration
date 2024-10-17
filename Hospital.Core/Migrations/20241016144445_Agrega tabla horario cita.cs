using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Core.Migrations
{
    /// <inheritdoc />
    public partial class Agregatablahorariocita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idHorarioCita",
                table: "Citas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "HorariosCitas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoraInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraFin = table.Column<TimeSpan>(type: "time", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorariosCitas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_idHorarioCita",
                table: "Citas",
                column: "idHorarioCita");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_HorariosCitas_idHorarioCita",
                table: "Citas",
                column: "idHorarioCita",
                principalTable: "HorariosCitas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_HorariosCitas_idHorarioCita",
                table: "Citas");

            migrationBuilder.DropTable(
                name: "HorariosCitas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_idHorarioCita",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "idHorarioCita",
                table: "Citas");
        }
    }
}
