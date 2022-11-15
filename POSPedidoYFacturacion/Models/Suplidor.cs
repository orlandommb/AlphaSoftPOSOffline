using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSPedidoYFacturacion.Models
{
    public class Suplidor
    {
        public int Id { get; set; }

        [Display(Name = "Empresa")]
        public int EmpresaId { get; set; }

        [ForeignKey("EmpresaId")]
        public Empresa Empresa { get; set; }

        [Display(Name = "Sucursal")]
        public int SucursalId { get; set; }

        [ForeignKey("SucursalId")]
        public Sucursal Sucursal { get; set; }

        [Required]
        [StringLength(20)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(20)]
        public string RazonSocial { get; set; }

        [Required]
        [StringLength(11)]
        public string Cedula { get; set; }

        public string RNC { get; set; }

        public bool Activo { get; set; }

        [Required]
        [Phone]
        public string Telefono { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string WhatsApp { get; set; }

        public int Condiciones { get; set; }

        //[Display(Name = "Tipo de ITBIS")]
        //public int TipoITBISId { get; set; }

        //[ForeignKey("TipoITBISId")]
        //public TipoITBIS TipoITBIS { get; set; }
    }
}
