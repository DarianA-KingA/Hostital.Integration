using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Core.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTransaccionesCorreccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comentario",
                table: "Transacciones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comentario",
                table: "Transacciones");
        }
    }
}
