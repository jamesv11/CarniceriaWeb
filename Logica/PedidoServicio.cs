using System.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;
using Microsoft.EntityFrameworkCore;
namespace Logica
{
    public class PedidoServicio
    {
        private readonly CarniceriaContext _context;

        public PedidoServicio(CarniceriaContext context)
        { 
            _context = context;
        }

        public ConsultarPedidoResponse ConsultarTodos()
        {
            try
            {
                var pedidos = _context.Pedidos.Include(p => p.Factura).Include(p => p.Factura.DetallesFacturas).ToList();
                return new ConsultarPedidoResponse(pedidos);

            }
            catch (Exception e)
            {
                return new ConsultarPedidoResponse($"error de aplicacion: {e.Message}");
            }

        }

        public ModificarPedidoResponse Modificar(Pedido pedidoNuevo)
        {
           
            try
            {
                 var pedidoViejo = _context.Pedidos.Where(p => p.PedidoId == pedidoNuevo.PedidoId).FirstOrDefault();
                 if(pedidoViejo != null)
                 {
                     pedidoViejo.PedidoId = pedidoNuevo.PedidoId;
                     pedidoViejo.Estado = pedidoNuevo.Estado;
                     pedidoViejo.CedulaDomicilario = pedidoNuevo.CedulaDomicilario;
                     _context.Pedidos.Update(pedidoViejo);
                     _context.SaveChanges();
                     return new ModificarPedidoResponse(pedidoViejo);
                 }
                 else
                 {
                     return new ModificarPedidoResponse($"Lo sentimos no se encuentra registrada la persona : {pedidoViejo.PedidoId}");
                 }
            }
            catch (Exception e)
            {
                
                return new  ModificarPedidoResponse($"Error de aplicacion: {e.Message}");
            }
        }
    }
    public class ConsultarPedidoResponse
    {
        public ConsultarPedidoResponse(List<Pedido> pedidos)
        {
            Error = false;
            Pedidos = pedidos;
        }
        public ConsultarPedidoResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<Pedido> Pedidos { get; set; }
    }
    public class ModificarPedidoResponse
    {
        public ModificarPedidoResponse(Pedido pedido )
        {
            Error = false;
            Pedido = pedido;
        }
        public ModificarPedidoResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Pedido Pedido { get; set; }
    }
}