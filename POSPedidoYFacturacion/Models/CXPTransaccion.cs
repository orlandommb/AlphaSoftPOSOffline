using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AlphaSoftPOSOffline.Models
{
    public class CXPTransaccion
    {
        public int Id { get; set; }

        public int EmpresaId { get; set; }

        [ForeignKey("EmpresaId")]
        public Empresa Empresa { get; set; }
        
        public int SucursalId { get; set; }

        [ForeignKey("SucursalId")]
        public Sucursal Sucursal { get; set; }
        
        public int? CuadreId { get; set; } 

        [ForeignKey("CuadreId")]
        public Cuadre Cuadre { get; set; }
        
        [Required(ErrorMessage = "Debe seleccionar un Suplidor!")]
        public int SuplidorId { get; set; } 

        [ForeignKey("SuplidorId")]
        public Suplidor Suplidor { get; set; }

        public string UsuarioId { get; set; } 

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria!")]
        public DateTime Fecha { get; set; }
        
        public DateTime FechaRegistro { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un Tipo de Transaccion!")]
        public int CXPTransaccionTipoId { get; set; } 

        [ForeignKey("CXPTransaccionTipoId")]
        public CXPTransaccionTipo CXPTransaccionTipo{ get; set; }
        
        [Required(ErrorMessage = "Debe seleccionar un Tipo de Documento!")]
        public int CXPTransaccionTipoDocumentoId { get; set; } 

        [ForeignKey("CXPTransaccionTipoDocumentoId")]
        public CXPTransaccionTipoDocumento CXPTransaccionTipoDocumento { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal Monto { get; set; }

        public bool Nulo { get; set; }

        public List<CXPTransaccionDetalle> CXPTransaccionDetalles { get; set; } = new List<CXPTransaccionDetalle>();
    }
}