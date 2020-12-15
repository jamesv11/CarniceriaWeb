using System.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class FacturaService
    {
        private readonly CarniceriaContext _context;
        private readonly ProductoServicio productoServicio;
        private readonly ClienteServicio clienteServicio;
        public FacturaService(CarniceriaContext context)
        {
            _context = context;
            productoServicio = new ProductoServicio(_context);
            clienteServicio = new ClienteServicio(_context);
            

        }

        
        public ConsultarFacturaResponse ConsultarTodos()
        {
            try
            {
                var facturas = _context.Facturas.Include(p => p.DetallesFacturas).ToList();
                return new ConsultarFacturaResponse(facturas);
            }
            catch (Exception e)
            {
                return new ConsultarFacturaResponse($"error de aplicacion: {e.Message}");
            }

        }


        public GuardarFacturaResponse GuardarFactura(Factura factura){
           
            try
            {
                 using(TransactionScope scope = new TransactionScope()){

                    var cliente = clienteServicio.buscarCliente(factura.Correo);
                    factura.PorcentajeDescuento = cliente.Cliente.ValorDescuento;           
                    ArmarFactura(factura);
                    _context.Facturas.Add(factura); 
                    GeneraPedido(factura);
                     RestaProducto(factura.DetallesFacturas);
                    _context.SaveChanges(); 
                    scope.Complete();
                 }
 
                    
                return new GuardarFacturaResponse(factura);

            }
            catch (Exception e)
            {
                
                return new GuardarFacturaResponse($"Error de la Aplicacion: {e}");

            }
        }

        public void ArmarFactura(Factura factura){

            factura.FechaExpedicion = DateTime.Now;
            factura.EstadoFactura = Estado.Pendiente.ToString();
            AsignarPrecioUnitario(factura.DetallesFacturas);
            factura.CalcularDetalles();
            factura.CalcularSubtotal();
            factura.CalcularValorTotal();
        }
        

        public void AsignarPrecioUnitario(List<DetalleFactura> detalleFacturas){

           foreach(DetalleFactura item in detalleFacturas)
           {
                Producto producto = this.productoServicio.BuscarProductoId(item.ProductoId);
                if(producto != null)
                {
                    item.ValorUnitario = producto.ValorUnitario;
                }
           }
        }

        public RespuestaVerificar VerificarExistencias(List<DetalleFactura> detalleFacturas)
        {
            
            foreach(DetalleFactura item in detalleFacturas)
           {
                Producto producto = this.productoServicio.BuscarProductoId(item.ProductoId);
                if(item.CantidadRequerida > producto.Cantidad)
                {
                    return new RespuestaVerificar( $"\n La cantidad requerida del producto ({producto.NombreProducto}) no se encuentra disponible");
                }
                else
                {
                    return new RespuestaVerificar(detalleFacturas);
                }
           }

           return new RespuestaVerificar( $"Error de la aplicacion no entro ni siquiera el foreach");
        }

       
        public void GeneraPedido(Factura factura){
            var NuevoPedido = new Pedido();
            NuevoPedido.Factura = factura;
            _context.Pedidos.Add(NuevoPedido);
                 
        }

        public void RestaProducto(List<DetalleFactura> detallesFactura){

            foreach (var item in detallesFactura)
            {
                var producto = productoServicio.BuscarProductoId(item.ProductoId);
                producto.restarCantidad(item.CantidadRequerida);
                this.productoServicio.Modificar(producto);
            }

        }

        
        


    }

    public class RespuestaVerificar{
        public RespuestaVerificar(List<DetalleFactura> _listaDetalle){
            error = false;
            listaDetalle = _listaDetalle;
        }
        public RespuestaVerificar(string stringError){
            error = true;
            respuesta = stringError;
        }

        public string respuesta { get; set; }
        public Boolean error { get; set; }
        public List<DetalleFactura> listaDetalle  { get; set; }
    }

    public class GuardarFacturaResponse{
        public GuardarFacturaResponse(Factura _factura ){
            error = false;
            factura = _factura;
        }
        public GuardarFacturaResponse(string stringError){
            error = true;
            respuesta = stringError;
        }

        public string respuesta { get; set; }
        public Boolean error { get; set; }
        public Factura factura  { get; set; }
    }
    public class ConsultarFacturaResponse{
        public ConsultarFacturaResponse(List<Factura> _facturas){
            Error = false;
            Facturas = _facturas;
        }
        public ConsultarFacturaResponse(string stringError){
            Error = true;
            Respuesta = stringError;
        }

        public string Respuesta { get; set; }
        public Boolean Error { get; set; }
        public List<Factura> Facturas  { get; set; }
    }

    

}