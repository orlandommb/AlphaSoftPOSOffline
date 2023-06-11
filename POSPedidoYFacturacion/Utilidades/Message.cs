using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace AlphaSoftPOSOffline.Utilidades
{
    public class Message:IMessage
    {

        private readonly IJSRuntime jSRuntime;

        public Message(IJSRuntime jSRuntime)
        {
            this.jSRuntime = jSRuntime;
        }



        public async Task Error(string message)
        {
            await ShowMessage("Error", message, "error");
        }

        public async Task Success(string message)
        {
            await ShowMessage("Exitoso", message, "success");
        }

        public async Task Alert(string message)
        {
            await ShowMessage("Alerta", message, "warning");
        }

        private async ValueTask ShowMessage(string titulo, string mensaje, string tipo)
        {
            await jSRuntime.InvokeVoidAsync("Swal.fire", titulo, mensaje, tipo);
        }

        private async ValueTask<int> ShowOptionsDialog(string titulo, bool mostrarCancelar, string textoConfirmar, bool mostrarDenegar, string textodenegar)
        {
            return await jSRuntime.InvokeAsync<int>("optionsdialog", titulo, mostrarCancelar, mostrarDenegar, textoConfirmar, textodenegar);
        }

        public async Task<int> Dialog(string titulo, string opcion1, string opcion2)
        {
            return await ShowOptionsDialog( titulo , true, opcion1, true ,opcion2);
        }
        
        public async Task<bool> Confirm(string titulo)
        {
            return await jSRuntime.InvokeAsync<bool>("confirm", titulo );
        }
        
        // public async Task<bool> Confirm(string titulo, string textoConfirmar, string textodenegar)
        // {
        //     return await jSRuntime.InvokeAsync<bool>("Confirmar", titulo, textoConfirmar, textodenegar );
        // }
    }
}
