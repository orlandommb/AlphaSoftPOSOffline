using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaSoftPOSOffline.Models
{
    public class Denominacion
    {
        public int Id { get; set; }

        public int TipoMonedaId { get; set; }

        [ForeignKey(nameof(TipoMonedaId))]
        public TipoDenominacion TipoMoneda { get; set; }

        public int Valor { get; set; }

    }
}
