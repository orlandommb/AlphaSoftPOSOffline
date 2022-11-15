using System;
using System.Collections.Generic;

namespace Shared.DTOs
{
    public class UsuarioDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AccessToken { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public DateTime? Expires { get; set; }
        public List<EmpresaDTO> Empresas { get; set; } = new List<EmpresaDTO>();
        public List<SucursalDTO> Sucursales { get; set; } = new List<SucursalDTO>();

    }
}
