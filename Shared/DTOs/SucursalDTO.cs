namespace Shared.DTOs
{
    public class SucursalDTO
    {
        public int Id { get; set; }

        public int EmpresaId { get; set; }

        public EmpresaDTO Empresa { get; set; }

        public string Nombre { get; set; }
    }
}