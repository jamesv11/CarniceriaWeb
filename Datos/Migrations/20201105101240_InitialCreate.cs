using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Domiciliarios",
                columns: table => new
                {
                    DomiciliarioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificacion = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domiciliarios", x => x.DomiciliarioID);
                });

            migrationBuilder.CreateTable(
                name: "ImagenesProductos",
                columns: table => new
                {
                    ImagenProductoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagen = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagenesProductos", x => x.ImagenProductoID);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    PersonaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.PersonaID);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProducto = table.Column<string>(nullable: true),
                    CantidadEnStock = table.Column<decimal>(nullable: false),
                    ValorUnitario = table.Column<decimal>(nullable: false),
                    descripcion = table.Column<string>(nullable: true),
                    Categoria = table.Column<string>(nullable: true),
                    Tag = table.Column<string>(nullable: true),
                    DetalleID = table.Column<int>(nullable: false),
                    ImagenProductoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoID);
                });

            migrationBuilder.CreateTable(
                name: "Documentos",
                columns: table => new
                {
                    DocumentoID = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Identificacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.DocumentoID);
                    table.ForeignKey(
                        name: "FK_Documentos_Domiciliarios_DocumentoID",
                        column: x => x.DocumentoID,
                        principalTable: "Domiciliarios",
                        principalColumn: "DomiciliarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    FacturaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Total = table.Column<decimal>(type: "DECIMAL(18,3)", nullable: false),
                    ClienteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.FacturaID);
                    table.ForeignKey(
                        name: "FK_Facturas_Personas_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Personas",
                        principalColumn: "PersonaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleFacturas",
                columns: table => new
                {
                    DetalleFacturaID = table.Column<int>(nullable: false),
                    CantidadRequerida = table.Column<decimal>(nullable: false),
                    ValorUnitario = table.Column<decimal>(nullable: false),
                    SubTotal = table.Column<decimal>(nullable: false),
                    FacturaID = table.Column<int>(nullable: false),
                    ProductoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleFacturas", x => x.DetalleFacturaID);
                    table.ForeignKey(
                        name: "FK_DetalleFacturas_Facturas_DetalleFacturaID",
                        column: x => x.DetalleFacturaID,
                        principalTable: "Facturas",
                        principalColumn: "FacturaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleFacturas_Productos_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "Productos",
                        principalColumn: "ProductoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PedidoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    FacturaID = table.Column<int>(nullable: false),
                    DomiciliarioID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.PedidoID);
                    table.ForeignKey(
                        name: "FK_Pedidos_Domiciliarios_DomiciliarioID",
                        column: x => x.DomiciliarioID,
                        principalTable: "Domiciliarios",
                        principalColumn: "DomiciliarioID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_Facturas_FacturaID",
                        column: x => x.FacturaID,
                        principalTable: "Facturas",
                        principalColumn: "FacturaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    EstadoID = table.Column<int>(nullable: false),
                    NombreEstado = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.EstadoID);
                    table.ForeignKey(
                        name: "FK_Estados_Pedidos_EstadoID",
                        column: x => x.EstadoID,
                        principalTable: "Pedidos",
                        principalColumn: "PedidoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFacturas_ProductoID",
                table: "DetalleFacturas",
                column: "ProductoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_ClienteID",
                table: "Facturas",
                column: "ClienteID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_DomiciliarioID",
                table: "Pedidos",
                column: "DomiciliarioID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_FacturaID",
                table: "Pedidos",
                column: "FacturaID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleFacturas");

            migrationBuilder.DropTable(
                name: "Documentos");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "ImagenesProductos");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Domiciliarios");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
