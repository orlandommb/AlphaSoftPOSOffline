using System.ComponentModel;
using Xamarin.Forms;
using ASCamarerosApp.ViewModels;

namespace ASCamarerosApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
