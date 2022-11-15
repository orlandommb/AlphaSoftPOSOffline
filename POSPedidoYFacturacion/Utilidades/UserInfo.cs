using System.ComponentModel.DataAnnotations;

namespace  POSPedidoYFacturacion
{
    public class UserInfo
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

    }
}