using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using POSPedidoYFacturacion.Data;
using POSPedidoYFacturacion.Models;
using POSPedidoYFacturacion.Utilidades;

namespace POSPedidoYFacturacion
{
    public class EstadoOrden
    {

        public EstadoOrden()
        {

        }

        public Orden Orden { get; private set; } = new Orden();

        public OrdenDetalle Detalle { get; private set; } = new OrdenDetalle();

        public Producto Producto { get; private set; } = new Producto();

        public bool ShowModalAgregarDetalle { get; set; } = false;

        public bool ShowModalOrden { get; set; } = false;

        public void SeleccionarProducto(Producto Item)
        {
            Detalle = new OrdenDetalle()
            {
                Producto = Item,
                ProductoId = Item.Id,
                NombreProducto = Item.Nombre,
                Precio = Item.Precio,
                Cantidad = 1
            };

            ShowModalAgregarDetalle = true;
        }

        public void SeleccionarDetalle(OrdenDetalle Item)
        {
            
                Detalle = Item;

                ShowModalAgregarDetalle = true;
            
        }



        public void CerrarModalOrdenDetalle()
        {
            if (ShowModalAgregarDetalle == true)
            {
                ShowModalAgregarDetalle = false;
                Detalle = new OrdenDetalle();
            }
        }

        public void CerrarModalOrden()
        {
            if (ShowModalOrden == true)
            {
                ShowModalOrden = false;
            }
        }

        public void AbrirModalOrdenDetalle()
        {
            if (ShowModalAgregarDetalle == false)
            {
                ShowModalAgregarDetalle = true;
            }
        }

        public void AbrirModalOrden()
        {
            if (ShowModalOrden== false)
            {
                ShowModalOrden = true;
            }
        }

        public void NuevaOrden()
        {
            Orden = new Orden();
        }



        public void AgregarOrden()
        {
            if (Detalle.Cantidad <= 0)
                {
                    Detalle.Cantidad = 1;
                    return;
                }

            if (Detalle.Importe < 0)
            {
                return;
            }

            var Prod = Orden.OrdenDetalles.SingleOrDefault(p => p.ProductoId == Detalle.ProductoId);
            if (Prod == null)
            {
                
                Orden.OrdenDetalles.Add(Detalle);
                Detalle = null;
            }
            else
            {
                
                    Prod.Cantidad = Detalle.Cantidad;
                    Prod.Precio = Detalle.Precio;
                    Prod.Descuento = Detalle.Descuento;
                    Prod.Importe = Detalle.Importe;
                

                //if (Detalle.Cantidad <= 0)
                //{
                //    Orden.OrdenDetalles.Remove(Prod);
                //}
                //else
                //{
                //    Prod.Cantidad = Detalle.Cantidad;
                //    Prod.Precio = Detalle.Precio;
                //    Prod.Descuento = Detalle.Descuento;
                //    Prod.Importe = Detalle.Importe;
                //}
            }

            ShowModalAgregarDetalle = false;
        }

        public void RemoverProductodeOrden()
        {
            var Prod = Orden.OrdenDetalles.SingleOrDefault(p => p.ProductoId == Detalle.ProductoId);
            if (Prod != null)
            {
                Orden.OrdenDetalles.Remove(Prod);
                CerrarModalOrdenDetalle();
            }
        }

        public void CargarOrden( Orden OrdenParameter)
        {
                Orden = OrdenParameter;
        }
        

    }
}
