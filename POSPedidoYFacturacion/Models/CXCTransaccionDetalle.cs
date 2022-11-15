using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSPedidoYFacturacion.Models
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

        public decimal BalanceAntes { get; set; }

        public decimal MontoAAplicar { get; set; }

        public decimal BalanceDespues { get; set; }
    }
}