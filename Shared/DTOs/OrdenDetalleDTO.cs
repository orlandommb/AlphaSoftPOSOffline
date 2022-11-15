using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shared.DTOs
{
    public class OrdenDetalleDTO : BaseDTO
    {
        private int id;
        private int ordenid;
        private OrdenDTO orden;
        private int productoid;
        private ProductoDTO producto;
        private string nombreproducto;
        private int cantidad;
        private decimal descuento;
        private decimal precio;
        private decimal importe;

        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public int OrdenId
        {
            get => ordenid;
            set => SetProperty(ref ordenid, value);
        }

        public OrdenDTO Orden
        {
            get => orden;
            set => SetProperty(ref orden, value);
        }

        public int ProductoId
        {
            get => productoid;
            set => SetProperty(ref productoid, value);
        }

        public ProductoDTO Producto
        {
            get => producto;
            set => SetProperty(ref producto, value);
        }

        public string NombreProducto
        {
            get => nombreproducto;
            set => SetProperty(ref nombreproducto, value);
        }

        public int Cantidad
        {
            get => cantidad;
            set => SetProperty(ref cantidad, value);
        }

        public decimal Descuento
        {
            get => descuento;
            set => SetProperty(ref descuento, value);
        }

        public decimal Precio
        {
            get => precio;
            set => SetProperty(ref precio, value);
        }

        public decimal Importe
        {
            get => importe;
            set => SetProperty(ref importe, value);
        }
    }
}