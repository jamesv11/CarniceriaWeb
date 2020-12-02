using System.Security.Principal;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Producto
    {
        public int ProductoId {get; set;}
        public string NombreProducto { get; set; }
        public string Description {get; set;}
        public int Cantidad {get; set;}
        [Column(TypeName = "decimal(12,2)")]
        public decimal ValorUnitario{get; set;}
        public string Categoria {get;set;}
        
        //relacion con la clase ImagenProducto
        public int ImagenProductoId {get;set;}
        

        
    }
}