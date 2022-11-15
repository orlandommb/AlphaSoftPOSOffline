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
    [Produces("application/json")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Camarero/a")]
    public class AreaController : Controller
    {


        private readonly IDbContextFactory<ApplicationDbContext> DbContextFactory;
        private readonly IMapper Mapper;

        public AreaController(IDbContextFactory<ApplicationDbContext> dbContextFactory, IMapper mapper)
        {
            DbContextFactory = dbContextFactory;
            Mapper = mapper;
        }


        // GET: api/values
        [HttpGet]
        [Route("GetAll/{EmpresaId}/{SucursalId}")]
        public async Task<List<AreaDTO>> GetAll(int EmpresaId, int SucursalId)
        {

            using var DbContext = DbContextFactory.CreateDbContext();
            var Areas = await DbContext.Areas.Include(m => m.Mesas).ThenInclude(m=>m.Ordenes.Where(o=>o.Facturado == false && o.Nulo == false)).Where(m => m.EmpresaId == EmpresaId && m.SucursalId == SucursalId ).ToListAsync();

            return Mapper.Map<List<AreaDTO>>(Areas);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            if (Id != 0)
            {
                using var DbContext = DbContextFactory.CreateDbContext();
                var Area = await DbContext.Areas.Include(m => m.Mesas).SingleOrDefaultAsync(m => m.Id == Id);

                return Ok(Mapper.Map<AreaDTO>(Area));
            }
            return NotFound();
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
