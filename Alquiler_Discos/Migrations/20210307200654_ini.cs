using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alquiler_Discos.Migrations
{
    public partial class ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigoTitulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    condicion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimineto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaInscripcion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TemaInteres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NroDNI = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "alquilers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nroAlquiler = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fechaAlquiler = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    valorAlquiler = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alquilers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_alquilers_clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detalleAlquilers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    item = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    diasPrestamo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fechaDevolucion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CdId = table.Column<int>(type: "int", nullable: false),
                    AlquilerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalleAlquilers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detalleAlquilers_alquilers_AlquilerId",
                        column: x => x.AlquilerId,
                        principalTable: "alquilers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalleAlquilers_cds_CdId",
                        column: x => x.CdId,
                        principalTable: "cds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sancions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoSancion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NroDiasSancion = table.Column<int>(type: "int", nullable: false),
                    AlquilerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sancions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sancions_alquilers_AlquilerId",
                        column: x => x.AlquilerId,
                        principalTable: "alquilers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_alquilers_ClienteId",
                table: "alquilers",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_detalleAlquilers_AlquilerId",
                table: "detalleAlquilers",
                column: "AlquilerId");

            migrationBuilder.CreateIndex(
                name: "IX_detalleAlquilers_CdId",
                table: "detalleAlquilers",
                column: "CdId");

            migrationBuilder.CreateIndex(
                name: "IX_sancions_AlquilerId",
                table: "sancions",
                column: "AlquilerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalleAlquilers");

            migrationBuilder.DropTable(
                name: "sancions");

            migrationBuilder.DropTable(
                name: "cds");

            migrationBuilder.DropTable(
                name: "alquilers");

            migrationBuilder.DropTable(
                name: "clientes");
        }
    }
}
