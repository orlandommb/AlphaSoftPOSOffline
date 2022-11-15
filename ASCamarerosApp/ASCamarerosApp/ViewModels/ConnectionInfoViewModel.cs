using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ASCamarerosApp.Helpers;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace ASCamarerosApp.ViewModels
{
    public class ConnectionInfoViewModel : BaseViewModel
    {
        Settings Settings = new Settings();
        private ObservableCollection<ConnectionViewModel> listaconnection = new ObservableCollection<ConnectionViewModel>();
        private ConnectionViewModel connectionviemodel;

        public ICommand LoadConnectionsCommand { get; private set; }
        public ICommand AddConnectionToListCommand { get; private set; }
        public ICommand RemoveConnectionFromListCommand { get; private set; }
        public ICommand SaveConnectionListCommand { get; private set; }
        public ICommand ActivateDeactivateConnectionCommand { get; private set; }

        public ObservableCollection<ConnectionViewModel> ListaConnections
        {
            get => listaconnection;
            set => SetProperty(ref listaconnection, value);
        }

        public ConnectionViewModel connectionVM
        {
            get => connectionviemodel;
            set => SetProperty(ref connectionviemodel, value);
        }

        public ConnectionInfoViewModel()
        {
            ListaConnections = new ObservableCollection<ConnectionViewModel>();
            LoadConnectionsCommand = new Command<string>(search => CargarConnections(search));
            AddConnectionToListCommand = new Command<ConnectionViewModel>(cvm => AddConnectionToList(cvm));
            RemoveConnectionFromListCommand = new Command<ConnectionViewModel>(cmv => RemoveConnection(cmv));
            SaveConnectionListCommand = new Command(SaveConnectionList);
            ActivateDeactivateConnectionCommand = new Command<ConnectionViewModel>(cvm => ActivateOrDeactivateConnection(cvm));
        }

        private void CargarConnections(string searchbartext = null)
        {
            ObservableCollection<ConnectionViewModel> OCConnections = new ObservableCollection<ConnectionViewModel>();

            OCConnections = JsonConvert.DeserializeObject<ObservableCollection<ConnectionViewModel>>(Settings.ConnectionListSettings);

            if (string.IsNullOrWhiteSpace(searchbartext))
            {
                ListaConnections = OCConnections;
            }
            else
            {
                var filteredusuarios = OCConnections.Where(c => c.Descripcion.StartsWith(searchbartext)).ToList();

                ListaConnections = new ObservableCollection<ConnectionViewModel>(filteredusuarios);
            }

        }

        private void AddConnectionToList(ConnectionViewModel connectionVM)
        {
            if (connectionVM != null)
            {
                if (!ListaConnections.Any(r => r.Connection == connectionVM.Connection))
                {
                    ListaConnections.Add(connectionVM);
                }
            }
        }

        private void SaveConnectionList()
        {
            Settings.ConnectionListSettings = JsonConvert.SerializeObject(ListaConnections);
        }


        private void RemoveConnection(ConnectionViewModel connectionVM)
        {
            if (connectionVM != null)
            {
                if (ListaConnections.Any(r => r.Connection == connectionVM.Connection))
                {
                    ListaConnections.Remove(connectionVM);
                }
            }
        }

        private void EditConnection()
        {

        }

        private void ActivateOrDeactivateConnection(ConnectionViewModel connectionVM)
        {
            if (connectionVM != null)
            {

                var convm = ListaConnections.SingleOrDefault(c => c.Connection == connectionVM.Connection);

                if (convm != null)
                {
                    if (convm.Activa == false)
                    {
                        convm.Activa = true;
                    }
                    else
                    {
                        convm.Activa = false;
                    }
                }
            }
        }
    }
}
