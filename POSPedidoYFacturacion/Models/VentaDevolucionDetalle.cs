using Microsoft.EntityFrameworkCore;
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
        [Precision(precision: 18, scale: 2)]
        public decimal Precio { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal Subtotal { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal Descuento { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal Impuesto { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal Total { get; set; }
        public string Observaciones { get; set; }
    }

}