using System.Net.Http.Headers;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyectocarniceria.Models
{
      public class  ImagenProductoInputModel
    {

        public int ImagenProductoID {get;set;}
        public byte[] Imagen {get;set;}

         
    }

    public class ImagenProductoViewModel  : ImagenProductoInputModel {

        public ImagenProductoViewModel   (){}
        public ImagenProductoViewModel  (ImagenProducto imagenProducto){
            
            ImagenProductoID = imagenProducto.ImagenProductoID;
            Imagen = imagenProducto.Imagen;
            
        }
    }
}