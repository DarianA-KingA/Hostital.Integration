using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital.Integration.Migrations
{
    /// <inheritdoc />
    public partial class Reduceentidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Servicios_IdServicio",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Usuarios_IdPaciente",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacciones_EstadoTransacciones_EstadoTransaccion",
                table: "Transacciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacciones_Servicios_IdServicio",
                table: "Transacciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacciones_TipoTransaccion_TipoTransaccion",
                table: "Transacciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacciones_Usuarios_IdCajero",
                table: "Transacciones");

            migrationBuilder.DropTable(
                name: "EstadoTransacciones");

            migrationBuilder.DropTable(
                name: "Perfiles");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "TipoTransaccion");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "AreasMedicas");

            migrationBuilder.DropTable(
                name: "TipoServicio");

            migrationBuilder.DropIndex(
                name: "IX_Transacciones_EstadoTransaccion",
                table: "Transacciones");

            migrationBuilder.DropIndex(
                name: "IX_Transacciones_IdCajero",
                table: "Transacciones");

            migrationBuilder.DropIndex(
                name: "IX_Transacciones_IdServicio",
                table: "Transacciones");

            migrationBuilder.DropIndex(
                name: "IX_Transacciones_TipoTransaccion",
                table: "Transacciones");

            migrationBuilder.DropIndex(
                name: "IX_Citas_IdPaciente",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_IdServicio",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "Apellidos",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Clave",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Nombres",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "EstadoTransaccion",
                table: "Transacciones");

            migrationBuilder.DropColumn(
                name: "TipoTransaccion",
                table: "Transacciones");

            migrationBuilder.RenameColumn(
                name: "UltimaModificacion",
                table: "Usuarios",
                newName: "Birthday");

            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "Usuarios",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "IdServicio",
                table: "Transacciones",
                newName: "TransaccionesId");

            migrationBuilder.RenameColumn(
                name: "IdTransaccion",
                table: "Citas",
                newName: "IdHorarioCita");

            migrationBuilder.AlterColumn<bool>(
                name: "Estado",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cedula",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AddColumn<string>(
                name: "Accion",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Pendiente",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "IdPaciente",
                table: "Transacciones",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "IdCajero",
                table: "Transacciones",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Transacciones",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<bool>(
                name: "Estado",
                table: "Transacciones",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "Accion",
                table: "Transacciones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Comentario",
                table: "Transacciones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdEstadoTransaccion",
                table: "Transacciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdTipoTransaccion",
                table: "Transacciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Pendiente",
                table: "Transacciones",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "IdPaciente",
                table: "Citas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaAgendada",
                table: "Citas",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<bool>(
                name: "Estado",
                table: "Citas",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "Accion",
                table: "Citas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdCita",
                table: "Citas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Pendiente",
                table: "Citas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accion",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Pendiente",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Accion",
                table: "Transacciones");

            migrationBuilder.DropColumn(
                name: "Comentario",
                table: "Transacciones");

            migrationBuilder.DropColumn(
                name: "IdEstadoTransaccion",
                table: "Transacciones");

            migrationBuilder.DropColumn(
                name: "IdTipoTransaccion",
                table: "Transacciones");

            migrationBuilder.DropColumn(
                name: "Pendiente",
                table: "Transacciones");

            migrationBuilder.DropColumn(
                name: "Accion",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "IdCita",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "Pendiente",
                table: "Citas");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Usuarios",
                newName: "Telefono");

            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "Usuarios",
                newName: "UltimaModificacion");

            migrationBuilder.RenameColumn(
                name: "TransaccionesId",
                table: "Transacciones",
                newName: "IdServicio");

            migrationBuilder.RenameColumn(
                name: "IdHorarioCita",
                table: "Citas",
                newName: "IdTransaccion");

            migrationBuilder.AlterColumn<bool>(
                name: "Estado",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Cedula",
                table: "Usuarios",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Apellidos",
                table: "Usuarios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Clave",
                table: "Usuarios",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Usuarios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Usuarios",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Nombres",
                table: "Usuarios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "IdPaciente",
                table: "Transacciones",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "IdCajero",
                table: "Transacciones",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Transacciones",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "Estado",
                table: "Transacciones",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "EstadoTransaccion",
                table: "Transacciones",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "TipoTransaccion",
                table: "Transacciones",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "IdPaciente",
                table: "Citas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaAgendada",
                table: "Citas",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "Estado",
                table: "Citas",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateTable(
                name: "AreasMedicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasMedicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoTransacciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoTransacciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoServicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoServicio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoTransaccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTransaccion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perfiles_Roles_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Perfiles_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAreaMedica = table.Column<int>(type: "int", nullable: false),
                    IdTipoServicio = table.Column<int>(type: "int", nullable: false),
                    Costo = table.Column<double>(type: "float", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicios_AreasMedicas_IdAreaMedica",
                        column: x => x.IdAreaMedica,
                        principalTable: "AreasMedicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Servicios_TipoServicio_IdTipoServicio",
                        column: x => x.IdTipoServicio,
                        principalTable: "TipoServicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EstadoTransacciones",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "pending" },
                    { 2, "applied" },
                    { 3, "rollback" }
                });

            migrationBuilder.InsertData(
                table: "TipoServicio",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Analisis" },
                    { 2, "Procedimiento" }
                });

            migrationBuilder.InsertData(
                table: "TipoTransaccion",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "CashInflow" },
                    { 2, "CashOutflow" },
                    { 3, "ServicePayment" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_EstadoTransaccion",
                table: "Transacciones",
                column: "EstadoTransaccion");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_IdCajero",
                table: "Transacciones",
                column: "IdCajero");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_IdServicio",
                table: "Transacciones",
                column: "IdServicio",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_TipoTransaccion",
                table: "Transacciones",
                column: "TipoTransaccion");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_IdPaciente",
                table: "Citas",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_IdServicio",
                table: "Citas",
                column: "IdServicio");

            migrationBuilder.CreateIndex(
                name: "IX_Perfiles_IdRol",
                table: "Perfiles",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Perfiles_IdUsuario",
                table: "Perfiles",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_IdAreaMedica",
                table: "Servicios",
                column: "IdAreaMedica");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_IdTipoServicio",
                table: "Servicios",
                column: "IdTipoServicio");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Servicios_IdServicio",
                table: "Citas",
                column: "IdServicio",
                principalTable: "Servicios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Usuarios_IdPaciente",
                table: "Citas",
                column: "IdPaciente",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacciones_EstadoTransacciones_EstadoTransaccion",
                table: "Transacciones",
                column: "EstadoTransaccion",
                principalTable: "EstadoTransacciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacciones_Servicios_IdServicio",
                table: "Transacciones",
                column: "IdServicio",
                principalTable: "Servicios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacciones_TipoTransaccion_TipoTransaccion",
                table: "Transacciones",
                column: "TipoTransaccion",
                principalTable: "TipoTransaccion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacciones_Usuarios_IdCajero",
                table: "Transacciones",
                column: "IdCajero",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
