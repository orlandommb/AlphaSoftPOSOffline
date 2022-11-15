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
    public class CategoriaController : Controller
    {

        private readonly IDbContextFactory<ApplicationDbContext> DbContextFactory;
        private readonly IMapper Mapper;

        public CategoriaController(IDbContextFactory<ApplicationDbContext> dbContextFactory, IMapper mapper)
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
                var Categorias = await DbContext.Categorias.Where(m => m.EmpresaId == EmpresaId && (SucursalId == null || m.SucursalId == SucursalId)).ToListAsync();

                return Ok(Mapper.Map<List<CategoriaDTO>>(Categorias));
            }

            return BadRequest("No se puede consultar las mesas con el EmpresaId = 0!");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
