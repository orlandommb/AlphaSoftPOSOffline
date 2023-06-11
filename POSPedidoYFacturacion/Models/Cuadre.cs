using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaSoftPOSOffline.Models
{
    public class Cuadre
    {
        public int EmpresaId { get; set; }

        [ForeignKey("EmpresaId")]
        public Empresa Empresa { get; set; }
        
        public int SucursalId { get; set; }

        [ForeignKey("SucursalId")]
        public Sucursal Sucursal { get; set; }
        
        public int Id { get; set; }
        public DateTime FechaApertura { get; set; }
        public DateTime? FechaCierre { get; set; }

        public bool Cerrado { get; set; }
        public string UsuarioId { get; set; }

        [ForeignKey(nameof(UsuarioId))]
        public Usuario Usuario { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal FondoCaja { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal MontoEfectivo { get; set; }


        public List<Venta> Ventas { get; set; } = new List<Venta>();
        public List<VentaDevolucion> Devoluciones { get; set; } = new List<VentaDevolucion>();
        public List<CXCTransaccion> RecibosIngresos { get; set; } = new List<CXCTransaccion>();
        public List<Desglose> Desgloses { get; set; } = new List<Desglose>();

    }
}
