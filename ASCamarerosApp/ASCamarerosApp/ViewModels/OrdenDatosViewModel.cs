using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ASCamarerosApp.Helpers;
using Newtonsoft.Json;
using Shared.DTOs;
using Xamarin.Forms;

namespace ASCamarerosApp.ViewModels
{
    public class OrdenDatosViewModel : BaseViewModel
    {
        Settings Settings = new Settings();

        private OrdenDTO orden = new OrdenDTO();
        private ObservableCollection<ClienteDTO> clientes;
        private ObservableCollection<TipoOrdenDTO> tipoordenes = new ObservableCollection<TipoOrdenDTO>();
        private UsuarioDTO usuario;
        private int? mesaid;
        private bool isreadony;

        public OrdenDTO Orden
        {
            get => orden;
            set => SetProperty(ref orden, value);
        }

        public ObservableCollection<ClienteDTO> Clientes
        {
            get => clientes;
            set => SetProperty(ref clientes, value);
        }

        public ObservableCollection<TipoOrdenDTO> TipoOrdenes
        {
            get => tipoordenes;
            set => SetProperty(ref tipoordenes, value);
        }

        public UsuarioDTO Usuario
        {
            get => usuario;
            set => SetProperty(ref usuario, value);
        }
        public int? MesaId
        {
            get => mesaid;
            set
            {
                SetProperty(ref mesaid, value);
                if(value != null)
                    CargarMesaCommand.Execute(null);
            }
        }

        public bool IsReadOnly
        {
            get => isreadony;
            set
            {
                SetProperty(ref isreadony, value);
            }
        }

        public Command CargarClientesCommand { get; set; }
        public Command CargarMesaCommand { get; set; }
        public Command OnClienteChangedCommand { get; set; }
        public Command OnTipoOrdenChangedCommand { get; set; }
        public Command CargarTipoOrdenesCommand { get; set; }
        

        public OrdenDatosViewModel(int? _MesaId)
        {
            Orden.TipoOrdenId = 3;
            Usuario = JsonConvert.DeserializeObject<UsuarioDTO>(Settings.LoggedInUser);
            Orden.EmpresaId = Usuario.Empresas.SingleOrDefault().Id;
            Orden.SucursalId = Usuario.Sucursales.SingleOrDefault().Id;
            CargarMesaCommand = new Command(async ()=> await CargarMesa());
            MesaId = _MesaId;

            Orden.MesaId = MesaId;

            Orden.FechaPedido = DateTime.Now;

            Orden.UsuarioId = Usuario.Id;

            CargarClientesCommand = new Command(async () => await CargarClientes());
            CargarTipoOrdenesCommand = new Command(async () => await CargarTiposOrdenes());
            OnClienteChangedCommand = new Command<string>((string obj) => OnClienteChanged(obj));
            OnTipoOrdenChangedCommand = new Command(OnTipoOrdenChanged);
            CargarTipoOrdenesCommand.Execute(null);
            CargarClientesCommand.Execute(null);
            

            
        }

        public OrdenDatosViewModel()
        {

        }

        public void OnClienteChanged(string Nombre)
        {
            if (!string.IsNullOrWhiteSpace(Nombre))
            {
                Orden.NombreCliente = Nombre;
                IsReadOnly = true;
            }
        }

        public void OnTipoOrdenChanged()
        {

            Orden.TipoOrden = TipoOrdenes.SingleOrDefault(tp => tp.Id == 3);
            Orden.TipoOrdenId = 3;
        }


        public async Task CargarMesa()
        {

            try
            {
                IsBusy = true;

                try
                {
                    var response = await _IHttpService.Get<MesaDTO>($"/api/Mesa/{MesaId}");
                    if (response.Error)
                    {
                        IsBusy = false;
                        var mensaje = await response.ResponseMessage.Content.ReadAsStringAsync();
                        await Application.Current.MainPage.DisplayAlert("Error", mensaje, "Ok");
                    }
                    else
                    {
                        Orden.Mesa = response.Data;

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

        public async Task CargarClientes()
        {

            try
            {
                IsBusy = true;

                try
                {
                    var response = await _IHttpService.Get<List<ClienteDTO>>($"/api/Cliente/GetAll/{Usuario.Empresas.SingleOrDefault().Id}");
                    if (response.Error)
                    {
                        IsBusy = false;
                        var mensaje = await response.ResponseMessage.Content.ReadAsStringAsync();
                        await Application.Current.MainPage.DisplayAlert("Error", mensaje, "Ok");
                    }
                    else
                    {
                        Clientes = new ObservableCollection<ClienteDTO>(response.Data);

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

        public async Task CargarTiposOrdenes()
        {

            try
            {
                IsBusy = true;

                try
                {
                    var response = await _IHttpService.Get<List<TipoOrdenDTO>>($"/api/TipoOrden");
                    if (response.Error)
                    {
                        IsBusy = false;
                        var mensaje = await response.ResponseMessage.Content.ReadAsStringAsync();
                        await Application.Current.MainPage.DisplayAlert("Error", mensaje, "Ok");
                    }
                    else
                    {
                        if (MesaId != 0)
                        {
                            var OrdenConsumoLocal = response.Data.SingleOrDefault(tp => tp.Nombre == "Consumo Local");
                            TipoOrdenes.Add(OrdenConsumoLocal);
                        }
                        else
                        {
                            TipoOrdenes = new ObservableCollection<TipoOrdenDTO>(response.Data);

                        }
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
