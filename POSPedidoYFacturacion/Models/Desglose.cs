using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSPedidoYFacturacion.Models
{
    public class Desglose
    {
        public int Id { get; set; }

        public int CuadreId { get; set; }

        [ForeignKey(nameof(CuadreId))]
        public Cuadre Cuadre { get; set; }

        public int DenominacionId { get; set; }

        [ForeignKey(nameof(DenominacionId))]
        public Denominacion Denominacion { get; set; }

        public int Cantidad { get; set; }

        public decimal Total { get; set; }

    }
}
