using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entidad
{
    public class DetalleFactura
    {
        public int DetalleFacturaId {get; set;}
        [Column(TypeName = "decimal(12,2)")]
        public decimal CantidadRequerida {get; set;}
        [Column(TypeName = "decimal(12,2)")]
        public decimal ValorUnitario {get; set;}

        //Relacion con la clase Producto
        public Producto ProductoDetalle {get; set;}

        //Relacion con la clase Factura
        public int FacturaId {get; set;}
        public Factura Factura {get; set;}
        
    }
}