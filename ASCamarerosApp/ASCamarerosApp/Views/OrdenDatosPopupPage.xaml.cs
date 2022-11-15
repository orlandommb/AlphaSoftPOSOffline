using System;
using System.Collections.Generic;
using ASCamarerosApp.ViewModels;
using Shared.DTOs;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace ASCamarerosApp.Views
{
    public partial class OrdenDatosPopupPage : Popup<OrdenDTO>
    {
        public OrdenDatosPopupPage(int? MesaId)
        {
            InitializeComponent();
            this.MesaId = MesaId;
            BindingContext = new OrdenDatosViewModel(MesaId);
        }

        public int? MesaId { get; }

        async void BtnAceptar_Clicked(System.Object sender, System.EventArgs e)
        {
            var VM = BindingContext as OrdenDatosViewModel;

            if(VM.Orden.TipoOrdenId == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Alerta", "Debe seleccionar un tipo de Orden", "Ok");
                return;
            }

            Dismiss(VM.Orden);
        }
    }
}
