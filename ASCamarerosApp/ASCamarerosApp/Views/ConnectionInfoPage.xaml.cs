using ASCamarerosApp.Helpers;
using ASCamarerosApp.ViewModels;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ASCamarerosApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConnectionInfoPage : ContentPage
    {

        public static Settings Settings = new Settings();
        public ConnectionInfoViewModel ConnectionInfoVM
        {
            get => BindingContext as ConnectionInfoViewModel;
            set => BindingContext = value;
        }


        public ConnectionInfoPage(ConnectionInfoViewModel connectionInfoViewModel)
        {
            ConnectionInfoVM = connectionInfoViewModel;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {

            pckrProtocol.SelectedItem = Settings.ProtocolSettings.ToString().Trim();
            txtIpOrHttpAdress.Text = Settings.IPOrAddresslSettings.ToString().Trim();
            txtPort.Text = Settings.PortSettings.ToString().ToString().Trim();

            ConnectionInfoVM.LoadConnectionsCommand.Execute(null);

            base.OnAppearing();
        }

        private void BtnGuardarOpciones_Clicked(object sender, EventArgs e)
        {
            Settings.ProtocolSettings = pckrProtocol.SelectedItem.ToString();
            Settings.IPOrAddresslSettings = txtIpOrHttpAdress.Text.Trim();
            Settings.PortSettings = txtPort.Text.Trim();

            ConnectionInfoVM.SaveConnectionListCommand.Execute(null);
            CheckConnection();

        }

        public async void CheckConnection()
        {
            var crossConnectivity = CrossConnectivity.Current;
            int countfailed = 0;
            int countsuccess = 0;
            string[] testedconnections = new string[10];


            for (int i = 0; i < ConnectionInfoVM.ListaConnections.Count; i++)
            {
                if (ConnectionInfoVM.ListaConnections[i].Port != null)
                {

                    var resultado = await crossConnectivity.IsReachable(ConnectionInfoVM.ListaConnections[i].IPorAddress);

                    if (resultado == true)
                    {
                        testedconnections[i] = ConnectionInfoVM.ListaConnections[i].Connection + " esta activa.";

                        countsuccess += 1;
                    }
                    else
                    {
                        testedconnections[i] = ConnectionInfoVM.ListaConnections[i].Connection + " no esta activa.";

                        countfailed += 1;
                    }
                }
                else
                {
                    var resultado = await crossConnectivity.IsRemoteReachable(ConnectionInfoVM.ListaConnections[i].IPorAddress, Convert.ToInt32(ConnectionInfoVM.ListaConnections[i].Port));

                    if (resultado == true)
                    {
                        testedconnections[i] = (ConnectionInfoVM.ListaConnections[i].Connection + " esta activa.");
                        countsuccess += 1;
                    }
                    else
                    {
                        testedconnections[i] = (ConnectionInfoVM.ListaConnections[i].Connection + " no esta activa.");
                        countfailed += 1;
                    }
                }
            }


            await DisplayActionSheet("Connection", "Ok", null, testedconnections);


        }



        private void BtnConfigAtras_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void BtnCheckearConexion_Clicked(object sender, EventArgs e)
        {
            CheckConnection();
        }

        void BtnAddConnectionToList_Clicked(System.Object sender, System.EventArgs e)
        {
            ConnectionViewModel connectionViewModel = new ConnectionViewModel
            {
                Descripcion = TxtDescripcion.Text,
                Connection = pckrProtocol.SelectedItem.ToString() + txtIpOrHttpAdress.Text.Trim() + ":" +txtPort.Text.Trim(),
                Protocol = pckrProtocol.SelectedItem.ToString(),
                IPorAddress = txtIpOrHttpAdress.Text.Trim(),
                Port = txtPort.Text.Trim()
            };

            ConnectionInfoVM.AddConnectionToListCommand.Execute(connectionViewModel);
        }

        async void ConnectionListView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var result = await DisplayActionSheet("Acciones", "Ok", null, (e.Item as ConnectionViewModel).Activa == false ? "Activar" : "Desactivar", "Eliminar");
            if (result == "Eliminar")
            {
                ConnectionInfoVM.RemoveConnectionFromListCommand.Execute(e.Item);
            }
            else if (result == "Activar" || result == "Desactivar")
            {
                ConnectionInfoVM.ActivateDeactivateConnectionCommand.Execute(e.Item);
            }

        }
    }
}