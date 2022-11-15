using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ASCamarerosApp.Helpers;
using ASCamarerosApp.ViewModels;
using Newtonsoft.Json;
using Shared.DTOs;

namespace ASCamarerosApp.Services
{
    public class HttpService : IHttpService, ILoginService
    {
        public static Settings Settings = new();
        public ObservableCollection<ConnectionViewModel> ListaConnections = new();
        public string URL;

        public string GetURL()
        {
            ListaConnections = JsonConvert.DeserializeObject<ObservableCollection<ConnectionViewModel>>(Settings.ConnectionListSettings);

            return ListaConnections.SingleOrDefault(c => c.Activa == true).Connection;
        }

        public static HttpClientHandler clientHandler = new()
        {

            ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
            {
                if (certificate.Issuer.Equals("CN=localhost") || certificate.Issuer.Equals("CN=192.168.1.251"))
                    return true;
                return sslPolicyErrors == System.Net.Security.SslPolicyErrors.None;
            },


        };

        private readonly HttpClient HttpClient = new(clientHandler);


        //private JsonSerializerOptions JsonOptions => new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        private JsonSerializerSettings JsonSettings => new() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };

        public async Task<HttpResponseWrapper<T>> Get<T>(string url = null)
        {
            HttpResponseMessage httpresponse = new();
            try
            {
                var User = JsonConvert.DeserializeObject<UsuarioDTO>(Settings.LoggedInUser);

                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", User.AccessToken);
                httpresponse = await HttpClient.GetAsync(GetURL() + url);

                if (httpresponse.IsSuccessStatusCode)
                {
                    var data = JsonConvert.DeserializeObject<T>(await httpresponse.Content.ReadAsStringAsync());
                    return new HttpResponseWrapper<T>(false, data, httpresponse);
                }

                return new HttpResponseWrapper<T>(true, default, httpresponse);
            }
            catch (HttpRequestException ex)
            {
                
                return new HttpResponseWrapper<T>(true, default, new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.BadRequest, ReasonPhrase = ex.Message});
            }
        }

        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(T enviar, string url = null)
        {
            var User = JsonConvert.DeserializeObject<UsuarioDTO>(Settings.LoggedInUser);

            HttpResponseMessage httpresponse = new();

            try
            {
                if (User != null)
                {
                    HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", User.AccessToken);
                }
                var Json = JsonConvert.SerializeObject(enviar, JsonSettings);
                var content = new StringContent(Json, Encoding.UTF8, "application/json");
                httpresponse = await HttpClient.PostAsync(GetURL() + url, content);

                if (httpresponse.IsSuccessStatusCode)
                {
                    var data = JsonConvert.DeserializeObject<TResponse>(await httpresponse.Content.ReadAsStringAsync());
                    return new HttpResponseWrapper<TResponse>(false, data, httpresponse);
                }

                return new HttpResponseWrapper<TResponse>(true, default, httpresponse);

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpResponseWrapper<TResponse>(true, default, new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
        }

        public async Task<HttpResponseWrapper<string>> Post<T>(T enviar, string url = null)
        {
            var User = JsonConvert.DeserializeObject<UsuarioDTO>(Settings.LoggedInUser);

            HttpResponseMessage httpresponse = new();

            try
            {
                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", User.AccessToken);

                var Json = JsonConvert.SerializeObject(enviar, JsonSettings);
                var content = new StringContent(Json, Encoding.UTF8, "application/json");
                httpresponse = await HttpClient.PostAsync(GetURL() + url, content);

                return new HttpResponseWrapper<string>(false, await httpresponse.Content.ReadAsStringAsync(), httpresponse);

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpResponseWrapper<string>(true, ex.Message, new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
        }

        public async Task<UsuarioDTO> LoginAPI(UsuarioDTO usuario)
        {
            var json = JsonConvert.SerializeObject(usuario);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await HttpClient.PostAsync(GetURL() + "/api/Auth/Login", content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                var Usuario = JsonConvert.DeserializeObject<UsuarioDTO>(result);

                return Usuario;
            }

            return default;
        }
    }
}
