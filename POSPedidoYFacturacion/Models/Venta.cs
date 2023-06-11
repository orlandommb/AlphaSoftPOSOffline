using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaSoftPOSOffline.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }

        [ForeignKey("EmpresaId")]
        public Empresa Empresa { get; set; }
        
        public int SucursalId { get; set; }

        [ForeignKey("SucursalId")]
        public Sucursal Sucursal { get; set; }

        [Display(Name = "Almacen")]
        public int AlmacenId { get; set; }

        [ForeignKey("AlmacenId")]
        public Almacen Almacen { get; set; }

        public int CuadreId { get; set; }

        [ForeignKey(nameof(CuadreId))]
        public Cuadre Cuadre { get; set; }

        public int? ClienteId { get; set; }

        [ForeignKey(nameof(ClienteId))]
        public Cliente Cliente { get; set; }

        public bool Nulo { get; set; }
        public bool Facturado { get; set; }

        [Required(ErrorMessage = "El tipo de factura es obligatorio!")]
        public int TipoFacturaId { get; set; }

        [ForeignKey(nameof(TipoFacturaId))]
        public TipoFactura TipoFactura { get; set; }

        public int? TipoOrdenId { get; set; }

        [ForeignKey(nameof(TipoOrdenId))]
        public TipoOrden TipoOrden { get; set; }

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
        public decimal Delivery { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal MontoManoObra { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal MontoEfectivo { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal MontoDevuelta{ get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal SubTotal { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal Descuento { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal Impuesto { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal Total { get; set; }

        public List<VentaDetalle> VentaDetalles { get; set; } = new List<VentaDetalle>();
        public List<OrdenVenta> OrdenVentas { get; set; } = new List<OrdenVenta>();
        public List<VentaDevolucion> Devoluciones { get; set; } = new List<VentaDevolucion>();
    }
}
