using System;
using System.ComponentModel.DataAnnotations;

namespace POSPedidoYFacturacion.Models
{
    public class ImpuestoTipo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Maximo de 10 caracteres")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Maximo de 100 caracteres")]
        public string Descripcion { get; set; }

    }
}