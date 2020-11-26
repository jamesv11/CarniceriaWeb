using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Entidad
{
    public class Pedido
    {
        public int PedidoID {get;set;}
        public DateTime Fecha {get;set;}
        public Factura Factura {get;set;}
        public string Direccion {get;set;}
        public List<Estado> Estados {get;set;}
        public Domiciliario Domiciliario {get;set;}



        public int FacturaID {get;set;}

        public int DomiciliarioID {get;set;}
            
    }
}