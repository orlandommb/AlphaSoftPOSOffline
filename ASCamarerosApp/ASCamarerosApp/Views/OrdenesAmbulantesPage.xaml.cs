using System;
using System.Collections.Generic;
using ASCamarerosApp.ViewModels;
using Xamarin.Forms;

namespace ASCamarerosApp.Views
{
    public partial class OrdenesAmbulantesPage : ContentPage
    {

        OrdenesAmbulantesViewModel VM;

        public OrdenesAmbulantesPage()
        {
            InitializeComponent();
            BindingContext = VM = new OrdenesAmbulantesViewModel();
        }

        protected override void OnAppearing()
        {
            VM.OnAppearing();
            base.OnAppearing();
        }
    }
}
