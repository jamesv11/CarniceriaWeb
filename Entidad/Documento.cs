using System.Reflection;
using System;
using System.ComponentModel.DataAnnotations;
namespace Entidad
{
    public class Documento
    {
        public int DocumentoId {get;set;}
        public byte[] DomiciliarioDocumento { get; set; }
    }
}