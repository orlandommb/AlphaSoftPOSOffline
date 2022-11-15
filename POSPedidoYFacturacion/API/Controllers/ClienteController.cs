using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POSPedidoYFacturacion.Data;
using AutoMapper;
using POSPedidoYFacturacion.Models;
using Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace POSPedidoYFacturacion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Camarero/a")]
    public class ClienteController : Controller
    {

        private readonly IDbContextFactory<ApplicationDbContext> DbContextFactory;
        private readonly IMapper Mapper;

        public ClienteController(IDbContextFactory<ApplicationDbContext> dbContextFactory, IMapper mapper)
        {
            DbContextFactory = dbContextFactory;
            Mapper = mapper;
        }

        // GET: api/values
        [HttpGet]
        [Route("GetAll/{EmpresaId}")]
        public async Task<IActionResult> GetAll(int EmpresaId, int? SucursalId)
        {
            if (EmpresaId != 0)
            {
                using var DbContext = DbContextFactory.CreateDbContext();
                var Clientes = await DbContext.Clientes
                                    .Include(o => o.Empresa)
                                    .Include(o => o.Sucursal)
                                    .Where(m => m.EmpresaId == EmpresaId && (SucursalId == null || m.SucursalId == SucursalId)).ToListAsync();

                return Ok(Mapper.Map<List<ClienteDTO>>(Clientes));
            }
            return BadRequest("No se puede consultar los clientes con EmpresaId = 0!");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            if (Id != 0)
            {
                using var DbContext = DbContextFactory.CreateDbContext();
                var Cliente = await DbContext.Clientes
                                .Include(o => o.Empresa)
                                .Include(o => o.Sucursal)
                                .SingleOrDefaultAsync(m => m.Id == Id);

                return Cliente == null ? NotFound($"No existe un producto con este ID {Id}!") : Ok(Mapper.Map<ClienteDTO>(Cliente));
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
