namespace Shared.DTOs
{
    public class CategoriaDTO:BaseDTO
    {
        private int empresaId;
        private EmpresaDTO empresa;
        private int sucursalId;
        private SucursalDTO sucursal;
        private int id;
        private string nombre;

        public int EmpresaId
        {
            get => empresaId;
            set => SetProperty(ref empresaId, value);
        }

        public EmpresaDTO Empresa
        {
            get => empresa;
            set => SetProperty(ref empresa, value);
        }

        public int SucursalId
        {
            get => sucursalId;
            set => SetProperty(ref sucursalId, value);
        }

        public SucursalDTO Sucursal
        {
            get => sucursal;
            set => SetProperty(ref sucursal, value);
        }

        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }
        public string Nombre
        {
            get => nombre;
            set => SetProperty(ref nombre, value);
        }
    }
}