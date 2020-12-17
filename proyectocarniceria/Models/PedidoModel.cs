using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
namespace proyectocarniceria.Models
{

    public class PedidoInputModel { 

        public Factura Factura { get; set; }
        public Estado Estado { get; set; }
        public string CedulaDomicilario { get; set; }
        public int PedidoId { get; set; }

    }
    public class PedidoViewModel : PedidoInputModel
    {
        public PedidoViewModel(){}
        public PedidoViewModel(Pedido pedido){
            PedidoId = pedido.PedidoId;
            Factura = pedido.Factura;
            Estado = pedido.Estado;
            CedulaDomicilario = pedido.CedulaDomicilario;
        }
    }
}