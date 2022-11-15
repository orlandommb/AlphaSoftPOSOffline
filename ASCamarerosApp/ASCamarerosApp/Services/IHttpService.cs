using System;
using System.Threading.Tasks;
using ASCamarerosApp.Helpers;

namespace ASCamarerosApp.Services
{
    public interface IHttpService
    {
        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(T enviar, string url = null);
        Task<HttpResponseWrapper<string>> Post<T>(T enviar, string url = null);
        Task<HttpResponseWrapper<T>> Get<T>(string url = null);
    }
}
