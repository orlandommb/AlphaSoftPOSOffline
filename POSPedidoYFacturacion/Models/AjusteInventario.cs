using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AlphaSoftPOSOffline.Models
{
    public class AjusteInventario
    {
        public int Id { get; set; }

        [Display(Name ="Tipo de Ajuste")]
        public int AjusteInventarioTipoId { get; set; }

        [ForeignKey("AjusteInventarioTipoId")]
        public AjusteInventarioTipo AjusteInventarioTipo { get; set; }

        // [Display(Name ="Tipo de Motivo")]
        // public int TipoMotivoAjusteId { get; set; }

        // [ForeignKey("TipoMotivoAjusteId")]
        // public TipoMotivoAjuste TipoMotivoAjuste { get; set; }

        [Display(Name = "Usuario")]
        public string UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        public DateTime Fecha { get; set; }

        [Display(Name = "Empresa")]
        public int EmpresaId { get; set; }

        [ForeignKey("EmpresaId")]
        public Empresa Empresa { get; set; }

        [Display(Name = "Sucursal")]
        public int SucursalId { get; set; }

        [ForeignKey("SucursalId")]
        public Sucursal Sucursal { get; set; }

        [Display(Name = "Almacen")]
        public int AlmacenId { get; set; }

        [ForeignKey("AlmacenId")]
        public Almacen Almacen { get; set; }

        [Display(Name = "Nulo")]
        public bool Nulo { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal Total { get; set; }

        public List<AjusteInventarioDetalle> AjusteDetalles { get; set; } = new List<AjusteInventarioDetalle>(); 
    }
}