using Microsoft.EntityFrameworkCore;
using System;
namespace POSPedidoYFacturacion.Models
{
    public class Sector
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal MontoDelivery { get; set; }

    }
}
