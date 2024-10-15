using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Core.Migrations
{
    /// <inheritdoc />
    public partial class AllEntites : Migration
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
                    Estado = table.Column<bool>(type: "bit", nullable: false)
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
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoTransacciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoServicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
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
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTransaccion", x => x.Id);
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
                    Estado = table.Column<bool>(type: "bit", nullable: false)
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
                name: "Citas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPaciente = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdServicio = table.Column<int>(type: "int", nullable: false),
                    FechaAgendada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Citas_AspNetUsers_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citas_Servicios_IdServicio",
                        column: x => x.IdServicio,
                        principalTable: "Servicios",
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
                    TipoTransaccion = table.Column<int>(type: "int", nullable: false),
                    EstadoTransaccion = table.Column<int>(type: "int", nullable: false),
                    Monto = table.Column<double>(type: "float", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCita = table.Column<int>(type: "int", nullable: false),
                    ServiciosId = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transacciones_Citas_IdCita",
                        column: x => x.IdCita,
                        principalTable: "Citas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transacciones_EstadoTransacciones_EstadoTransaccion",
                        column: x => x.EstadoTransaccion,
                        principalTable: "EstadoTransacciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transacciones_Servicios_ServiciosId",
                        column: x => x.ServiciosId,
                        principalTable: "Servicios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transacciones_TipoTransaccion_TipoTransaccion",
                        column: x => x.TipoTransaccion,
                        principalTable: "TipoTransaccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Transacciones_IdCita",
                table: "Transacciones",
                column: "IdCita");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_ServiciosId",
                table: "Transacciones",
                column: "ServiciosId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_TipoTransaccion",
                table: "Transacciones",
                column: "TipoTransaccion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacciones");

            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "EstadoTransacciones");

            migrationBuilder.DropTable(
                name: "TipoTransaccion");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "AreasMedicas");

            migrationBuilder.DropTable(
                name: "TipoServicio");
        }
    }
}
