using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shared.DTOs
{
    public class OrdenDTO : BaseDTO
    {
        private int id;
        private int empresaid;
        private EmpresaDTO empresa;
        private int sucursalid;
        private SucursalDTO sucursal;
        private int tipordenid;
        private TipoOrdenDTO tipoorden;
        private int? clienteid;
        private ClienteDTO cliente;
        private int? mesaid;
        private MesaDTO mesa;
        private bool nulo;
        private bool facturado;
        private DateTime fechapedido;
        private DateTime? fechaenproceso;
        private DateTime? fechafinalizado;
        private string usuarioid;
        private UsuarioDTO usuario;
        private string nombrecliente;
        private string celularcliente;
        private int? sectorid;
        private SectorDTO sector;
        private string direccioncliente;
        private decimal montodelivery;
        private decimal subtotal;
        private decimal descuento;
        private decimal impuesto;
        private decimal total;
        private ObservableCollection<OrdenDetalleDTO> ordendetalles = new ObservableCollection<OrdenDetalleDTO>();

        public int Id
        {
            get=>id;
            set=>SetProperty(ref id, value);
        }

        public int EmpresaId
        {
            get => empresaid;
            set=> SetProperty(ref empresaid, value);
        }

        public EmpresaDTO Empresa
        {
            get=>empresa;
            set=>SetProperty(ref empresa, value);
        }

        public int SucursalId
        {
            get =>sucursalid;
            set =>SetProperty(ref sucursalid, value);
        }

        public SucursalDTO Sucursal
        {
            get =>sucursal;
            set => SetProperty(ref sucursal, value);
        }

        public int TipoOrdenId
        {
            get => tipordenid;
            set => SetProperty(ref tipordenid, value);
        }

        public TipoOrdenDTO TipoOrden
        {
            get => tipoorden;
            set => SetProperty(ref tipoorden, value);
        }
        public int? ClienteId
        {
            get => clienteid;
            set => SetProperty(ref clienteid, value);
        }

        public ClienteDTO Cliente
        {
            get => cliente;
            set => SetProperty(ref cliente, value);
        }

        public int? MesaId
        {
            get => mesaid;
            set => SetProperty(ref mesaid, value);
        }

        public MesaDTO Mesa
        {
            get => mesa;
            set => SetProperty(ref mesa, value);
        }

        public bool Nulo
        {
            get => nulo;
            set => SetProperty(ref nulo, value);
        }

        public bool Facturado
        {
            get => facturado;
            set => SetProperty(ref facturado, value);
        }

        public DateTime FechaPedido
        {
            get => fechapedido;
            set => SetProperty(ref fechapedido, value);
        }
        public DateTime? FechaEnProceso
        {
            get => fechaenproceso;
            set => SetProperty(ref fechaenproceso, value);
        }
        public DateTime? FechaFinalizado
        {
            get => fechafinalizado;
            set => SetProperty(ref fechafinalizado, value);
        }

        public string UsuarioId
        {
            get => usuarioid;
            set => SetProperty(ref usuarioid, value);
        }

        public UsuarioDTO Usuario
        {
            get => usuario;
            set => SetProperty(ref usuario, value);
        }

        public string NombreCliente
        {
            get => nombrecliente;
            set => SetProperty(ref nombrecliente, value);
        }

        public string CelularCliente
        {
            get => celularcliente;
            set => SetProperty(ref celularcliente, value);
        }

        public int? SectorId
        {
            get => sectorid;
            set => SetProperty(ref sectorid, value);
        }
        public SectorDTO Sector
        {
            get => sector;
            set => SetProperty(ref sector, value);
        }

        public string DireccionCliente
        {
            get => direccioncliente;
            set => SetProperty(ref direccioncliente, value);
        }

        public decimal MontoDelivery
        {
            get => montodelivery;
            set => SetProperty(ref montodelivery, value);
        }

        public decimal SubTotal
        {
            get => subtotal;
            set => SetProperty(ref subtotal, value);
        }
        public decimal Descuento
        {
            get => descuento;
            set => SetProperty(ref descuento, value);
        }
        public decimal Impuesto
        {
            get => impuesto;
            set => SetProperty(ref impuesto, value);
        }
        public decimal Total
        {
            get => total;
            set => SetProperty(ref total, value);
        }

        public ObservableCollection<OrdenDetalleDTO> OrdenDetalles
        {
            get => ordendetalles;
            set => SetProperty(ref ordendetalles, value);
        }
    }
}