using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace POSPedidoYFacturacion.Models
{
    public class VentaDevolucion
    {
        public int Id { get; set; }

        public int EmpresaId { get; set; }

        [ForeignKey("EmpresaId")]
        public Empresa Empresa { get; set; }
        
        public int SucursalId { get; set; }

        [ForeignKey("SucursalId")]
        public Sucursal Sucursal { get; set; }

        public int VentaId { get; set; }

        [ForeignKey("VentaId")]
        public Venta Venta { get; set; }

        [Display(Name = "Almacen")]
        public int AlmacenId { get; set; }

        [ForeignKey("AlmacenId")]
        public Almacen Almacen { get; set; }

        public int CuadreId { get; set; }

        [ForeignKey(nameof(CuadreId))]
        public Cuadre Cuadre { get; set; }

        public string UsuarioId { get; set; }

        [ForeignKey(nameof(UsuarioId))]
        public Usuario Usuario { get; set; }

        public int? ClienteId { get; set; }

        [ForeignKey(nameof(ClienteId))]
        public Cliente Cliente { get; set; }

        public bool Nulo { get; set; }
        public bool Facturado { get; set; }
        public DateTime Fecha { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal SubTotal { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal Descuento { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal Impuesto { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal Total { get; set; }

        public string Motivo { get; set; }

        public List<VentaDevolucionDetalle> DevolucionDetalles { get; set; } = new List<VentaDevolucionDetalle>();
    }

}