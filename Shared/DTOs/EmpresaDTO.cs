using System;

namespace Shared.DTOs
{
    public class EmpresaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Logo { get; set; }
        public bool UsarPOSRestaurant { get; set; }
        public bool ImprimirLogoEnOrden { get; set; }
        public bool ImprimirLogoEnFactura { get; set; }
        public decimal MontoMinimoDelivery { get; set; }
        public int TipoOrdenPredeterminada { get; set; }
        public DateTime FechaVencimientoServicio { get; set; }
    }
}