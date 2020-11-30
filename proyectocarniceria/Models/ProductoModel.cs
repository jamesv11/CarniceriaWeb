using System.Net.Http.Headers;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyectocarniceria.Models
{
      public class  ProductoInputModel
    {

        public string NombreProducto {get; set;}
        public ImagenProducto ImagenProducto {get; set;}
        public decimal CantidadEnStock {get; set;}
        public decimal ValorUnitario{get; set;}
        public string descripcion {get;set;}
        public string Categoria {get;set;}
        public string Tag {get;set;}
        public int ImagenProductoID {get;set;}

         
    }

    public class ProductoViewModel : ProductoInputModel {

        public ProductoViewModel  (){}
        public ProductoViewModel (Producto producto){
            
        }
    }
}