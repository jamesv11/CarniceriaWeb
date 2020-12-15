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
    

    public class DomiciliarioViewModel : DomiciliarioInputModel {

        public DomiciliarioViewModel (){}
        public DomiciliarioViewModel(Domiciliario domiciliario){    
              Persona = domiciliario.Persona;           
        }
    }
    public class ClienteValidacion : ValidationAttribute
    {
        protected override ValidationResult IsValid(Object value, ValidationContext validationContext)
        {
            Persona personaValidacion = (Persona) value;
            string respuesta = "";

            if (string.IsNullOrEmpty(personaValidacion.Apellido)  )
            {
                respuesta += "\n EL campo apellido no puede estar vacio";
            }
            if(string.IsNullOrEmpty(personaValidacion.Correo)){
                respuesta += "\n EL campo de correo electronico no puede estar vacio";
            }
            if(string.IsNullOrEmpty(personaValidacion.Nombre)){
                respuesta += "\nEL campo Nombre no puede estar vacio";
            }
            if(string.IsNullOrEmpty(personaValidacion.Password)){
                respuesta += "\nEL campo Contraseña no puede estar vacio";
            }
            if(respuesta.Equals("")){
                return ValidationResult.Success;
            }
            return new ValidationResult(ErrorMessage=respuesta);
        }
    }


}