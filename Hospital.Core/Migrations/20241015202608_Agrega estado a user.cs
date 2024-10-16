using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Core.Migrations
{
    /// <inheritdoc />
    public partial class Agregaestadoauser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "AspNetUsers");
        }
    }
}
