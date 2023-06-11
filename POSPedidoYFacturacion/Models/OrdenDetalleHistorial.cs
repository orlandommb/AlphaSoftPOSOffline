using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AlphaSoftPOSOffline.Models
{
    public class OrdenDetalleHistorial
    {
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public Orden Orden { get; set; }
        public DateTime Fecha { get; set; }
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public string Accion { get; set; }

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