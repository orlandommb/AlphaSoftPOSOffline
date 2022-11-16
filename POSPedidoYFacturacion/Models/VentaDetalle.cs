using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSPedidoYFacturacion.Models
{
    public class VentaDetalle
    {
        public int Id { get; set; }

        public int VentaId { get; set; }

        [ForeignKey(nameof(VentaId))]
        public Venta Venta { get; set; }

        public int ProductoId { get; set; }

        [ForeignKey(nameof(ProductoId))]
        public Producto Producto { get; set; }

        public string NombreProducto { get; set; }

        public int Cantidad { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal Descuento { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal Precio { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal Importe { get; set; }
    }
}
