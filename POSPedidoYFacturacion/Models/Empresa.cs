using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSPedidoYFacturacion.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        [StringLength(maximumLength:100, ErrorMessage ="Solo se aceptan hasta 100 caracteres", MinimumLength = 5)]
        public string Nombre { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }
        [StringLength(maximumLength: 150, ErrorMessage = "Solo se aceptan hasta 150 caracteres", MinimumLength = 5)]
        public string Direccion { get; set; }
        public string Logo { get; set; }
        public bool UsarPOSRestaurant { get; set; }
        public bool ImprimirLogoEnOrden { get; set; }
        public bool ImprimirLogoEnFactura { get; set; }
        [Column(TypeName ="decimal(18, 2)")]
        public decimal MontoMinimoDelivery { get; set; }
        public int TipoOrdenPredeterminada { get; set; }
        public DateTime FechaVencimientoServicio { get; set; }

    }
}
