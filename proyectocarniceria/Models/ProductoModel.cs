using System.Net.Http.Headers;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace proyectocarniceria.Models
{
      public class ProductoInputModel
    {
        [Required(ErrorMessage = "El nombre del producto no puede estar vacio")]
        public string NombreProducto {get; set;}
        // [Range(0,900,ErrorMessage="Please enter correct value")]
        public string Descripcion {get;set;}
        public int Cantidad {get; set;}
        public float ValorUnitario{get; set;}       
        public string Categoria {get;set;}
        public string ImagenProducto {get;set;}

         
    }

    public class ProductoViewModel  {
            public int ProductoId { get; set; }
            public string NombreProducto { get; set; }
            public string Descripcion { get; set; }
            public int Cantidad { get; set; }
            public float ValorUnitario { get; set; }
            public string Categoria { get; set; }
            public string ImagenProducto { get; set; }
        public ProductoViewModel  (){}
        public ProductoViewModel (Producto producto){         
            NombreProducto = producto.NombreProducto;
            Descripcion = producto.Descripcion;
            Cantidad = producto.Cantidad;
            ValorUnitario = producto.ValorUnitario;
            Categoria = producto.Categoria;
            ImagenProducto =  producto.ImagenProducto;
            ProductoId = producto.ProductoId;
        }
    }
}