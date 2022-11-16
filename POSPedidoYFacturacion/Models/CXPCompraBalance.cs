using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace POSPedidoYFacturacion.Models
{
    public class CXPCompraBalance
    {
        public int Id { get; set; }

        [Required]
        public int CompraId { get; set; }

        [ForeignKey("CompraId")]
        public Compra Compra { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal Balance { get; set; }
    }
}