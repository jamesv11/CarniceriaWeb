using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entidad
{
    public class DetalleFactura
    {
        public int DetalleFacturaId {get; set;}
        [Column(TypeName = "decimal(12,2)")]
        public int CantidadRequerida {get; set;}
        [Column(TypeName = "decimal(12,2)")]
        public double ValorUnitario {get; set;}
        public double ValorNeto {get; set;}

        //Relacion con la clase Producto
        public int ProductoId {get; set;}

        public void CalcularSubtotal(){
            this.ValorNeto = CantidadRequerida * ValorUnitario;
        }        
    }
}