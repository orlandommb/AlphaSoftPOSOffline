using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ASCamarerosApp.Models;
using Shared.DTOs;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.UI.Views.Internals;
using Xamarin.CommunityToolkit.Extensions;
using ASCamarerosApp.Helpers;
using Newtonsoft.Json;
using System.Linq;

namespace ASCamarerosApp.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private Settings settings = new Settings();
        private UsuarioDTO usuario;
        private OrdenDetalleDTO ordendetalle = new OrdenDetalleDTO();
        private ObservableCollection<ProductoDTO> productos;
        private ObservableCollection<CategoriaDTO> categorias = new ObservableCollection<CategoriaDTO>();
        private CategoriaDTO selectedcategoria = new CategoriaDTO();

        public Command SaveCommand { get; }
        public Command LoadProductosCommand { get; }
        public Command LoadCategoriasCommand { get; }
        public Command ProductoTappedCommand { get; }
        public Command CategoriaTappedCommand { get; }
        public Command OnNumericValueChangeCommand { get; }

        public NewItemViewModel()
        {
            LoadCategoriasCommand = new Command(async () => await LoadCategorias());
            SelectedDetalle.Cantidad = 1;
            Usuario = JsonConvert.DeserializeObject<UsuarioDTO>(settings.LoggedInUser);
            LoadProductosCommand = new Command(async ()=> await LoadProductos());
            ProductoTappedCommand = new Command<ProductoDTO>(OnItemSelected);
            CategoriaTappedCommand = new Command<CategoriaDTO>(OnCategoriaSelected);
            OnNumericValueChangeCommand = new Command<double>(args => OnNumericChange(args));


            Task.Run(async () => await LoadProductos());
            Task.Run(async () => await LoadCategorias());

        }

        private void OnItemSelected(ProductoDTO obj)
        {
            if (obj == null)
                return;

            SelectedDetalle = new OrdenDetalleDTO()
            {
                Producto = obj,
                ProductoId = obj.Id,
                NombreProducto = obj.Nombre,
                Precio = obj.Precio,
                Cantidad = 1,
                Importe = obj.Precio
            };
        }

        private async void OnCategoriaSelected(CategoriaDTO obj)
        {
            if (obj == null)
                return;

            SelectedCategoria = obj;
            await LoadProductos();
        }

        private void OnNumericChange(double obj)
        {
            if (obj == 0)
                return;
            SelectedDetalle.Importe = (decimal)obj * SelectedDetalle.Precio;
        }

        public UsuarioDTO Usuario
        {
            get => usuario;
            set => SetProperty(ref usuario, value);
        }

        public OrdenDetalleDTO SelectedDetalle
        {
            get => ordendetalle;
            set => SetProperty(ref ordendetalle, value);
        }

        public CategoriaDTO SelectedCategoria
        {
            get => selectedcategoria;
            set => SetProperty(ref selectedcategoria, value);
        }

        public ObservableCollection<ProductoDTO> Productos
        {
            get => productos;
            set => SetProperty(ref productos, value);
        }

        public ObservableCollection<CategoriaDTO> Categorias
        {
            get => categorias;
            set => SetProperty(ref categorias, value);
        }

        public async Task LoadProductos()
        {
            try
            {
                IsBusy = true;

                StringBuilder Query = new StringBuilder();
                if (SelectedCategoria.Id != 0)
                    Query.Append("CategoriaId=" + SelectedCategoria.Id);

                try
                {
                    var response = await _IHttpService.Get<List<ProductoDTO>>($"/api/Producto/GetAll/{Usuario.Empresas.SingleOrDefault().Id}?{Query}");
                    if (response.Error)
                    {
                        IsBusy = false;
                        var mensaje = await response.ResponseMessage.Content.ReadAsStringAsync();
                        await Application.Current.MainPage.DisplayAlert("Error", mensaje, "Ok");
                    }
                    else
                    {
                        Productos = new ObservableCollection<ProductoDTO>(response.Data);

                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    await Application.Current.MainPage.DisplayAlert("Error", ex.InnerException.Message, "Ok");

                }
                finally
                {
                    IsBusy = false;
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        public async Task LoadCategorias()
        {
            try
            {
                IsBusy = true;

                try
                {
                    var response = await _IHttpService.Get<List<CategoriaDTO>>($"/api/Categoria/GetAll/{Usuario.Empresas.SingleOrDefault().Id}");
                    if (response.Error)
                    {
                        IsBusy = false;
                        var mensaje = await response.ResponseMessage.Content.ReadAsStringAsync();
                        await Application.Current.MainPage.DisplayAlert("Error", mensaje, "Ok");
                    }
                    else
                    {
                        Categorias = new ObservableCollection<CategoriaDTO>(response.Data);

                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    await Application.Current.MainPage.DisplayAlert("Error", ex.InnerException.Message, "Ok");

                }
                finally
                {
                    IsBusy = false;
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

    }
}
