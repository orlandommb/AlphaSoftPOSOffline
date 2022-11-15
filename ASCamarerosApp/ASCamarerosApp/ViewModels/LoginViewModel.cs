using ASCamarerosApp.Helpers;
using ASCamarerosApp.Views;
using Newtonsoft.Json;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ASCamarerosApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string username;
        private string password;
        //private bool isbusy;
        private UsuarioDTO loggedInUsuario;
        private Settings settings = new();

        //public bool IsBusy { get => isbusy; set => SetValue(ref isbusy, value); }
        public string Username { get => username; set => SetProperty(ref username, value); }
        public string Password { get => password; set => SetProperty(ref password, value); }
        public ICommand LoginCommand { get; private set; }
        public ICommand LogoutCommand { get; private set; }
        public ICommand GoToConnectionConfigPageCommand { get; private set; }
        //public UsuarioViewModel LoggedInUsuario { get => loggedInUsuario; private set => SetValue(ref loggedInUsuario, value); }
        public UsuarioDTO LoggedInUsuario { get => loggedInUsuario; private set => SetProperty(ref loggedInUsuario, value); }

        public LoginViewModel()
        {
            LoginCommand = new Command(Login);
            GoToConnectionConfigPageCommand = new Command(GoToConConfigPage);
        }

        private async void Login()
        {

            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Alerta", "No puede dejar los campos vacios!.", "Ok", "Cancel");
            }
            else
            {
                IsBusy = true;

                UsuarioDTO usuarioVM = new()
                {
                    Username = Username,
                    Password = Password
                };

                var Response = await _IHttpService.Post<UsuarioDTO, UsuarioDTO>(usuarioVM, "/api/Auth/Login");
                if (Response.Error)
                {
                    IsBusy = false;

                    var Mensaje = await Response.ResponseMessage.Content.ReadAsStringAsync();
                    switch (string.IsNullOrWhiteSpace(Mensaje))
                    {
                        case true:
                            await Application.Current.MainPage.DisplayAlert("Error!", Response.ResponseMessage.ReasonPhrase, "Ok");
                            break;
                        case false:
                            await Application.Current.MainPage.DisplayAlert("Error!", Mensaje, "Ok");
                            break;
                    }


                }
                else
                {
                    LoggedInUsuario = Response.Data;
                    var SerializedUser = JsonConvert.SerializeObject(LoggedInUsuario);

                    settings.LoggedInUser = SerializedUser;

                    IsBusy = false;

                    //await Application.Current.MainPage.DisplayAlert("Acceso Concedido", "Bienvenido " + LoggedInUsuario.UserName + " !.", "Aceptar");

                    Application.Current.MainPage = new AppShell();

                }

            }
        }

        private async void GoToConConfigPage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ConnectionInfoPage(new ConnectionInfoViewModel()));
        }

    }
}
