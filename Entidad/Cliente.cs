using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace Entidad
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal ValorDescuento { get; set; }

        public Cliente(){this.Persona.Rol = "Cliente"; }

        //Relacion con la entidad Persona
        public Persona Persona { get; set; }

        //Relacion con factura
        public List<Factura> Facturas {get;set;}

        
    }
}