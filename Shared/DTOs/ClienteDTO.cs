namespace Shared.DTOs
{
    public class ClienteDTO : BaseDTO
    {
        private int empresaId;
        private EmpresaDTO empresa;
        private SucursalDTO sucursal;
        private int id;
        private string nombre;
        private string apellido;
        private string tipoIdentificacion;
        private string noIdentificacion;
        private string direccion;
        private string telefono;
        private string email;
        private string whatsApp;
        private int condiciones;
        private bool creditoAbierto;
        private decimal limiteCredito;
        private int sucursalId;

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
            set => SetProperty(ref sucursalId ,value);
        }

        public SucursalDTO Sucursal
        {
            get => sucursal;
            set => SetProperty(ref sucursal, value);
        }

        public int Id { get => id; set => SetProperty(ref id, value); }

        public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }

        public string Apellido { get => apellido; set => SetProperty(ref apellido, value); }

        public string TipoIdentificacion { get => tipoIdentificacion; set => SetProperty(ref tipoIdentificacion ,value); }

        public string NoIdentificacion { get => noIdentificacion; set => SetProperty(ref noIdentificacion ,value); }

        public string Direccion { get => direccion; set => SetProperty(ref direccion , value); }

        public string Telefono { get => telefono; set => SetProperty(ref telefono, value); }

        public string Email { get => email; set => SetProperty(ref email, value); }

        public string WhatsApp { get => whatsApp; set => SetProperty(ref whatsApp , value); }

        public int Condiciones { get => condiciones; set => SetProperty(ref condiciones , value); }

        public bool CreditoAbierto { get => creditoAbierto; set => SetProperty(ref creditoAbierto , value); }

        public decimal LimiteCredito { get => limiteCredito; set => SetProperty(ref limiteCredito , value); }
    }
}