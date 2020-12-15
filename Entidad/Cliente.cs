using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace Entidad
{
    public class Cliente
    {
        public string Correo { get; set; }
      

        [Column(TypeName = "decimal(12,2)")]
        public double ValorDescuento { get; set; }

        //Relacion con la entidad Persona      
        public virtual Persona Persona { get; set; }
    }
}