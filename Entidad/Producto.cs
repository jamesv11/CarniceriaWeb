using System.ComponentModel.DataAnnotations;
using System;

namespace Entidad
{
    public class Producto
    {
        public int ProductoID {get; set;}
        public string NombreProducto {get; set;}
        public decimal CantidadEnStock {get; set;}
        public decimal ValorUnitario{get; set;}
        public string descripcion {get;set;}
        public string Categoria {get;set;}
        public string Tag {get;set;}
        


        public int DetalleID {get; set;}
        public DetalleFactura DetalleFactura {get; set;}
        public int ImagenProductoID {get;set;}
        

        
    }
}