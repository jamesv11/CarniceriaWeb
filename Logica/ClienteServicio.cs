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

        public Cliente Validate(string correo, string password) 
        {
            return _context.Clientes.Include(p => p.Persona).Where(t => t.Persona.Correo == correo && t.Persona.Password == password).FirstOrDefault();
        }
        public GuardarClienteResponse Guardar(Cliente cliente)
        {
            try
            {
                var verificarCliente = _context.Clientes.Find(cliente.Persona.Correo);
                if(verificarCliente != null)
                {
                    return new GuardarClienteResponse("Error el cliente se encuentra registrado ");
                }
                 cliente.Persona.Rol = "Rol.Cliente";
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

        public BuscarClienteResponse buscarCliente(string correo){
            try
            {
                var cliente = _context.Clientes.Include(p => p.Persona).Where(p => p.Persona.Correo ==  correo).FirstOrDefault();
                return new BuscarClienteResponse(cliente);
            }
            catch (Exception e)
            {
                
                return new BuscarClienteResponse($"Error de aplicacion: {e.Message}");
            }
        }

        public ModificarClienteResponse Modificar(Cliente clienteNuevo){
            try{
                var clienteViejo = _context.Clientes.Include(p => p.Persona).Where(p => p.Persona.Correo ==  clienteNuevo.Persona.Correo).FirstOrDefault();
                if(clienteViejo != null)
                {
                    clienteViejo.Persona.Correo = clienteNuevo.Persona.Correo;
                    clienteViejo.Persona.Nombre = clienteNuevo.Persona.Nombre;
                    clienteViejo.Persona.Apellido = clienteNuevo.Persona.Apellido;
                    clienteViejo.Persona.Password = clienteNuevo.Persona.Password;
                    clienteViejo.Persona.Direccion = clienteNuevo.Persona.Direccion;
                    clienteViejo.Persona.Telefono = clienteNuevo.Persona.Telefono;
                    clienteViejo.Persona.Rol = clienteNuevo.Persona.Rol;
                    clienteViejo.ValorDescuento = clienteNuevo.ValorDescuento;
                    _context.Clientes.Update(clienteViejo);
                    _context.SaveChanges();
                    return new ModificarClienteResponse(clienteViejo);
                }
                else{
                    return new ModificarClienteResponse($"Lo sentimos no se encuentra registrada la persona : {clienteViejo.Correo}");
                }
            }
            catch (Exception e)
            {
                return new ModificarClienteResponse($"Error de aplicacion: {e.Message}");
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

    public class ModificarClienteResponse
    {
        public ModificarClienteResponse(Cliente cliente )
        {
            Error = false;
            Cliente = Cliente;
        }
        public ModificarClienteResponse(string mensaje)
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