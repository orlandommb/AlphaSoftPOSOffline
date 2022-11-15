using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ASCamarerosApp.Services;
using ASCamarerosApp.Views;
using ASCamarerosApp.ViewModels;
using System.Collections.ObjectModel;
using ASCamarerosApp.Helpers;
using Newtonsoft.Json;
using Shared.DTOs;

namespace ASCamarerosApp
{
    public partial class App : Application
    {
        public static string BaseImageUrl { get; } = "https://cdn.syncfusion.com/essential-ui-kit-for-xamarin.forms/common/uikitimages/";

        Settings settings = new Settings();

        public App()
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTcxNzI4QDMxMzkyZTM0MmUzMGhONW83VDM2K1BDS0x3bkNvb0VoL3V5UVJYVkxBMTk4YjFraUhiUTlsVXM9; NTcxNzI5QDMxMzkyZTM0MmUzMG1DZm41a1JwdmV1NDJIMUthMFdGaE0zWXFyS1NnSWhZVmxUektiY0dKbHc9");
            DevExpress.XamarinForms.Editors.Initializer.Init();
            InitializeComponent();

            

            if (string.IsNullOrWhiteSpace(settings.ConnectionListSettings))
            {
                ObservableCollection<ConnectionViewModel> occonnectionVM = new()
                {
                    new ConnectionViewModel{ Descripcion = "10 Localhost", Connection="https://10.0.0.252", Protocol = "Https://", IPorAddress = "10.0.0.252", Port = ":5000", Activa = true},
                    new ConnectionViewModel{ Descripcion = "192 Localhost", Connection = "https://192.168.1.252:5000", Protocol = "Https://", IPorAddress = "192.168.1.252", Port = ":5000", Activa = false}
                };

                settings.ConnectionListSettings = JsonConvert.SerializeObject(occonnectionVM);
            }

            DependencyService.Register<HttpService>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            IsAuthenticated();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
            IsAuthenticated();
        }


        private void IsAuthenticated()
        {
            if (!string.IsNullOrWhiteSpace(settings.LoggedInUser))
            {

                if (IsTokenExpired() == false)
                {

                    MainPage = new AppShell();

                }
                else
                {

                    MainPage = new NavigationPage(new LoginPage());
                }
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage());
            }
        }

        public bool IsTokenExpired()
        {
            var User = JsonConvert.DeserializeObject<UsuarioDTO>(settings.LoggedInUser);
            if (User != null)
            {
                if (User.Expires != null)
                {
                    if (User.Expires > DateTime.UtcNow)
                    {
                        return false;
                    }
                    return true;
                }
                return true;
            }
            return true;
        }
    }
}
