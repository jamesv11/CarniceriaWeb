using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace proyectocarniceria.Models
{
    public class ClienteInputModel
    {
      //  [PersonaValidacion ]
        public Persona Persona { get; set; }

    }

    public class ClienteViewModel : ClienteInputModel
    {
        
        public decimal ValorDescuento { get; set; }

        //Relacion con la entidad Persona

        public ClienteViewModel() { }
        public ClienteViewModel(Cliente cliente)
        {

            ValorDescuento = cliente.ValorDescuento;
            Persona = cliente.Persona;

        }
    }

    public class PersonaValidacion : ValidationAttribute
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