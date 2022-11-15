using System;
using System.Collections.Generic;
using ASCamarerosApp.Helpers;
using ASCamarerosApp.ViewModels;
using ASCamarerosApp.Views;
using Newtonsoft.Json;
using Shared.DTOs;
using Xamarin.Forms;

namespace ASCamarerosApp
{
    public partial class AppShell : Shell
    {

        

        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(AcercaDePage), typeof(AcercaDePage));

            
        }

    }
}
