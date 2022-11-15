using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ASCamarerosApp.Helpers;
using ASCamarerosApp.Views;
using Newtonsoft.Json;
using Shared.DTOs;
using Xamarin.Forms;

namespace ASCamarerosApp.ViewModels
{
    public class OrdenesAmbulantesViewModel :BaseViewModel
    {

        private OrdenDTO _selectedItem;
        private UsuarioDTO Usuario { get; set; }
        Settings Settings = new Settings();
        private ObservableCollection<OrdenDTO> ordenes;

        public ObservableCollection<OrdenDTO> Ordenes
        {
            get => ordenes;
            set => SetProperty(ref ordenes, value);
        }

        public Command LoadOrdenesCommand { get; }
        public Command<OrdenDTO> ItemTapped { get; }
        public Command OnAddItemCommand { get; }

        public OrdenesAmbulantesViewModel()
        {
            LoadOrdenesCommand = new Command(async () => await LoadOrdenes());

            ItemTapped = new Command<OrdenDTO>(OnItemSelected);
            OnAddItemCommand = new Command(async () => await AddItem());


            Usuario = JsonConvert.DeserializeObject<UsuarioDTO>(Settings.LoggedInUser);

            Task.Run(async () => await LoadOrdenes());

        }

        async Task LoadOrdenes()
        {
            IsBusy = true;

            

                var response = await _IHttpService.Get<List<OrdenDTO>>($"/api/Orden/GetAll/{Usuario.Empresas.SingleOrDefault().Id}?TipoOrdenId={3}&MesaId={null}");
                if (response.Error)
                {
                IsBusy = false;

                if (response.ResponseMessage.Content != null)
                {
                    var mensaje = await response.ResponseMessage.Content.ReadAsStringAsync();
                    switch (string.IsNullOrWhiteSpace(mensaje))
                    {
                        case true:
                            await Application.Current.MainPage.DisplayAlert("Error", response.ResponseMessage.ReasonPhrase, "Ok");
                            break;
                        case false:
                            await Application.Current.MainPage.DisplayAlert("Error", mensaje, "Ok");
                            break;
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", response.ResponseMessage.ReasonPhrase, "Ok");
                }
            }
            else
            {
                Ordenes = new ObservableCollection<OrdenDTO>(response.Data);

            }
            IsBusy = false;
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
            LoadOrdenesCommand.Execute(null);
        }

        public async Task AddItem()
        {
            await Shell.Current.GoToAsync(nameof(ItemDetailPage));
        }

        public OrdenDTO SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }



        async void OnItemSelected(OrdenDTO item)
        {
            if (item == null)
                return;
            
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.OrdenId)}={item.Id}");
            
        }



    }
}
