using System;
using System.ComponentModel.DataAnnotations;

namespace AlphaSoftPOSOffline.Models
{
    public class TipoFactura
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio!")]
        public string Nombre { get; set; }
    }
}