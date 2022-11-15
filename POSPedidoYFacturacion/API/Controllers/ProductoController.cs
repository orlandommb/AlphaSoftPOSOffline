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
using Shared.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace POSPedidoYFacturacion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Camarero/a")]
    public class ProductoController : Controller
    {

        private readonly IDbContextFactory<ApplicationDbContext> DbContextFactory;
        private readonly IMapper Mapper;

        public ProductoController(IDbContextFactory<ApplicationDbContext> dbContextFactory, IMapper mapper)
        {
            DbContextFactory = dbContextFactory;
            Mapper = mapper;
        }

        // GET: api/values
        [HttpGet]
        [Route("GetAll/{EmpresaId}")]
        public async Task<IActionResult> GetAll(int EmpresaId, int? SucursalId, int? CategoriaId)
        {
            if (EmpresaId != 0)
            {
                using var DbContext = DbContextFactory.CreateDbContext();
                var Productos = await DbContext.Productos
                                    .Include(o => o.Categoria)
                                    .Include(o => o.SubCategoria)
                                    .Include(o => o.Empresa)
                                    .Include(o => o.Sucursal)
                                    .Where(m => m.EmpresaId == EmpresaId && (SucursalId == null || m.SucursalId == SucursalId) && (CategoriaId == null || m.CategoriaId == CategoriaId)).ToListAsync();

                return Ok(Mapper.Map<List<ProductoDTO>>(Productos));

            }

            return BadRequest("El parametro empresa Id es obligatorio y no puede ser 0!");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            if (Id != 0)
            {
                using var DbContext = DbContextFactory.CreateDbContext();
                var Producto = await DbContext.Productos
                                .Include(o => o.Categoria)
                                .Include(o => o.SubCategoria)
                                .Include(o => o.Empresa)
                                .Include(o => o.Sucursal)
                                .SingleOrDefaultAsync(m => m.Id == Id);

                return Producto == null ? NotFound($"No existe un producto con este ID {Id}!") : Ok(Mapper.Map<ProductoDTO>(Producto));
            }

            return BadRequest("No se puede buscar un producto con un Id = 0!");
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
