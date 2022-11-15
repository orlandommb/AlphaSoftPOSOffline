using System;
using System.Collections.ObjectModel;

namespace Shared.DTOs
{
    public class AreaDTO
    {
        public int EmpresaId { get; set; }

        public EmpresaDTO Empresa { get; set; }

        public int SucursalId { get; set; }

        public SucursalDTO Sucursal { get; set; }
        public int Id { get; set; }

        public string Nombre { get; set; }

        public ObservableCollection<MesaDTO> Mesas { get; set; } = new ObservableCollection<MesaDTO>();
    }
}
