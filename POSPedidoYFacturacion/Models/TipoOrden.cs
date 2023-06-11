using System;
using System.Collections.Generic;

namespace AlphaSoftPOSOffline.Models
{
    public class TipoOrden
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Venta> Ventas { get; set; }
    }
}
