using System;
using System.Collections.Generic;
using Datos;
using Entidad;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class ClienteServicio
    {
        private readonly CarniceriaContext _context;

        public ClienteServicio(CarniceriaContext context)
        {
            _context = context;
        }

        public GuardarClienteResponse Guardar(Cliente cliente)
        {
            try
            {
                var verificarCliente = _context.Clientes.Find(cliente.Correo);
                if(verificarCliente != null)
                {
                    return new GuardarClienteResponse("Error el cliente se encuentra registrado ");
                }                  
                    _context.Clientes.Add(cliente);
                    _context.SaveChanges();
                    return new GuardarClienteResponse(cliente);
            }
            catch (Exception e)
            {
                return new GuardarClienteResponse($"Error de la Aplicacion: {e.Message}");
            }
        }

        public ConsultarClientesResponse Consultar(){
            try
            {
                var clientes = _context.Clientes.Include(p => p.Persona).ToList();
                return new ConsultarClientesResponse(clientes);
            }
            catch (Exception e)
            {
                return new ConsultarClientesResponse($"error de aplicacion :  {e.Message}");
            }
        }

        public BuscarClienteResponse buscarCliente(int clienteIdentificacion){
            try
            {
                var cliente = _context.Clientes.Find(clienteIdentificacion);
                return new BuscarClienteResponse(cliente);
            }
            catch (Exception e)
            {
                
                return new BuscarClienteResponse($"Error de aplicacion: {e.Message}");
            }
        }
    }

    public class GuardarClienteResponse
    {
        public GuardarClienteResponse(Cliente cliente )
        {
            Error = false;
            Cliente = Cliente;
        }
        public GuardarClienteResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Cliente Cliente { get; set; }
    }
    public class ConsultarClientesResponse
    {
        public ConsultarClientesResponse(List<Cliente> clientes)
        {
            Error = false;
            Clientes = clientes;
        }
        public ConsultarClientesResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<Cliente> Clientes { get; set; }
    }
    public class BuscarClienteResponse
    {
        public BuscarClienteResponse(Cliente cliente)
        {
            Error = false;
            Cliente = cliente;
        }
        public BuscarClienteResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Cliente Cliente { get; set; }
    }
}