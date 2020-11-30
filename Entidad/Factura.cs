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
        public string NombreEmpresa {get; set;}
        public DateTime FechaExpedicion {get; set;}   

        [Column(TypeName = "decimal(12,2)")]
        public decimal SubTotal {get; set;}

        [Column(TypeName = "decimal(12,2)")]
        public decimal ValorTotal { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        
        public decimal Descuento { get; set; }

        //Relacion con la entidad Cliente 
        public int ClienteId {get; set;}
        
        public Cliente Cliente { get; set; }

        //para hacer la relacion con la entidad pedido

        public int PedidoId { get; set; }
        public Pedido Pedido {get; set;}

        //Relacion con la entidad Detalle
        public List<DetalleFactura> DetallesFacturas {get; set;}

        public void CalcularSubtotal()
        {
            this.SubTotal = DetallesFacturas.Sum(d => d.ValorUnitario);
        }

        public void CalcularValorDescuento()
        {
            this.Descuento = this.SubTotal * (this.Cliente.ValorDescuento / 100);       
        }
        public void CalcularValorTotal()
        {
            if(this.Cliente.ValorDescuento > 0){
                this.CalcularValorDescuento();
                this.ValorTotal = this.SubTotal + this.Descuento;
            }

            this.ValorTotal = this.SubTotal;
        }  
    
    }
}