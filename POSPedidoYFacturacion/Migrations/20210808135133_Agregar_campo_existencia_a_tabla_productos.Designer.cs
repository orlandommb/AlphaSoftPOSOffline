﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using POSPedidoYFacturacion.Data;

namespace POSPedidoYFacturacion.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210808135133_Agregar_campo_existencia_a_tabla_productos")]
    partial class Agregar_campo_existencia_a_tabla_productos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.Cuadre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Cerrado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaApertura")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaCierre")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("FondoCaja")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MontoEfectivo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Cuadres");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.Denominacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TipoMonedaId")
                        .HasColumnType("int");

                    b.Property<int>("Valor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoMonedaId");

                    b.ToTable("Denominaciones");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.Desglose", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("CuadreId")
                        .HasColumnType("int");

                    b.Property<int>("DenominacionId")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CuadreId");

                    b.HasIndex("DenominacionId");

                    b.ToTable("Desgloses");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Direccion")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("FechaVencimientoServicio")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ImprimirLogoEnFactura")
                        .HasColumnType("bit");

                    b.Property<bool>("ImprimirLogoEnOrden")
                        .HasColumnType("bit");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("MontoMinimoDelivery")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Nombre")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoOrdenPredeterminada")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.Mesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PosicionX")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PosicionY")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.ToTable("Mesas");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.Orden", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CelularCliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Descuento")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("DireccionCliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Facturado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaEnProceso")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaFinalizado")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaPedido")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Impuesto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("MesaId")
                        .HasColumnType("int");

                    b.Property<decimal>("MontoDelivery")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NombreCliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Nulo")
                        .HasColumnType("bit");

                    b.Property<int?>("SectorId")
                        .HasColumnType("int");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TipoOrdenId")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("MesaId");

                    b.HasIndex("SectorId");

                    b.HasIndex("TipoOrdenId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Ordenes");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.OrdenDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<decimal>("Descuento")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Importe")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NombreProducto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrdenId")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrdenId");

                    b.HasIndex("ProductoId");

                    b.ToTable("OrdenDetalles");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.OrdenVenta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrdenId")
                        .HasColumnType("int");

                    b.Property<int>("VentaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrdenId");

                    b.HasIndex("VentaId");

                    b.ToTable("OrdenVentas");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ImageString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ManejaExistencia")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SubCategoriaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("SubCategoriaId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.Rol", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.Sector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("MontoDelivery")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sectores");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.SubCategoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("SubCategorias");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.TipoDenominacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoDenominaciones");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.TipoOrden", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoOrdenes");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.Venta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CelularCliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CuadreId")
                        .HasColumnType("int");

                    b.Property<decimal>("Delivery")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Descuento")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("DireccionCliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Facturado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaEnProceso")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaFinalizado")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaPedido")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Impuesto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MontoEfectivo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NombreCliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Nulo")
                        .HasColumnType("bit");

                    b.Property<int?>("SectorId")
                        .HasColumnType("int");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TipoOrdenId")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CuadreId");

                    b.HasIndex("SectorId");

                    b.HasIndex("TipoOrdenId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.VentaDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<decimal>("Descuento")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Importe")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NombreProducto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<int>("VentaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.HasIndex("VentaId");

                    b.ToTable("VentaDetalles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("POSPedidoYFacturacion.Models.Rol", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("POSPedidoYFacturacion.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("POSPedidoYFacturacion.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("POSPedidoYFacturacion.Models.Rol", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POSPedidoYFacturacion.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("POSPedidoYFacturacion.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.Cuadre", b =>
                {
                    b.HasOne("POSPedidoYFacturacion.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.Denominacion", b =>
                {
                    b.HasOne("POSPedidoYFacturacion.Models.TipoDenominacion", "TipoMoneda")
                        .WithMany()
                        .HasForeignKey("TipoMonedaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoMoneda");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.Desglose", b =>
                {
                    b.HasOne("POSPedidoYFacturacion.Models.Cuadre", "Cuadre")
                        .WithMany("Desgloses")
                        .HasForeignKey("CuadreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POSPedidoYFacturacion.Models.Denominacion", "Denominacion")
                        .WithMany()
                        .HasForeignKey("DenominacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuadre");

                    b.Navigation("Denominacion");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.Mesa", b =>
                {
                    b.HasOne("POSPedidoYFacturacion.Models.Area", "Area")
                        .WithMany("Mesas")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.Orden", b =>
                {
                    b.HasOne("POSPedidoYFacturacion.Models.Mesa", "Mesa")
                        .WithMany()
                        .HasForeignKey("MesaId");

                    b.HasOne("POSPedidoYFacturacion.Models.Sector", "Sector")
                        .WithMany()
                        .HasForeignKey("SectorId");

                    b.HasOne("POSPedidoYFacturacion.Models.TipoOrden", "TipoOrden")
                        .WithMany()
                        .HasForeignKey("TipoOrdenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POSPedidoYFacturacion.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Mesa");

                    b.Navigation("Sector");

                    b.Navigation("TipoOrden");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.OrdenDetalle", b =>
                {
                    b.HasOne("POSPedidoYFacturacion.Models.Orden", "Orden")
                        .WithMany("OrdenDetalles")
                        .HasForeignKey("OrdenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POSPedidoYFacturacion.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orden");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.OrdenVenta", b =>
                {
                    b.HasOne("POSPedidoYFacturacion.Models.Orden", "Orden")
                        .WithMany()
                        .HasForeignKey("OrdenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POSPedidoYFacturacion.Models.Venta", "Venta")
                        .WithMany("OrdenVentas")
                        .HasForeignKey("VentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orden");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.Producto", b =>
                {
                    b.HasOne("POSPedidoYFacturacion.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POSPedidoYFacturacion.Models.SubCategoria", "SubCategoria")
                        .WithMany()
                        .HasForeignKey("SubCategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("SubCategoria");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.SubCategoria", b =>
                {
                    b.HasOne("POSPedidoYFacturacion.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.Venta", b =>
                {
                    b.HasOne("POSPedidoYFacturacion.Models.Cuadre", "Cuadre")
                        .WithMany("Ventas")
                        .HasForeignKey("CuadreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POSPedidoYFacturacion.Models.Sector", "Sector")
                        .WithMany()
                        .HasForeignKey("SectorId");

                    b.HasOne("POSPedidoYFacturacion.Models.TipoOrden", "TipoOrden")
                        .WithMany("Ventas")
                        .HasForeignKey("TipoOrdenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POSPedidoYFacturacion.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Cuadre");

                    b.Navigation("Sector");

                    b.Navigation("TipoOrden");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.VentaDetalle", b =>
                {
                    b.HasOne("POSPedidoYFacturacion.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POSPedidoYFacturacion.Models.Venta", "Venta")
                        .WithMany("VentaDetalles")
                        .HasForeignKey("VentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.Area", b =>
                {
                    b.Navigation("Mesas");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.Cuadre", b =>
                {
                    b.Navigation("Desgloses");

                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.Orden", b =>
                {
                    b.Navigation("OrdenDetalles");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.TipoOrden", b =>
                {
                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("POSPedidoYFacturacion.Models.Venta", b =>
                {
                    b.Navigation("OrdenVentas");

                    b.Navigation("VentaDetalles");
                });
#pragma warning restore 612, 618
        }
    }
}
