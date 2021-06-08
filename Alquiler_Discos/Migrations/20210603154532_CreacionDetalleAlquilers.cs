using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alquiler_Discos.Migrations
{
    public partial class CreacionDetalleAlquilers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detalleAlquilers_alquilers_AlquilerId",
                table: "detalleAlquilers");

            migrationBuilder.DropForeignKey(
                name: "FK_detalleAlquilers_cds_CdId",
                table: "detalleAlquilers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_detalleAlquilers",
                table: "detalleAlquilers");

            migrationBuilder.DropIndex(
                name: "IX_detalleAlquilers_CdId",
                table: "detalleAlquilers");

            migrationBuilder.DropColumn(
                name: "CdId",
                table: "detalleAlquilers");

            migrationBuilder.DropColumn(
                name: "fechaDevolucion",
                table: "detalleAlquilers");

            migrationBuilder.DropColumn(
                name: "item",
                table: "detalleAlquilers");

            migrationBuilder.RenameTable(
                name: "detalleAlquilers",
                newName: "DetalleAlquiler");

            migrationBuilder.RenameColumn(
                name: "diasPrestamo",
                table: "DetalleAlquiler",
                newName: "ProductoId");

            migrationBuilder.RenameIndex(
                name: "IX_detalleAlquilers_AlquilerId",
                table: "DetalleAlquiler",
                newName: "IX_DetalleAlquiler_AlquilerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetalleAlquiler",
                table: "DetalleAlquiler",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleAlquiler_ProductoId",
                table: "DetalleAlquiler",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleAlquiler_alquilers_AlquilerId",
                table: "DetalleAlquiler",
                column: "AlquilerId",
                principalTable: "alquilers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleAlquiler_productos_ProductoId",
                table: "DetalleAlquiler",
                column: "ProductoId",
                principalTable: "productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleAlquiler_alquilers_AlquilerId",
                table: "DetalleAlquiler");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleAlquiler_productos_ProductoId",
                table: "DetalleAlquiler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetalleAlquiler",
                table: "DetalleAlquiler");

            migrationBuilder.DropIndex(
                name: "IX_DetalleAlquiler_ProductoId",
                table: "DetalleAlquiler");

            migrationBuilder.RenameTable(
                name: "DetalleAlquiler",
                newName: "detalleAlquilers");

            migrationBuilder.RenameColumn(
                name: "ProductoId",
                table: "detalleAlquilers",
                newName: "diasPrestamo");

            migrationBuilder.RenameIndex(
                name: "IX_DetalleAlquiler_AlquilerId",
                table: "detalleAlquilers",
                newName: "IX_detalleAlquilers_AlquilerId");

            migrationBuilder.AddColumn<int>(
                name: "CdId",
                table: "detalleAlquilers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaDevolucion",
                table: "detalleAlquilers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "item",
                table: "detalleAlquilers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_detalleAlquilers",
                table: "detalleAlquilers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_detalleAlquilers_CdId",
                table: "detalleAlquilers",
                column: "CdId");

            migrationBuilder.AddForeignKey(
                name: "FK_detalleAlquilers_alquilers_AlquilerId",
                table: "detalleAlquilers",
                column: "AlquilerId",
                principalTable: "alquilers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detalleAlquilers_cds_CdId",
                table: "detalleAlquilers",
                column: "CdId",
                principalTable: "cds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
