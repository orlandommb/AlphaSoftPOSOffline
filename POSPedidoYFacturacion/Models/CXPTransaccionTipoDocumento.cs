using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSPedidoYFacturacion.Models
{
    public class CXPTransaccionTipoDocumento
    {
        public int Id { get; set; }

        public int EmpresaId { get; set; }

        [ForeignKey("EmpresaId")]
        public Empresa Empresa { get; set; }
        
        public int SucursalId { get; set; }

        [ForeignKey("SucursalId")]
        public Sucursal Sucursal { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un Tipo de Transaccion!")]
        public int CXPTransaccionTipoId { get; set; } 

        [ForeignKey("CXPTransaccionTipoId")]
        public CXPTransaccionTipo CXPTransaccionTipo{ get; set; }
        
        [StringLength(maximumLength:30,ErrorMessage = "Solo debe contener 30 caracteres!")]
        [Required(ErrorMessage = "Nombre es obligatorio!")]
        public string Nombre { get; set; }
    }
}