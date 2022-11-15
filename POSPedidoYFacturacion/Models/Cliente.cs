using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSPedidoYFacturacion.Models
{
    public class Cliente
    {
        public int EmpresaId { get; set; }

        [ForeignKey("EmpresaId")]
        public Empresa Empresa { get; set; }
        
        public int SucursalId { get; set; }

        [ForeignKey("SucursalId")]
        public Sucursal Sucursal { get; set; }
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        [Required(ErrorMessage = "Tipo de ID es obligatorio!")]
        [StringLength(maximumLength: 3, ErrorMessage = "Es obligatorio utilizar 3 caracteres!", MinimumLength = 3)]
        public string TipoIdentificacion { get; set; }

        [Required(ErrorMessage = "No. ID es obligatorio!")]
        public string NoIdentificacion { get; set; }

        [Required(ErrorMessage = "La direccion es obligatoria!")]
        [StringLength(maximumLength: 100, ErrorMessage = "Es obligatorio utilizar entre 10 y 100 caracteres!", MinimumLength = 10)]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El numero de telefono es obligatorio!")]
        [Phone(ErrorMessage = "El formato de este Telefono no es valido!")]
        public string Telefono { get; set; }

        [EmailAddress(ErrorMessage = "El formato de este Correo no es valido!")]
        [MaxLength(50, ErrorMessage = "Es obligatorio utilizar hasta 50 caracteres!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El numero de WhatsApp es obligatorio!")]
        [Phone(ErrorMessage = "El formato de este WhatsApp no es valido!")]
        public string WhatsApp { get; set; }

        [Required]
        public int Condiciones { get; set; }

        public bool CreditoAbierto { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal LimiteCredito { get; set; }

    }
}
