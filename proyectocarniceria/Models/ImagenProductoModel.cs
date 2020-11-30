using System.IO;
using System.Drawing;
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

    public class ImagenProductoViewModel   {
        public int ImagenProductoID {get;set;}
        public Image Imagen {get;set;}

        public ImagenProductoViewModel   (){}
        public ImagenProductoViewModel  (int imagenProductoID, Image  imagen){
            
            ImagenProductoID = imagenProductoID;
            Imagen = imagen;
            
        }

        
    }
}