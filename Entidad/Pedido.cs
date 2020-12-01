using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Entidad
{
    public class Pedido
    {
        public int PedidoId {get;set;}
        public DateTime Fecha {get;set;}
        public Estado Estado {get;set;}
        public Pedido()
        { this.Estado = Estado.Pendiente;}

        //Relacion con la clase factura 
        public Factura Factura {get;set;}

        //Relacion con la clase Domiciliario      
        public int DomiciliarioId { get; set; }
        public Domiciliario Domiciliario {get;set;}
    }
}