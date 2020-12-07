using System;
using Microsoft.EntityFrameworkCore;
using Entidad;

namespace Datos
{
    public class CarniceriaContext : DbContext
    {
        public CarniceriaContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<DetalleFactura> DetalleFacturas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Domiciliario> Domiciliarios { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<ProductoCarne> ProductoCarnes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Domiciliario>()
            .HasOne(d => d.Persona)
            .WithMany()
            .HasForeignKey(b => b.Correo);

            modelBuilder.Entity<Cliente>()
            .HasOne(p => p.Persona)
            .WithMany()
            .HasForeignKey(b => b.Correo);

            modelBuilder.Entity<Factura>()
            .HasOne<Cliente>()
            .WithMany()
            .HasForeignKey(b => b.Correo);

            modelBuilder.Entity<DetalleFactura>()
            .HasOne<Producto>()
            .WithMany()
            .HasForeignKey(b => b.ProductoId);
         

            modelBuilder.Entity<Cliente>().HasKey(c => c.Correo);
            modelBuilder.Entity<Domiciliario>().HasKey(c => c.Correo);   
            
            /*
            modelBuilder.Entity<Cliente>()
                .HasOne(b => b.Carrito)
                .WithOne(i => i.ClienteFactura)
                .HasForeignKey<Factura>(b => b.ClienteID);
            modelBuilder.Entity<DetalleFactura>()
                .HasOne<Factura>(c => c.Factura)
                .WithMany(c => c.DetallesFactura)
                .HasForeignKey(c => c.DetalleFacturaID);
            modelBuilder.Entity<DetalleFactura>()
                .HasOne(b => b.ProductoDetalle)
                .WithOne(i => i.DetalleFactura)
                .HasForeignKey<DetalleFactura>(b => b.ProductoID);
            modelBuilder.Entity<Pedido>()
                .HasOne(b => b.Factura)
                .WithOne(i => i.Pedido)
                .HasForeignKey<Pedido>(b => b.FacturaID);
            modelBuilder.Entity<Estado>()
                .HasOne<Pedido>(c => c.Pedido)
                .WithMany(c => c.Estados)
                .HasForeignKey(c => c.EstadoID);
            modelBuilder.Entity<Pedido>()
                .HasOne(b => b.Domiciliario)
                .WithOne(i => i.Pedido)
                .HasForeignKey<Pedido>(b => b.DomiciliarioID);
            
            */
        }
    }
}