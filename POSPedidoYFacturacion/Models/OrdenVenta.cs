using System;
namespace POSPedidoYFacturacion.Models
{
    public class OrdenVenta
    {
        public int Id { get; set; }

        public int OrdenId { get; set; }
        public Orden Orden { get; set; }

        public int VentaId { get; set; }
        public Venta Venta { get; set; }

    }
}
