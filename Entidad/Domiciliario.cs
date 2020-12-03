using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Entidad
{
    public class Domiciliario
    {
        
        public string Correo { get; set; }
        public virtual Persona Persona { get; set; }
        //Relacion con la clase Documentos
        //public List<Documento> Documentos  {get;set;}
                
    }
}