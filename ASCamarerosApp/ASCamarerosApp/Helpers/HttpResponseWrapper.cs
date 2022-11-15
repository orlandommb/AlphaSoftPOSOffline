using System;
using System.Net.Http;

namespace ASCamarerosApp.Helpers
{
        public class HttpResponseWrapper<T>
        {

            public HttpResponseWrapper(bool error, T Data, HttpResponseMessage responseMessage)
            {
                Error = error;
                this.Data = Data;
                ResponseMessage = responseMessage;
            }

            public bool Error { get; set; }
            public T Data { get; set; }
            public HttpResponseMessage ResponseMessage { get; set; }
    }
}
