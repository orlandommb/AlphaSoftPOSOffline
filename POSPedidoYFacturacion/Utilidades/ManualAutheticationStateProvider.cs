using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace POSPedidoYFacturacion.Utilidades
{
    public class ManualAutheticationStateProvider :AuthenticationStateProvider
    {
        public ManualAutheticationStateProvider()
        {
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
