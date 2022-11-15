using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace POSPedidoYFacturacion.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }

        [ForeignKey("EmpresaId")]
        public Empresa Empresa { get; set; }
        
        public int SucursalId { get; set; }

        [ForeignKey("SucursalId")]
        public Sucursal Sucursal { get; set; }

        public string ImageString { get; set; }

        [Required(ErrorMessage = "El Codigo del producto es obligatorio")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El Nombre del producto es obligatorio")]
        public string Nombre { get; set; }

        public bool Activo { get; set; }

        public bool ManejaExistencia { get; set; }

        [Required(ErrorMessage = "La Categoria del producto es obligatoria")]
        public int CategoriaId { get; set; }

        [ForeignKey(nameof(CategoriaId))]
        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "La Sub-Categoria del producto es obligatoria")]
        public int SubCategoriaId { get; set; }

        [ForeignKey(nameof(SubCategoriaId))]
        public SubCategoria SubCategoria { get; set; }

        [Required(ErrorMessage = "El Tipo de Impuesto del producto es obligatorio")]
        [Display(Name = "Tipo de Impuesto")]
        public int ImpuestoTipoId { get; set; }

        [ForeignKey("ImpuestoTipoId")]
        public ImpuestoTipo ImpuestoTipo { get; set; }

        [Display(Name = "Impuesto")]
        public int? ImpuestoId { get; set; }

        [ForeignKey("ImpuestoId")]
        public Impuesto Impuesto { get; set; }

        public decimal Costo { get; set; }

        public decimal Precio { get; set; }

        public List<Existencia> Existencias { get; set; } = new List<Existencia>();

    }
}
