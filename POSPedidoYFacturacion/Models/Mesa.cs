using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace POSPedidoYFacturacion.Models
{
    public class Mesa
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }

        [ForeignKey("EmpresaId")]
        public Empresa Empresa { get; set; }
        
        public int SucursalId { get; set; }

        [ForeignKey("SucursalId")]
        public Sucursal Sucursal { get; set; }

        public string Nombre { get; set; }

        public string Estado { get; set; }

        public decimal PosicionX { get; set; }

        public decimal PosicionY { get; set; }

        [Display(Name = "Area")]
        public int AreaId { get; set; }

        [ForeignKey("AreaId")]
        public Area Area { get; set; }
        
        public List<Orden> Ordenes { get; set; } = new List<Orden>();
    }
}
