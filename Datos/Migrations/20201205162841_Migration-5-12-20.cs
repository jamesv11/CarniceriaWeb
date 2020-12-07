using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class Migration51220 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagenesProductos");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "ImagenProductoId",
                table: "Productos");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Productos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagenProducto",
                table: "Productos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "ImagenProducto",
                table: "Productos");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImagenProductoId",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ImagenesProductos",
                columns: table => new
                {
                    ImagenProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagen = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagenesProductos", x => x.ImagenProductoId);
                });
        }
    }
}
