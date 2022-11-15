using System;
namespace ASCamarerosApp.ViewModels
{
    public class ConnectionViewModel : BaseViewModel
    {
        private string descripcion;
        private string connection;
        private string protocol;
        private string iporaddress;
        private string port;
        private bool activa;

        public string Descripcion
        {
            get => descripcion;
            set => SetProperty(ref descripcion, value);
        }

        public string Connection
        {
            get => connection;
            set => SetProperty(ref connection, value);
        }

        public string Protocol
        {
            get => protocol;
            set => SetProperty(ref protocol, value);
        }

        public string IPorAddress
        {
            get => iporaddress;
            set => SetProperty(ref iporaddress, value);
        }

        public string Port
        {
            get => port;
            set => SetProperty(ref port, value);
        }

        public bool Activa
        {
            get => activa;
            set => SetProperty(ref activa, value);
        }

    }
}
