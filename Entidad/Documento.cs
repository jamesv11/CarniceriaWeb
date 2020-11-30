using System;
using System.ComponentModel.DataAnnotations;
namespace Entidad
{
    public class Documento
    {
        public int DocumentoId {get;set;}
        public string Nombre { get; set; }

        //Relacion con la entidad Domiciliario uno a muchos     
        public string DomiciliarioId {get;set;}
        public Domiciliario Domiciliario {get;set;} 
    }
}