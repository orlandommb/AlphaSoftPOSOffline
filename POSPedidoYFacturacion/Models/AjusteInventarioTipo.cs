using System.ComponentModel.DataAnnotations;

namespace POSPedidoYFacturacion.Models
{
    public class AjusteInventarioTipo
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Nombre { get; set; }

        [MaxLength(200)]
        public string Descripcion { get; set; }
    }
}