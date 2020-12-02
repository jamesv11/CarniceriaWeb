using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyectocarniceria.Models
{
      public class ClienteInputModel
    {
        public Persona Persona { get; set; }    
    }

    public class ClienteViewModel : ClienteInputModel {

        public decimal ValorDescuento { get; set; }

        //Relacion con la entidad Persona
      
        public ClienteViewModel (){}
        public ClienteViewModel(Cliente cliente){     
           
            ValorDescuento = cliente.ValorDescuento;
            Persona = cliente.Persona;

        }
    }
}