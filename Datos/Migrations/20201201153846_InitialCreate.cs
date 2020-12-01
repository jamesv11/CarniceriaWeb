using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    AdministradorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.AdministradorId);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    ValorDescuento = table.Column<decimal>(type: "decimal(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Domiciliarios",
                columns: table => new
                {
                    DomiciliarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domiciliarios", x => x.DomiciliarioId);
                });

            migrationBuilder.CreateTable(
                name: "ImagenesProductos",
                columns: table => new
                {
                    ImagenProductoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagen = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagenesProductos", x => x.ImagenProductoId);
                });

            migrationBuilder.CreateTable(
                name: "Documentos",
                columns: table => new
                {
                    DocumentoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    DomiciliarioId = table.Column<string>(nullable: true),
                    DomiciliarioId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.DocumentoId);
                    table.ForeignKey(
                        name: "FK_Documentos_Domiciliarios_DomiciliarioId1",
                        column: x => x.DomiciliarioId1,
                        principalTable: "Domiciliarios",
                        principalColumn: "DomiciliarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PedidoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    DomiciliarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.PedidoId);
                    table.ForeignKey(
                        name: "FK_Pedidos_Domiciliarios_DomiciliarioId",
                        column: x => x.DomiciliarioId,
                        principalTable: "Domiciliarios",
                        principalColumn: "DomiciliarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    PersonaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificacion = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Rol = table.Column<string>(nullable: true),
                    AdministradorId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    DomiciliarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.PersonaId);
                    table.ForeignKey(
                        name: "FK_Personas_Administradores_AdministradorId",
                        column: x => x.AdministradorId,
                        principalTable: "Administradores",
                        principalColumn: "AdministradorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personas_Domiciliarios_DomiciliarioId",
                        column: x => x.DomiciliarioId,
                        principalTable: "Domiciliarios",
                        principalColumn: "DomiciliarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    FacturaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEmpresa = table.Column<string>(nullable: true),
                    FechaExpedicion = table.Column<DateTime>(nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    PedidoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.FacturaId);
                    table.ForeignKey(
                        name: "FK_Facturas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Facturas_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "PedidoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleFacturas",
                columns: table => new
                {
                    DetalleFacturaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CantidadRequerida = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    FacturaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleFacturas", x => x.DetalleFacturaId);
                    table.ForeignKey(
                        name: "FK_DetalleFacturas_Facturas_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "Facturas",
                        principalColumn: "FacturaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProducto = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Categoria = table.Column<string>(nullable: true),
                    DetalleFacturaId = table.Column<int>(nullable: false),
                    ImagenProductoId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    CorteRes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                    table.ForeignKey(
                        name: "FK_Productos_DetalleFacturas_DetalleFacturaId",
                        column: x => x.DetalleFacturaId,
                        principalTable: "DetalleFacturas",
                        principalColumn: "DetalleFacturaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFacturas_FacturaId",
                table: "DetalleFacturas",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_DomiciliarioId1",
                table: "Documentos",
                column: "DomiciliarioId1");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_ClienteId",
                table: "Facturas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_PedidoId",
                table: "Facturas",
                column: "PedidoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_DomiciliarioId",
                table: "Pedidos",
                column: "DomiciliarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_AdministradorId",
                table: "Personas",
                column: "AdministradorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_ClienteId",
                table: "Personas",
                column: "ClienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_DomiciliarioId",
                table: "Personas",
                column: "DomiciliarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_DetalleFacturaId",
                table: "Productos",
                column: "DetalleFacturaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documentos");

            migrationBuilder.DropTable(
                name: "ImagenesProductos");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "DetalleFacturas");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Domiciliarios");
        }
    }
}
