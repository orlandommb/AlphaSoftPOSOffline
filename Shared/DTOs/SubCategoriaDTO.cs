namespace Shared.DTOs
{
    public class SubCategoriaDTO
    {
        public int EmpresaId { get; set; }

        public EmpresaDTO Empresa { get; set; }

        public int SucursalId { get; set; }

        public SucursalDTO Sucursal { get; set; }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public int CategoriaId { get; set; }

        public CategoriaDTO Categoria { get; set; }
    }
}