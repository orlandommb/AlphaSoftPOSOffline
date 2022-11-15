using System;
using System.Threading.Tasks;
using Shared.DTOs;

namespace ASCamarerosApp.Services
{
    public interface ILoginService
    {
        Task<UsuarioDTO> LoginAPI(UsuarioDTO usuario);
    }
}
