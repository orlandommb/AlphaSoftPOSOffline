using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSPedidoYFacturacion.Models
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

        public decimal BalanceAntes { get; set; }

        public decimal MontoAAplicar { get; set; }

        public decimal BalanceDespues { get; set; }
    }
}