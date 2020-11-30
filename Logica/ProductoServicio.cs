using System;
using System.Collections.Generic;
using Datos;
using Entidad;

namespace Logica
{
    public class ProductoServicio
    {
        private readonly CarniceriaContext _context;
        private readonly ImagenProductoServicio imagenProductoServicio;
        public ProductoServicio(CarniceriaContext context)
        {
            _context = context;
            imagenProductoServicio =  new ImagenProductoServicio(context);
        }

        public GuardarProductoResponse Guardar(Producto producto)
        {
            try
            {
                 if(producto.ImagenProductoId==0){
                     producto.ImagenProductoId = imagenProductoServicio.ultimoId();
                 }

                _context.Productos.Add(producto);
                _context.SaveChanges();
                return new GuardarProductoResponse(producto);
            }
            catch (Exception e)
            {
                return new GuardarProductoResponse($"Error de la Aplicacion: {e.Message}");
            }
        }


    }

    public class GuardarProductoResponse
    {
        public GuardarProductoResponse(Producto _producto )
        {
            Error = false;
            producto = _producto;
        }
        public GuardarProductoResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Producto producto { get; set; }
    }

    // public class ConsultarClientesResponse
    // {
    //     public ConsultarClientesResponse(List<Cliente> clientes)
    //     {
    //         Error = false;
    //         Clientes = Clientes;
    //     }
    //     public ConsultarClientesResponse(string mensaje)
    //     {
    //         Error = true;
    //         Mensaje = mensaje;
    //     }
    //     public bool Error { get; set; }
    //     public string Mensaje { get; set; }
    //     public List<Cliente> Clientes { get; set; }
    // }
    // public class BuscarClienteResponse
    // {
    //     public BuscarClienteResponse(Cliente cliente)
    //     {
    //         Error = false;
    //         Cliente = cliente;
    //     }
    //     public BuscarClienteResponse(string mensaje)
    //     {
    //         Error = true;
    //         Mensaje = mensaje;
    //     }
    //     public bool Error { get; set; }
    //     public string Mensaje { get; set; }
    //     public Cliente Cliente { get; set; }
    // }
}