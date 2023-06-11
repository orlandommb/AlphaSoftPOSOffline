using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AlphaSoftPOSOffline.Models;

namespace AlphaSoftPOSOffline.Data
{
    public class ApplicationDbContext : IdentityDbContext<Usuario, Rol, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }


        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<OrdenDetalle> OrdenDetalles { get; set; }
        public DbSet<OrdenDetalleHistorial> OrdenDetalleHistoriales { get; set; }
        //DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Cuadre> Cuadres { get; set; }
        public DbSet<TipoOrden> TipoOrdenes { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<VentaDetalle> VentaDetalles { get; set; }
        public DbSet<Sector> Sectores { get; set; }
        public DbSet<Denominacion> Denominaciones { get; set; }
        public DbSet<TipoDenominacion> TipoDenominaciones { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Desglose> Desgloses { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<SubCategoria> SubCategorias { get; set; }
        public DbSet<OrdenVenta> OrdenVentas { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Almacen> Almacenes { get; set; }
        public DbSet<Existencia> Existencias { get; set; }
        public DbSet<Suplidor> Suplidores { get; set; }
        public DbSet<TipoFactura> TipoFacturas { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<CompraDetalle> CompraDetalles { get; set; }
        public DbSet<TipoCompra> TipoCompras { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<CXCVentaBalance> CXCVentaBalances { get; set; }
        public DbSet<CXCTransaccion> CXCTransacciones {get; set;}
        public DbSet<CXCTransaccionDetalle> CXCTransaccionDetalles {get; set;}
        public DbSet<CXCTransaccionTipo> CXCTransaccionTipos {get; set;}
        public DbSet<CXCTransaccionTipoDocumento> CXCTransaccionTipoDocumentos {get; set;}
        
        public DbSet<CXPCompraBalance> CXPCompraBalances { get; set; }
        public DbSet<CXPTransaccion> CXPTransacciones {get; set;}
        public DbSet<CXPTransaccionDetalle> CXPTransaccionDetalles {get; set;}
        public DbSet<CXPTransaccionTipo> CXPTransaccionTipos {get; set;}
        public DbSet<CXPTransaccionTipoDocumento> CXPTransaccionTipoDocumentos {get; set;}

        public DbSet<UsuarioEmpresa> UsuarioEmpresas { get; set; }
        public DbSet<UsuarioSucursal> UsuarioSucursales { get; set; }

        public DbSet<VentaDevolucion> VentaDevoluciones { get; set; }
        public DbSet<VentaDevolucionDetalle> VentaDevolucionDetalles { get; set; }

        public DbSet<AjusteInventarioTipo> AjusteInventarioTipos { get; set; }
        public DbSet<AjusteInventario> AjustesInventario { get; set; }
        public DbSet<AjusteInventarioDetalle> AjusteInventarioDetalles { get; set; }
        public DbSet<Impuesto> Impuestos { get; set; }
        public DbSet<ImpuestoTipo> ImpuestoTipos { get; set; }
    }
}
