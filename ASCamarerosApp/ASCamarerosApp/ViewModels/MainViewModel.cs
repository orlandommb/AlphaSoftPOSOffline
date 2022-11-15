using System;
using System.Threading.Tasks;
using ASCamarerosApp.Helpers;
using Newtonsoft.Json;
using Shared.DTOs;
using Xamarin.Forms;

namespace ASCamarerosApp.ViewModels
{
    public class MainViewModel :BaseViewModel
    {
        Settings settings = new();
        private UsuarioDTO usuario;

        public UsuarioDTO Usuario
        {
            get => usuario;
            set => SetProperty(ref usuario, value);
        }

        public Command LogoutCommand { get; }

        public MainViewModel()
        {
            LogoutCommand = new Command(async ()=> await Logout());
            Usuario = JsonConvert.DeserializeObject<UsuarioDTO>(settings.LoggedInUser);
        }

        private async Task Logout()
        {
            settings.LoggedInUser = "";
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
