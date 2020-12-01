using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Logica
{
    public class ClienteServicio
    {
        private readonly CarniceriaContext _context;

        public ClienteServicio(CarniceriaContext context)
        {
            _context = context;
        }

        public GuardarPersonaResponse Guardar(Cliente cliente)
        {
            try
            {
                var verificarCliente = _context.Clientes.Find(cliente.Persona.PersonaId);
                if(verificarCliente != null)
                {
                    return new GuardarPersonaResponse("Error el cliente se encuentra registrado ");
                }
                    _context.Clientes.Add(cliente);
                    _context.SaveChanges();
                    return new GuardarPersonaResponse(cliente);
            }
            catch (Exception e)
            {
                return new GuardarPersonaResponse($"Error de la Aplicacion: {e.Message}");
            }
        }

        public ConsultarClientesResponse Consultar(){
            try
            {
                var clientes = _context.Clientes.ToList();
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

    public class GuardarPersonaResponse
    {
        public GuardarPersonaResponse(Cliente cliente )
        {
            Error = false;
            Cliente = Cliente;
        }
        public GuardarPersonaResponse(string mensaje)
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