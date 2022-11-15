using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ASCamarerosApp.Helpers;
using ASCamarerosApp.Models;
using ASCamarerosApp.Views;
using Newtonsoft.Json;
using Shared.DTOs;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace ASCamarerosApp.ViewModels
{
    [QueryProperty(nameof(MesaId), nameof(MesaId))]
    [QueryProperty(nameof(OrdenId), nameof(OrdenId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private Settings Settings = new Settings();
        private OrdenDTO orden = new();
        private int mesaid;
        private int ordenid;
        private UsuarioDTO usuario;

        public string Id { get; set; }


        public Command RegistroOrdenCommand { get; }
        public Command AddItemCommand { get; }
        public Command MostrarDatosOrdenCommand { get; }

        public OrdenDTO Orden
        {
            get => orden;
            set => SetProperty(ref orden, value);
        }

        public int MesaId
        {
            get
            {
                return mesaid;
            }
            set
            {
                SetProperty(ref mesaid, value);
                if (value != 0)
                    MostrarDatosOrdenCommand.Execute(value);
            }
        }

        public int OrdenId
        {
            get
            {
                return ordenid;
            }
            set
            {
                SetProperty(ref ordenid, value);
                LoadItemId(value);
            }
        }

        public UsuarioDTO Usuario
        {
            get => usuario;
            private set => SetProperty(ref usuario, value);
        }

        public ItemDetailViewModel()
        {
            Usuario = JsonConvert.DeserializeObject<UsuarioDTO>(Settings.LoggedInUser);
            Orden.EmpresaId = Usuario.Empresas.SingleOrDefault().Id;
            Orden.SucursalId = Usuario.Sucursales.SingleOrDefault().Id;
            RegistroOrdenCommand = new Command(async () => await RegistrarOrden());
            AddItemCommand = new Command(OnAddItem);
            MostrarDatosOrdenCommand = new Command<int?>(async args => await MostrarDatosOrden(args));
            Orden.FechaPedido = DateTime.Now;
            Orden.TipoOrdenId = 3;
            Orden.UsuarioId = Usuario.Id;
            
        }

        public async Task MostrarDatosOrden(int? MesaId)
        {
            var result = await Application.Current.MainPage.Navigation.ShowPopupAsync(new OrdenDatosPopupPage(MesaId));
            if (result == null)
                return;
            Orden = result;
            Orden.FechaPedido = DateTime.Now;
        }

        public async void LoadItemId(int OrdenId)
        {
            try
            {
                IsBusy = true;

                try
                {
                    var response = await _IHttpService.Get<OrdenDTO>($"/api/Orden/{OrdenId}");
                    if (response.Error)
                    {
                        IsBusy = false;
                        var mensaje = await response.ResponseMessage.Content.ReadAsStringAsync();
                        await Application.Current.MainPage.DisplayAlert("Error", mensaje, "Ok");
                    }
                    else
                    {
                        Orden = response.Data;

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

        public async Task RegistrarOrden()
        {
            try
            {
                //if (MesaId == 0 && Orden.Id == 0)
                //{
                //    MostrarDatosOrdenCommand.Execute(null);
                //}

                //if (Orden.TipoOrdenId == 0)
                //{
                //    MostrarDatosOrdenCommand.Execute(null);
                //}

                
                IsBusy = true;

                try
                {
                    var response = await _IHttpService.Post(Orden, $"/api/Orden/RegistrarOrden");
                    if (response.Error)
                    {
                        IsBusy = false;
                        var mensaje = await response.ResponseMessage.Content.ReadAsStringAsync();
                        await Application.Current.MainPage.DisplayAlert("Error", mensaje, "Ok");
                    }
                    else
                    {
                        var mensaje = await response.ResponseMessage.Content.ReadAsStringAsync();
                        await Application.Current.MainPage.DisplayAlert("Exito !", mensaje, "Ok");
                        await Application.Current.MainPage.Navigation.PopAsync();
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



        private async void OnAddItem(object obj)
        {

            var ordendetalle = await Application.Current.MainPage.Navigation.ShowPopupAsync(new NewItemPage());
            IsBusy = true;
            if (ordendetalle == null)
                return;
            var productoexist = Orden.OrdenDetalles.SingleOrDefault(c => c.ProductoId == ordendetalle.ProductoId);
            if (productoexist == null)
            {
                Orden.OrdenDetalles.Add(ordendetalle);
            }
            else
            {
                productoexist.Precio = ordendetalle.Precio;
                productoexist.Descuento = ordendetalle.Descuento;
                productoexist.Cantidad += ordendetalle.Cantidad;
                productoexist.Importe = productoexist.Cantidad * productoexist.Precio;

            }

            Orden.SubTotal = Orden.OrdenDetalles.Sum(od => od.Precio * od.Cantidad);
            Orden.Descuento = Orden.OrdenDetalles.Sum(od => od.Descuento);
            Orden.Total = Orden.OrdenDetalles.Sum(od => od.Importe);
            IsBusy = false;
        }
    }
}
