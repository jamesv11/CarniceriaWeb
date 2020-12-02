using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entidad
{
    public class DetalleFactura
    {
        public int DetalleFacturaId {get; set;}
        [Column(TypeName = "decimal(12,2)")]
        public double CantidadRequerida {get; set;}
        [Column(TypeName = "decimal(12,2)")]
        public double ValorUnitario {get; set;}

        //Relacion con la clase Producto
        public int ProductoId {get; set;}        
    }
}