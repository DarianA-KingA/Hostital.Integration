using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital.Integration.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
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
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UltimaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoServicio = table.Column<int>(type: "int", nullable: false),
                    IdAreaMedica = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Perfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false),
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
                name: "Citas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    IdServicio = table.Column<int>(type: "int", nullable: false),
                    IdTransaccion = table.Column<int>(type: "int", nullable: false),
                    FechaAgendada = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Estado = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Citas_Servicios_IdServicio",
                        column: x => x.IdServicio,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citas_Usuarios_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transacciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCajero = table.Column<int>(type: "int", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    IdServicio = table.Column<int>(type: "int", nullable: false),
                    TipoTransaccion = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    EstadoTransaccion = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Monto = table.Column<double>(type: "float", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Estado = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transacciones_EstadoTransacciones_EstadoTransaccion",
                        column: x => x.EstadoTransaccion,
                        principalTable: "EstadoTransacciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transacciones_Servicios_IdServicio",
                        column: x => x.IdServicio,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transacciones_TipoTransaccion_TipoTransaccion",
                        column: x => x.TipoTransaccion,
                        principalTable: "TipoTransaccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transacciones_Usuarios_IdCajero",
                        column: x => x.IdCajero,
                        principalTable: "Usuarios",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Perfiles");

            migrationBuilder.DropTable(
                name: "Transacciones");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "EstadoTransacciones");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "TipoTransaccion");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "AreasMedicas");

            migrationBuilder.DropTable(
                name: "TipoServicio");
        }
    }
}
