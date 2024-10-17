using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Core.Migrations
{
    /// <inheritdoc />
    public partial class eliminandoFKTransacciones_Citas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacciones_Citas_IdCita",
                table: "Transacciones");

            migrationBuilder.DropIndex(
                name: "IX_Transacciones_IdCita",
                table: "Transacciones");

            migrationBuilder.DropColumn(
                name: "IdCita",
                table: "Transacciones");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCita",
                table: "Transacciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_IdCita",
                table: "Transacciones",
                column: "IdCita");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacciones_Citas_IdCita",
                table: "Transacciones",
                column: "IdCita",
                principalTable: "Citas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
