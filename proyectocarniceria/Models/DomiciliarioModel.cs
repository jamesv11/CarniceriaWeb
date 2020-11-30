using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyectocarniceria.Models
{
      public class  DomiciliarioInputModel
    {

         public int DomiciliarioID {get;set;}
        public string Identificacion {get;set;}
         
        public string Nombre { get; set; }
        public string Apellido {get;set;}
        public string Correo {get;set;}
        public string Telefono {get;set;}

         
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
            
            Identificacion = domiciliario.Identificacion;
            Correo = domiciliario.Correo;
            Telefono = domiciliario.Telefono;           
        }
    }
}