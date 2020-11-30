using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyectocarniceria.Models
{
      public class ClienteInputModel
    {

        public int PersonaID {get;set;}
        public string Nombre {get;set;}
        public string Apellido {get;set;}
        public string Correo {get;set;}
        public string Password {get;set;}

         
    }

    public class ClienteViewModel : ClienteInputModel {

        public ClienteViewModel (){}
        public ClienteViewModel(Cliente cliente){     
                  
        }
    }
}