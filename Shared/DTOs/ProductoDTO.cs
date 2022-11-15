namespace Shared.DTOs
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }

        public EmpresaDTO Empresa { get; set; }

        public int SucursalId { get; set; }

        public SucursalDTO Sucursal { get; set; }

        public string ImageString { get; set; }

        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public bool Activo { get; set; }

        public bool ManejaExistencia { get; set; }

        public int CategoriaId { get; set; }

        public CategoriaDTO Categoria { get; set; }

        public int SubCategoriaId { get; set; }

        public SubCategoriaDTO SubCategoria { get; set; }

        public decimal Costo { get; set; }

        public decimal Precio { get; set; }
    }
}