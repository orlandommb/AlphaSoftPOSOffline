using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Shared.DTOs
{
    public class MesaDTO
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }

        public EmpresaDTO Empresa { get; set; }

        public int SucursalId { get; set; }

        public SucursalDTO Sucursal { get; set; }

        public string Nombre { get; set; }

        public string Estado { get; set; }

        public decimal PosicionX { get; set; }

        public decimal PosicionY { get; set; }

        public int AreaId { get; set; }

        public AreaDTO Area { get; set; }

        public ObservableCollection<OrdenDTO> Ordenes { get; set; } = new ObservableCollection<OrdenDTO>();
    }
}
