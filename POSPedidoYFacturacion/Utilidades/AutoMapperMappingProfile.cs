using System;
using AutoMapper;
using POSPedidoYFacturacion.Models;
using Shared.DTOs;

namespace POSPedidoYFacturacion.Utilidades
{
    public class AutoMapperMappingProfile : Profile
    {
        public AutoMapperMappingProfile()
        {
            //Empresa
            CreateMap<Empresa, EmpresaDTO>();
            CreateMap<EmpresaDTO, Empresa>();

            //Sucursal
            CreateMap<Sucursal, SucursalDTO>();
            CreateMap<SucursalDTO, Sucursal>();

            //Area
            CreateMap<Area, AreaDTO>();
            CreateMap<AreaDTO, Area>();

            //Categoria
            CreateMap<Categoria, CategoriaDTO>();
            CreateMap<CategoriaDTO, Categoria>();

            //Cliente
            CreateMap<Cliente, ClienteDTO>();
            CreateMap<ClienteDTO, Cliente>();

            //Mesa
            CreateMap<Mesa, MesaDTO>();
            CreateMap<MesaDTO, Mesa>();

            //Orden
            CreateMap<Orden, OrdenDTO>();
            CreateMap<OrdenDTO, Orden>();

            //OrdenDetalle
            CreateMap<OrdenDetalle, OrdenDetalleDTO>();
            CreateMap<OrdenDetalleDTO, OrdenDetalle>();

            //Producto
            CreateMap<Producto, ProductoDTO>();
            CreateMap<ProductoDTO, Producto>();

            //Sector
            CreateMap<Sector, SectorDTO>();
            CreateMap<SectorDTO, Sector>();

            //SubCategoria
            CreateMap<SubCategoria, SubCategoriaDTO>();
            CreateMap<SubCategoriaDTO, SubCategoria>();

            //TipoOrden
            CreateMap<TipoOrden, TipoOrdenDTO>();
            CreateMap<TipoOrdenDTO, TipoOrden>();

            //Usuario
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<UsuarioDTO, Usuario>();
        }
    }
}
