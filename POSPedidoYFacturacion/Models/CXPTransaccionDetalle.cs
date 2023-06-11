using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaSoftPOSOffline.Models
{
    public class CXPTransaccionDetalle
    {
        public int Id { get; set; }
        
        public int CXPTransaccionId { get; set; }
        
        [ForeignKey("CXPTransaccionId")]
        public CXPTransaccion CXPTransaccion { get; set; }
        
        public int CompraId { get; set; }

        [ForeignKey("CompraId")]
        public Compra Compra { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal BalanceAntes { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal MontoAAplicar { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal BalanceDespues { get; set; }
    }
}