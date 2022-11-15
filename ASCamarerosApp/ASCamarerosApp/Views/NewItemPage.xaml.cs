using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ASCamarerosApp.Models;
using ASCamarerosApp.ViewModels;
using Xamarin.CommunityToolkit.UI.Views;
using Shared.DTOs;

namespace ASCamarerosApp.Views
{
    public partial class NewItemPage : Popup<OrdenDetalleDTO>
    {

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();

        }

        void ButtonCancelar_Clicked(System.Object sender, System.EventArgs e)
        {
            Dismiss(null);
        }

        async void ButtonSave_Clicked_1(System.Object sender, System.EventArgs e)
        {
            var VM = (BindingContext as NewItemViewModel);
            if (VM.SelectedDetalle.ProductoId == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Alert","Seleccione un producto!", "Ok");
            }
            else
            {
                Dismiss(VM.SelectedDetalle);
                VM.SelectedDetalle = new OrdenDetalleDTO();
            }
            
        }

    }
}
