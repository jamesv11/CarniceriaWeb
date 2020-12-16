using System.Net.Http.Headers;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace proyectocarniceria.Models
{
      public class  ProductoResInputModel
    {
        public string NombreProducto {get; set;}
        public int Cantidad{get; set;}
        public float ValorUnitario{get; set;}
        public string Descripcion {get;set;} 
        public string Categoria {get;set;}
        public string ImagenProducto {get;set;}
        public string CorteRes { get; set; }

         
    }

    public class ProductoResViewModel : ProductoResInputModel {

        public ProductoResViewModel  (){}
        public ProductoResViewModel (ProductoCarne producto){
            NombreProducto = producto.NombreProducto;
            Cantidad = producto.Cantidad;
            ValorUnitario = producto.ValorUnitario;
            Descripcion = producto.Descripcion;
            Categoria = producto.Categoria;
            ImagenProducto = producto.ImagenProducto;
            CorteRes = producto.CorteRes;
        }
    }
}