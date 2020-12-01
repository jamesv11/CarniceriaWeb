using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Entidad
{
    public class Domiciliario
    {
        public int DomiciliarioId {get;set;}

        
        //Relacion con la entidad Persona

        public Persona Persona { get; set; }

        //Relacion con la clase Documentos
        public List<Documento> Documentos  {get;set;}
        //Relacion con la clase pedidos
        public List<Pedido> Pedidos {get;set;}
        public Domiciliario()
        {
            this.Persona.Rol = "Domiciliario";
        }
        
        
    }
}