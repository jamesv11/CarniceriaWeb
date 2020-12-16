using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace proyectocarniceria.Models
{
    public class FacturaInputModel
    {
      //  [PersonaValidacion ]

        public List<DetalleFactura> DetallesFacturas {get; set;}
        public string Correo {get; set;}

    }

    public class FacturaViewModel : FacturaInputModel
    {
        public int FacturaId { get; set; }
        public DateTime FechaExpedicion {get; set;}  
        public string EstadoFactura { get; set; }
        public double Descuento { get; set; }
        public double SubTotal {get; set;} 
        public double ValorTotal { get; set; }

        //Relacion con la entidad Persona

        public FacturaViewModel() { }
        public FacturaViewModel(Factura factura)
        {
            FacturaId = factura.FacturaId;
            DetallesFacturas = factura.DetallesFacturas;
            Correo = factura.Correo;
            Descuento = factura.Descuento;
            FechaExpedicion = factura.FechaExpedicion;
            EstadoFactura= factura.EstadoFactura;
            SubTotal = factura.SubTotal;
            ValorTotal = factura.ValorTotal;
        }
    }

}