using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace proyectocarniceria.Models
{
      public class  DomiciliarioInputModel
    {   
        [PersonaValidacion ]
        public Persona Persona { get; set; }
               
    }
     /*identificacion:string;     
    nombre:string;
    apellido:string;
    correo:string;
    telefono:string; 
    documentos:Documento[]; 
  */

    public class DomiciliarioViewModel : DomiciliarioInputModel {

        public DomiciliarioViewModel (){}
        public DomiciliarioViewModel(Domiciliario domiciliario){    
              Persona = domiciliario.Persona;           
        }
    }


}