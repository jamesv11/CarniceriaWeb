using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Entidad
{
    public class Factura
    {
        public int FacturaId {get; set;}
        public DateTime FechaExpedicion {get; set;}  
        public string EstadoFactura { get; set; } 

        [Column(TypeName = "decimal(12,2)")]
        public double SubTotal {get; set;}

        [Column(TypeName = "decimal(12,2)")]
        public double ValorTotal { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        
        public double Descuento { get; set; }

        public double PorcentajeDescuento { get; set; }

        //Relacion con la entidad Cliente 
        public string Correo {get; set;}

        
        //Relacion con la entidad Detalle
        public List<DetalleFactura> DetallesFacturas {get; set;}

        public void CalcularSubtotal()
        {
            this.SubTotal = DetallesFacturas.Sum(d => d.ValorUnitario);
        }

        public void CalcularValorDescuento()
        {
            this.Descuento = this.SubTotal * this.PorcentajeDescuento;       
        }
        public void CalcularValorTotal()
        {
            if(this.PorcentajeDescuento > 0){
                this.CalcularValorDescuento();
                this.ValorTotal = this.SubTotal + this.Descuento;
            }

            this.ValorTotal = this.SubTotal;
        }  
    
    }
}