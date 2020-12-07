﻿// <auto-generated />
using System;
using Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Datos.Migrations
{
    [DbContext(typeof(CarniceriaContext))]
    [Migration("20201205162841_Migration-5-12-20")]
    partial class Migration51220
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entidad.Cliente", b =>
                {
                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("ValorDescuento")
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("Correo");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Entidad.DetalleFactura", b =>
                {
                    b.Property<int>("DetalleFacturaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CantidadRequerida")
                        .HasColumnType("decimal(12,2)");

                    b.Property<int?>("FacturaId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorUnitario")
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("DetalleFacturaId");

                    b.HasIndex("FacturaId");

                    b.HasIndex("ProductoId");

                    b.ToTable("DetalleFacturas");
                });

            modelBuilder.Entity("Entidad.Documento", b =>
                {
                    b.Property<int>("DocumentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("DomiciliarioDocumento")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("DocumentoId");

                    b.ToTable("Documentos");
                });

            modelBuilder.Entity("Entidad.Domiciliario", b =>
                {
                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Correo");

                    b.ToTable("Domiciliarios");
                });

            modelBuilder.Entity("Entidad.Factura", b =>
                {
                    b.Property<int>("FacturaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Descuento")
                        .HasColumnType("decimal(12,2)");

                    b.Property<string>("EstadoFactura")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaExpedicion")
                        .HasColumnType("datetime2");

                    b.Property<double>("PorcentajeDescuento")
                        .HasColumnType("float");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(12,2)");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("FacturaId");

                    b.HasIndex("Correo");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("Entidad.Pedido", b =>
                {
                    b.Property<int>("PedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CedulaDomicilario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<int?>("FacturaId")
                        .HasColumnType("int");

                    b.HasKey("PedidoId");

                    b.HasIndex("FacturaId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Entidad.Persona", b =>
                {
                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Correo");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("Entidad.Producto", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Categoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagenProducto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreProducto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ValorUnitario")
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("ProductoId");

                    b.ToTable("Productos");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Producto");
                });

            modelBuilder.Entity("Entidad.ProductoCarne", b =>
                {
                    b.HasBaseType("Entidad.Producto");

                    b.Property<string>("CorteRes")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ProductoCarne");
                });

            modelBuilder.Entity("Entidad.Cliente", b =>
                {
                    b.HasOne("Entidad.Persona", "Persona")
                        .WithMany()
                        .HasForeignKey("Correo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entidad.DetalleFactura", b =>
                {
                    b.HasOne("Entidad.Factura", null)
                        .WithMany("DetallesFacturas")
                        .HasForeignKey("FacturaId");

                    b.HasOne("Entidad.Producto", null)
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entidad.Domiciliario", b =>
                {
                    b.HasOne("Entidad.Persona", "Persona")
                        .WithMany()
                        .HasForeignKey("Correo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entidad.Factura", b =>
                {
                    b.HasOne("Entidad.Cliente", null)
                        .WithMany()
                        .HasForeignKey("Correo");
                });

            modelBuilder.Entity("Entidad.Pedido", b =>
                {
                    b.HasOne("Entidad.Factura", "Factura")
                        .WithMany()
                        .HasForeignKey("FacturaId");
                });
#pragma warning restore 612, 618
        }
    }
}
