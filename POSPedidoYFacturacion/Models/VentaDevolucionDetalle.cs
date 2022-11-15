using System;

namespace POSPedidoYFacturacion.Models
{
    public class VentaDevolucionDetalle
    {
        public int Id { get; set; }
        
        public int VentaDevolucionId { get; set; }
        public VentaDevolucion VentaDevolucion { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        public int CantidadVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }
        public string Observaciones { get; set; }
    }

}