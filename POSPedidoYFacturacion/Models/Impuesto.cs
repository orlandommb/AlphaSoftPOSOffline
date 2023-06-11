using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace AlphaSoftPOSOffline.Models
{
    public class Impuesto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Nombre { get; set; }

        [Required]
        [Precision(precision: 18, scale: 2)]
        public decimal Valor { get; set; }

    }
}