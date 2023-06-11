using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaSoftPOSOffline.Models
{
    public class CXCTransaccionDetalle
    {
        public int Id { get; set; }
        
        public int CXCTransaccionId { get; set; }
        
        [ForeignKey("CXCTransaccionId")]
        public CXCTransaccion CXCTransaccion { get; set; }
        
        public int VentaId { get; set; }

        [ForeignKey("VentaId")]
        public Venta Venta { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal BalanceAntes { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal MontoAAplicar { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal BalanceDespues { get; set; }
    }
}