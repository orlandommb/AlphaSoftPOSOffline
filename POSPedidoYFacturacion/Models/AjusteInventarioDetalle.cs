using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaSoftPOSOffline.Models
{
    public class AjusteInventarioDetalle
    {
        public int Id { get; set; }

        [Display(Name = "AjusteInventario")]
        public int AjusteInventarioId { get; set; }

        [ForeignKey("AjusteInventarioId")]
        public AjusteInventario AjusteInventario { get; set; }

        [Display(Name = "Producto")]
        public int ProductoId { get; set; }

        [ForeignKey("ProductosId")]
        public Producto Producto { get; set; }

        public double Cantidad { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal Costo { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal Importe { get; set; }
    }
}