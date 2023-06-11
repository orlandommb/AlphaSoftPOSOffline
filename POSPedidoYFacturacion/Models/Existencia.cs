using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaSoftPOSOffline.Models
{
    public class Existencia
    {
        public int  Id { get; set; }
        public int AlmacenId { get; set; }
        [ForeignKey("AlmacenId")]
        public Almacen Almacen { get; set; }
        public int ProductoId { get; set; }
        [ForeignKey("ProductoId")]
        public Producto Producto { get; set; }

        public double Cantidad { get; set; }
    }
}
