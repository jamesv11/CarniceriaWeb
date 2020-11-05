using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Logica
{
    public class ImagenProductoServicio
    {
        private readonly CarniceriaContext _context;

        public ImagenProductoServicio(CarniceriaContext context)
        {
            _context = context;
        }

        public GuardarImagenResponse Guardar(ImagenProducto imagenProducto)
        {
            try
            {
                _context.ImagenesProductos.Add(imagenProducto);
                _context.SaveChanges();
                var LastRegister = _context.ImagenesProductos
                .OrderByDescending(x => x.ImagenProductoID)
                .First().ImagenProductoID;
                return new GuardarImagenResponse(LastRegister);
            }
            catch (Exception e)
            {
                return new GuardarImagenResponse($"Error de la Aplicacion: {e.Message}");
            }
        }


        public int ultimoId(){
            var LastRegister = _context.ImagenesProductos
                .OrderByDescending(x => x.ImagenProductoID)
                .First().ImagenProductoID;
            return LastRegister;
        }
        public ImagenProducto BuscarImagenID(int ID){
            return _context.ImagenesProductos.Find(ID);

        }
    }

    public class GuardarImagenResponse
    {
        public GuardarImagenResponse(int id )
        {
            Error = false;
            ID  = id;
        }
        public GuardarImagenResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public int ID { get; set; }
    }

    public class ConsultarImagenResponse
    {
        public ConsultarImagenResponse(ImagenProducto _imagenProducto )
        {
            Error = false;
            ImagenProducto  = _imagenProducto;
        }
        public ConsultarImagenResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public ImagenProducto ImagenProducto { get; set; }
    }


}