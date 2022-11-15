using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSPedidoYFacturacion.Models
{
    public class CompraDetalle
    {
        public int Id { get; set; }

        [Display(Name = "Compra")]
        public int CompraId { get; set; }

        [ForeignKey("CompraId")]
        public Compra Compra { get; set; }

        [Display(Name = "Producto")]
        public int ProductoId { get; set; }

        [ForeignKey("ProductoId")]
        public Producto Producto { get; set; }

        public int Cantidad { get; set; }

        public string Nombre { get; set; }

        public decimal Descuento { get; set; }

        public decimal ITBIS { get; set; }

        //[Display(Name = "Tipo de ITBIS")]
        //public int TipoITBISId { get; set; }

        //[ForeignKey("TipoITBISId")]
        //public virtual TipoITBIS TipoITBIS { get; set; }

        [Required]
        public decimal Costo { get; set; }

        [Required]
        public decimal Importe { get; set; }
    }
}