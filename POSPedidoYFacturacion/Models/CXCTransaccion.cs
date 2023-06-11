using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaSoftPOSOffline.Models
{
    public class CXCTransaccion
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
        
        [Required(ErrorMessage = "Debe seleccionar un cliente!")]
        public int ClienteId { get; set; } 

        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

        public string UsuarioId { get; set; } 

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria!")]
        public DateTime Fecha { get; set; }
        
        public DateTime FechaRegistro { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un Tipo de Transaccion!")]
        public int CXCTransaccionTipoId { get; set; } 

        [ForeignKey("CXCTransaccionTipoId")]
        public CXCTransaccionTipo CXCTransaccionTipo{ get; set; }
        
        [Required(ErrorMessage = "Debe seleccionar un Tipo de Documento!")]
        public int CXCTransaccionTipoDocumentoId { get; set; } 

        [ForeignKey("CXCTransaccionTipoDocumentoId")]
        public CXCTransaccionTipoDocumento CXCTransaccionTipoDocumento { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal Monto { get; set; }

        public bool Nulo { get; set; }

        public string DevolucionNo { get; set; }

        public List<CXCTransaccionDetalle> CXCTransaccionDetalles { get; set; } = new List<CXCTransaccionDetalle>();
    }
}