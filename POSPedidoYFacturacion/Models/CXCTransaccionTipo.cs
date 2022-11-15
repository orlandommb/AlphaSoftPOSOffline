using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSPedidoYFacturacion.Models
{
    public class CXCTransaccionTipo
    {
        public int Id { get; set; }
        
        [StringLength(maximumLength:30,ErrorMessage = "Solo debe contener 30 caracteres!")]
        [Required(ErrorMessage = "Nombre es obligatorio!")]
        public string Nombre { get; set; }
    }
}