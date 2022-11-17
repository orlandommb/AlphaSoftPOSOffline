using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSPedidoYFacturacion.Models
{
    public class Orden
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }

        [ForeignKey("EmpresaId")]
        public Empresa Empresa { get; set; }
        
        public int SucursalId { get; set; }

        [ForeignKey("SucursalId")]
        public Sucursal Sucursal { get; set; }

        public int TipoOrdenId { get; set; }

        [ForeignKey(nameof(TipoOrdenId))]
        public TipoOrden TipoOrden { get; set; }
        public int? ClienteId { get; set; }

        [ForeignKey(nameof(ClienteId))]
        public Cliente Cliente { get; set; }

        public int? MesaId { get; set; }

        [ForeignKey(nameof(MesaId))]
        public Mesa Mesa { get; set; }

        public bool Nulo { get; set; }

        public bool Facturado { get; set; }

        public DateTime FechaPedido { get; set; }
        public DateTime? FechaEnProceso { get; set; }
        public DateTime? FechaFinalizado { get; set; }

        public string UsuarioId { get; set; }

        [ForeignKey(nameof(UsuarioId))]
        public Usuario Usuario { get; set; }

        public string NombreCliente { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string CelularCliente { get; set; }

        public int? SectorId { get; set; }
        public Sector Sector { get; set; }

        public string DireccionCliente { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal MontoDelivery { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal SubTotal { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal Descuento { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal Impuesto { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal Total { get; set; }

        public List<OrdenDetalle> OrdenDetalles { get; set; } = new List<OrdenDetalle>();
        public List<OrdenDetalleHistorial> OrdenDetalleHistoriales { get; set; } = new List<OrdenDetalleHistorial>();
    }
}
