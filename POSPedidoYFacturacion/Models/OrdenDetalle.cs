using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSPedidoYFacturacion.Models
{
    public class OrdenDetalle
    {

        public int Id { get; set; }

        public int OrdenId { get; set; }

        [ForeignKey(nameof(OrdenId))]
        public Orden Orden { get; set; }

        public int ProductoId { get; set; }

        [ForeignKey(nameof(ProductoId))]
        public Producto Producto { get; set; }

        public string NombreProducto { get; set; }

        public int Cantidad { get; set; }

        public decimal Descuento { get; set; }

        public decimal Precio { get; set; }

        public decimal Importe { get; set; }

    }
}
