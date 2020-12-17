using System.ComponentModel;
using System.Transactions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Datos;
using Entidad;

namespace Logica
{
    public class ProductoServicio
    {
        private readonly CarniceriaContext _context;
        public ProductoServicio(CarniceriaContext context)
        {
            _context = context;

        }

        public GuardarProductoResponse Guardar(Producto producto)
        {
            try
            {
                _context.Productos.Add(producto);
                _context.SaveChanges();
                return new GuardarProductoResponse(producto);
            }
            catch (Exception e)
            {
                return new GuardarProductoResponse($"Error de la Aplicacion: {e.Message}");
            }
        }

        public Producto BuscarProductoId(int id)
        {
            return _context.Productos.Find(id);
        }

        public Boolean VerificaExistencia(int id, int cantidad)
        {
            var producto = BuscarProductoId(id);
            if (producto.Cantidad >= cantidad) return true;
            return false;
        }

        public ModificarProductoResponse UpdateLista(List<Producto> productos)
        {
            try
            {

                using (var scope = _context.Database.BeginTransaction() )
                {
                    foreach (var item in productos)
                    {
                        UpdateProducto(item);
                    }
                    scope.Commit();
                }

                    

                return new ModificarProductoResponse(_context.Productos.ToList());


            }
            catch (Exception e)
            {
                return new ModificarProductoResponse("Error de aplicacion"+ e);
            }
        }

        private void UpdateProducto(Producto _producto)
        {
            var producto = _context.Productos.Find(_producto.ProductoId);
            if(producto!=null){
                producto.Cantidad = _producto.Cantidad;
                producto.ValorUnitario = _producto.ValorUnitario;
                _context.Productos.Update(producto);
                _context.SaveChanges();
            }

        }

        public ConsultarProductoResponsive ConsultarTodos()
        {
            try
            {


                var producto = _context.Productos.ToList();
                return new ConsultarProductoResponsive(producto);

            }
            catch (Exception e)
            {
                return new ConsultarProductoResponsive($"error de aplicacion: {e.Message}");
            }

        }
        public ConsultarCarneResponsive ConsultarTodasRes()
        {
            try
            {


                var carnes = _context.ProductoCarnes.ToList();
                return new ConsultarCarneResponsive(carnes);

            }
            catch (Exception e)
            {
                return new ConsultarCarneResponsive($"error de aplicacion: {e.Message}");
            }

        }

        public Boolean Modificar(Producto productoNuevo)
        {
            try
            {
                var productoViejo = _context.Productos.Where(p => p.ProductoId == productoNuevo.ProductoId).FirstOrDefault();
                if (productoViejo != null)
                {
                    productoViejo.Cantidad = productoNuevo.Cantidad;
                    _context.Productos.Update(productoNuevo);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public GuardarProductoCarneResponse GuardarCarne(ProductoCarne productoCarne)
        {
            try
            {
                _context.ProductoCarnes.Add(productoCarne);
                _context.SaveChanges();
                return new GuardarProductoCarneResponse(productoCarne);
            }
            catch (Exception e)
            {
                return new GuardarProductoCarneResponse($"Error de la Aplicacion: {e.Message}");
            }
        }


    }

    public class GuardarProductoResponse
    {
        public GuardarProductoResponse(Producto _producto)
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

    public class ModificarProductoResponse
    {
        public ModificarProductoResponse(List<Producto> _producto)
        {
            Error = false;
            productos = _producto;
        }
        public ModificarProductoResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<Producto> productos { get; set; }
    }

    public class GuardarProductoCarneResponse
    {
        public GuardarProductoCarneResponse(ProductoCarne _producto)
        {
            Error = false;
            producto = _producto;
        }
        public GuardarProductoCarneResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public ProductoCarne producto { get; set; }
    }

    public class ConsultarProductoResponsive
    {
        public ConsultarProductoResponsive(List<Producto> _productos)
        {
            Error = false;
            Productos = _productos;
        }
        public ConsultarProductoResponsive(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<Producto> Productos { get; set; }
    }
    public class ConsultarCarneResponsive
    {
        public ConsultarCarneResponsive(List<ProductoCarne> _productos)
        {
            Error = false;
            Productos = _productos;
        }
        public ConsultarCarneResponsive(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<ProductoCarne> Productos { get; set; }
    }

}