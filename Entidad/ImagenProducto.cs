using System;
using System.ComponentModel.DataAnnotations;
namespace Entidad
{
    public class ImagenProducto
    {
        public int ImagenProductoId {get;set;}
        public byte[] Imagen {get;set;}
    }
}