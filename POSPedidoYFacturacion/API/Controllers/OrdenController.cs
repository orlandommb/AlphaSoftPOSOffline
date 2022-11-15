using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POSPedidoYFacturacion.Data;
using POSPedidoYFacturacion.Models;
using Shared.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace POSPedidoYFacturacion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Camarero/a")]
    public class OrdenController : Controller
    {

        private readonly IDbContextFactory<ApplicationDbContext> DbContextFactory;
        private readonly IMapper Mapper;

        public OrdenController(IDbContextFactory<ApplicationDbContext> dbContextFactory, IMapper mapper)
        {
            DbContextFactory = dbContextFactory;
            Mapper = mapper;
        }

        // GET: api/values
        [HttpGet]
        [Route("GetAll/{EmpresaId}")]
        public async Task<IActionResult> GetAll(int EmpresaId, int? SucursalId, int? TipoOrdenId, int? MesaId, string UsuarioId, int? ClienteId)
        {
            if (EmpresaId != 0)
            {
                using var DbContext = DbContextFactory.CreateDbContext();
                var Ordenes = await DbContext.Ordenes
                                    .Include(o => o.TipoOrden)
                                    .Include(o => o.Empresa)
                                    .Include(o => o.Sucursal)
                                    .Include(o => o.Cliente)
                                    .Include(o => o.Usuario)
                                    .Include(m => m.Mesa)
                                    .Include(m => m.OrdenDetalles)
                                    .ThenInclude(m => m.Producto)
                                    .Where(m => m.EmpresaId == EmpresaId &&
                                    (SucursalId == null || m.SucursalId == SucursalId) &&
                                    (TipoOrdenId == null || m.TipoOrdenId == TipoOrdenId) &&
                                    (MesaId == 0 || m.MesaId == MesaId) &&
                                    (string.IsNullOrWhiteSpace(UsuarioId) || m.UsuarioId == UsuarioId) &&
                                    (ClienteId == null || m.ClienteId == ClienteId) &&
                                    m.Facturado == false && m.Nulo == false
                                    ).ToListAsync();

                return Ok(Mapper.Map<List<OrdenDTO>>(Ordenes));

            }

            return BadRequest($"No se puede consultar ordenes con la EmpresaId = 0 !");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            if (Id != 0)
            {
                using var DbContext = DbContextFactory.CreateDbContext();
                var Orden = await DbContext.Ordenes
                    .Include(o=>o.TipoOrden)
                    .Include(o=>o.Empresa)
                    .Include(o=>o.Sucursal)
                    .Include(o=>o.Cliente)
                    .Include(o=>o.Usuario)
                    .Include(m => m.Mesa)
                    .Include(m => m.OrdenDetalles)
                    .ThenInclude(m => m.Producto)
                    .SingleOrDefaultAsync(m => m.Id == Id);

                return Ok(Mapper.Map<OrdenDTO>(Orden));
            }
            return NotFound();
        }

        // POST api/values
        [HttpPost]
        [Route("RegistrarOrden")]
        public async Task<IActionResult> RegistrarOrden([FromBody] OrdenDTO DTO)
        {
            if (ModelState.IsValid)
            {
                var Orden = new Orden();

                Orden = Mapper.Map<Orden>(DTO);

                if (Orden.TipoOrdenId == 0)
                {
                    return BadRequest("Debe seleccionar el tipo de orden!");
                    
                }

                if (Orden.OrdenDetalles.Count <= 0)
                {
                    return BadRequest("No se puede guardar una orden sin productos!");
                    
                }

                if (Orden.TipoOrdenId != 1)
                {
                    Orden.MontoDelivery = 0;
                }

                using var DbContext = DbContextFactory.CreateDbContext();

                if (Orden.Id == 0)
                {
                    var OrdenNueva = new Orden();
                    OrdenNueva = Orden;

                    OrdenNueva.Empresa = null;
                    OrdenNueva.Sucursal = null;
                    OrdenNueva.Usuario = null;
                    OrdenNueva.TipoOrden = null;
                    OrdenNueva.Sector = null;
                    OrdenNueva.Mesa = null;

                    foreach (var detalle in OrdenNueva.OrdenDetalles)
                    {
                        detalle.Producto = null;
                    }

                    await DbContext.AddAsync(OrdenNueva);
                    await DbContext.SaveChangesAsync();

                    return Ok("Registro Exitoso!");
                }
                else
                {
                    var OrdenFromDb = await DbContext.Ordenes
                    .Include(o => o.TipoOrden)
                    .Include(o => o.Sector)
                    .Include(o => o.OrdenDetalles)
                    .SingleOrDefaultAsync(o => o.Id == Orden.Id);

                    OrdenFromDb.TipoOrdenId = Orden.TipoOrdenId;
                    OrdenFromDb.NombreCliente = Orden.NombreCliente;
                    OrdenFromDb.DireccionCliente = Orden.DireccionCliente;
                    OrdenFromDb.MontoDelivery = Orden.MontoDelivery;
                    OrdenFromDb.SubTotal = Orden.OrdenDetalles.Sum(od => od.Precio * od.Cantidad);
                    OrdenFromDb.Descuento = Orden.OrdenDetalles.Sum(od => od.Descuento);
                    OrdenFromDb.Total = Orden.OrdenDetalles.Sum(od => od.Importe) + Orden.MontoDelivery;

                    DbContext.Update(OrdenFromDb);

                //
                //Procesos de Detalle de la Transaccion
                //


                //Creamos una lista de detalles removidos para agregar los detalles que se hayan removido.
                var DetallesRemovidos = new List<OrdenDetalle>();

                    //por cada detalle en la lista de detalles antiguos
                    foreach (var item in OrdenFromDb.OrdenDetalles)
                    {
                        //Consultamos en la lista de detalles nuevos donde el producto sea igual al producto del detalle antiguo.
                        var Exists = Orden.OrdenDetalles.Where(od => od.ProductoId == item.ProductoId && od.Id == item.Id).SingleOrDefault();

                        //Si no existe el detalle antiguo en el detalle de al compra nueva.
                        if (Exists == null)
                        {
                            //Agregamos el detalle antiguo a lista de DetalleRemovidos.
                            DetallesRemovidos.Add(item);
                        }
                    }

                    //Si hay mas de 0 objetos en la lista de detalles removidos.
                    if (DetallesRemovidos.Count > 0)
                    {

                        //Borramos todos los detalles removidos en la lista de detalles removidos de la Base de Datos.
                        DbContext.OrdenDetalles.RemoveRange(DetallesRemovidos);

                    }



                    //Por cada detalle en el detalle de la compra nueva.
                    foreach (var item in Orden.OrdenDetalles)
                    {
                        //Asignamos los nuevos datos al detalle para que entity framework no arroje excepciones.
                        item.OrdenId = OrdenFromDb.Id;
                        item.Orden = await DbContext.Ordenes.SingleOrDefaultAsync(o => o.Id == OrdenFromDb.Id);
                        item.Producto = await DbContext.Productos.SingleOrDefaultAsync(o => o.Id == item.ProductoId);

                        //Si el detalle nuevo no existe en la base de datos.
                        if (item.Id == 0)
                        {
                            //lo insertamos.
                            await DbContext.AddAsync(item);
                        }
                        else
                        {
                            //Consultamos el detalle de la lista de Detalles Antiguos, donde el producto y la compra sean igual al detalle de la compra enviada.
                            var detalle = OrdenFromDb.OrdenDetalles.Where(od => od.ProductoId == item.ProductoId && od.OrdenId == item.OrdenId).SingleOrDefault();

                            //Asignamos los datos a actualizar al detalle consultado
                            detalle.NombreProducto = item.NombreProducto;
                            detalle.Cantidad = item.Cantidad;
                            detalle.Descuento = item.Descuento;
                            detalle.Precio = item.Precio;
                            detalle.Importe = item.Importe;

                            //actualizamos los datos en la base de datos.
                            DbContext.Update(detalle);
                        }

                    }

                    await DbContext.SaveChangesAsync();
                    return Ok("Modificacion Exitosa!");
                }
            }
            return BadRequest(ModelState.Values.ToList().Select(v=>v.Children).ToString());
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
