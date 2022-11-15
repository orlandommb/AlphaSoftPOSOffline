namespace Shared.DTOs
{
    public class TipoOrdenDTO : BaseDTO
    {
        private int id;
        private string nombre;

        public int Id { get => id; set => SetProperty(ref id, value); }
        public string Nombre { get => nombre; set => SetProperty(ref nombre , value); }
    }
}