using System;
using System.ComponentModel.DataAnnotations;

namespace POSPedidoYFacturacion.Models
{
    public class Impuesto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Nombre { get; set; }

        [Required]
        public decimal Valor { get; set; }

    }
}