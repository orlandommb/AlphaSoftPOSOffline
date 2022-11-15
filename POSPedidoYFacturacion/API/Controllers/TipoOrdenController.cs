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
    public class TipoOrdenController : Controller
    {

        private readonly IDbContextFactory<ApplicationDbContext> DbContextFactory;
        private readonly IMapper Mapper;

        public TipoOrdenController(IDbContextFactory<ApplicationDbContext> dbContextFactory, IMapper mapper)
        {
            DbContextFactory = dbContextFactory;
            Mapper = mapper;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            using var DbContext = DbContextFactory.CreateDbContext();
            var TipoOrdenes = await DbContext.TipoOrdenes.ToListAsync();

            return Ok(Mapper.Map<List<TipoOrdenDTO>>(TipoOrdenes));
        

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            if (Id != 0)
            {
                using var DbContext = DbContextFactory.CreateDbContext();
                var TipoOrden = await DbContext.TipoOrdenes.SingleOrDefaultAsync(tp=>tp.Id == Id);

                return TipoOrden == null ? NotFound($"No existe un tipo de orden con este ID {Id}!") : Ok(Mapper.Map<TipoOrdenDTO>(TipoOrden));
            }

            return BadRequest("No se puede buscar un tipo de orden con un Id = 0!");
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
