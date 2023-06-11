using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace AlphaSoftPOSOffline.Utilidades
{
    public static class IJSRuntimeExtensionMethods
    {

        public static async ValueTask InicializarTimerInactivo<T>(this IJSRuntime js,
            DotNetObjectReference<T> dotNetObjectReference) where T : class
        {
            await js.InvokeVoidAsync("timerInactivo", dotNetObjectReference);
        }

        public static async ValueTask<bool> Confirmar(this IJSRuntime js, string mensaje)
        {
            return await js.InvokeAsync<bool>("ConfirmarDialog", mensaje, "Si", "No");
        }
        
        public static async ValueTask AbrirNuevaPagina(this IJSRuntime js, string URL)
        {
            await js.InvokeVoidAsync("OpenNewPage", URL);
        }
        
        public static async ValueTask CerrarPagina(this IJSRuntime js)
        {
            await js.InvokeVoidAsync("ClosePage");
        }
        
        public static async ValueTask ImprimirPagina(this IJSRuntime js)
        {
            await js.InvokeVoidAsync("imprimir");
        }

        public static ValueTask<object> SetInLocalStorage(this IJSRuntime js, string key, string content)
   => js.InvokeAsync<object>(
       "localStorage.setItem",
       key, content
       );

        public static ValueTask<string> GetFromLocalStorage(this IJSRuntime js, string key)
            => js.InvokeAsync<string>(
                "localStorage.getItem",
                key
                );

        public static ValueTask<object> RemoveItem(this IJSRuntime js, string key)
            => js.InvokeAsync<object>(
                "localStorage.removeItem",
                key);
    }
}
