using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using ASCamarerosApp.Models;
using ASCamarerosApp.Views;
using Shared.DTOs;
using System.Collections.Generic;
using ASCamarerosApp.Helpers;
using Newtonsoft.Json;
using System.Linq;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.CommunityToolkit.Extensions;

namespace ASCamarerosApp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private MesaDTO _selectedItem;
        private UsuarioDTO Usuario { get; set; }
        Settings Settings = new Settings();
        private ObservableCollection<AreaDTO> areas;

        public ObservableCollection<AreaDTO> Areas
        {
            get =>  areas;
            set => SetProperty(ref areas, value);
        }
        
        public ObservableCollection<TabViewItem> TabViewItems { get; set; } = new ObservableCollection<TabViewItem>();
        public Command LoadAreasCommand { get; }
        public Command<MesaDTO> ItemTapped { get; }

        public ItemsViewModel()
        {
            LoadAreasCommand = new Command(async () => await ExecuteLoadAreasCommand());

            ItemTapped = new Command<MesaDTO>(OnItemSelected);

            
            Usuario = JsonConvert.DeserializeObject<UsuarioDTO>(Settings.LoggedInUser);

            Task.Run(async () => await ExecuteLoadAreasCommand());

        }

        async Task ExecuteLoadAreasCommand()
        {
            IsBusy = true;

                var response = await _IHttpService.Get<List<AreaDTO>>($"/api/Area/GetAll/{Usuario.Empresas.FirstOrDefault().Id}/{Usuario.Sucursales.FirstOrDefault().Id}");
                if(response.Error)
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
                    Areas = new ObservableCollection<AreaDTO>(response.Data);
                    
                }
                IsBusy = false;
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
            LoadAreasCommand.Execute(null);
        }

        public MesaDTO SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        

        async void OnItemSelected(MesaDTO item)
        {
            if (item == null)
                return;
            if (item.Ordenes.Count == 0)
            {
                // This will push the ItemDetailPage onto the navigation stack
                await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.MesaId)}={item.Id}");
            }
            else
            {
                await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.OrdenId)}={item.Ordenes.SingleOrDefault().Id}");
            }
        }
    }
}
