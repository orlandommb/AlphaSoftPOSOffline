using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSPedidoYFacturacion.Models
{
    public class Compra
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

        [Required(ErrorMessage = "Tipo de Compra es obligatoria!")]
        [Display(Name = "Tipo de Compra")]
        public int TipoCompraId { get; set; }

        [ForeignKey("TipoCompraId")]
        public TipoCompra TipoCompra { get; set; }
        
        [Required(ErrorMessage = "Almacen es obligatorio!")]
        [Display(Name = "Almacen")]
        public int AlmacenId { get; set; }

        [ForeignKey("AlmacenId")]
        public Almacen Almacen { get; set; }

        [Required]
        public DateTime FechaHoraFactura { get; set; }

        public DateTime? FechaHoraRecepcion { get; set; }

        [Required]
        public string NoFactura { get; set; }

        [Required]
        public string NCF { get; set; }

        [Required(ErrorMessage = "Suplidor es obligatorio")]
        [Display(Name = "Suplidor")]
        public int SuplidorId { get; set; }

        [ForeignKey("SuplidorId")]
        public Suplidor Suplidor { get; set; }

        [Display(Name = "Usuario")]
        public string UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }

        [Required(ErrorMessage = "El tipo de factura es obligatorio!")]
        [Display(Name = "Tipo de Factura")]
        public int TipoFacturaId { get; set; }

        [ForeignKey("TipoFacturaId")]
        public TipoFactura TipoFactura { get; set; }

        [Display(Name = "Nulo")]
        public bool Nulo { get; set; }

        [Required]
        [Precision(precision: 18, scale: 2)]
        public decimal SubTotal { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Impuesto Total")]
        [Precision(precision: 18, scale: 2)]
        public decimal Impuesto { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Descuento Total")]
        [Precision(precision: 18, scale: 2)]
        public decimal Descuento { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Total")]
        [Precision(precision: 18, scale: 2)]
        public decimal Total { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Efectivo")]
        [Precision(precision: 18, scale: 2)]
        public decimal EfectivoMonto { get; set; }

        //[DisplayFormat(DataFormatString = "{0:C2}")]
        //[Display(Name = "Tarjeta")]
        //public decimal TarjetaMonto { get; set; }

        //[Display(Name = "Tarjeta")]
        //[CreditCard]
        //public string TarjetaNumero { get; set; }

        //[Display(Name = "Tipo de Tarjeta")]
        //public int? TipoTarjetaId { get; set; }

        //[ForeignKey("TipoTarjetaId")]
        //public TipoTarjeta TipoTarjeta { get; set; }

        //[DisplayFormat(DataFormatString = "{0:C2}")]
        //[Display(Name = "Banco")]
        //public decimal BancoMonto { get; set; }

        //[Display(Name = "Banco")]
        //public int? BancoId { get; set; }

        //[ForeignKey("BancoId")]
        //public Bancos Banco { get; set; }

        public string Status { get; set; }
        public string PagoStatus { get; set; }
        public string Comentarios { get; set; }
        [Required(ErrorMessage = "Concepto es obligatorio")]
        [StringLength(maximumLength:50, ErrorMessage = "Solo puede colocar un maximo de 50 caracteres!")]
        public string Concepto { get; set; }

        public List<CompraDetalle> CompraDetalles { get; set; }
    }
}
