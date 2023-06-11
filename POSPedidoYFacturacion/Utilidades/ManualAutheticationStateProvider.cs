using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace AlphaSoftPOSOffline.Utilidades
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
