using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using POSPedidoYFacturacion.Data;
using POSPedidoYFacturacion.Models;
using Shared;
using Shared.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace POSPedidoYFacturacion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Camarero/a")]
    public class AuthController : Controller
    {
        public IConfiguration Configuration { get; private set; }
        public UserManager<Usuario> UserManager { get; private set; }
        public SignInManager<Usuario> SignInManager { get; private set; }
        private readonly IDbContextFactory<ApplicationDbContext> DbContextFactory;
        private readonly IMapper Mapper;

        public AuthController(IConfiguration configuration, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, IDbContextFactory<ApplicationDbContext> dbContextFactory, IMapper mapper)
        {
            Configuration = configuration;
            UserManager = userManager;
            SignInManager = signInManager;
            DbContextFactory = dbContextFactory;
            Mapper = mapper;
        }

        // POST: api/Usuarios/Login
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UsuarioDTO Usuario)
        {

            var User = await UserManager.Users
                .Include(u => u.Empresa)
                .SingleOrDefaultAsync(u => u.UserName == Usuario.Username);

            if (User != null)
            {
                if (!(await UserManager.GetRolesAsync(User)).Contains("Camarero/a"))
                {
                    return BadRequest("El usuario no es un camarero, este login solo es reservado para camareros");
                }
                    var result = await SignInManager.PasswordSignInAsync(User.UserName, Usuario.Password, false, false);

                    if (result.Succeeded)
                    {

                        var token = await GenerateJwtToken(User.UserName, User);

                    //var roles = await UserManager.GetRolesAsync(User);

                    //List<Rol> Roles = new List<Rol>();


                    //foreach (var item in roles)
                    //{
                    //    Rol rol = new()
                    //    {
                    //        Name = item
                    //    };

                    //    Roles.Add(rol);
                    //}
                    using var DbContext = DbContextFactory.CreateDbContext();
                    var Empresas = await DbContext.UsuarioEmpresas.Where(ue => ue.UsuarioId == User.Id).Select(ue=>ue.Empresa).ToListAsync();
                    var Sucursales = await DbContext.UsuarioSucursales.Include(ue=>ue.Sucursal).Where(ue => ue.UsuarioId == User.Id && Empresas.SingleOrDefault().Id == ue.Sucursal.EmpresaId).Select(ue=>ue.Sucursal).ToListAsync();


                    var DTO = new UsuarioDTO
                    {
                        Id = User.Id,
                        Username = User.UserName,
                        AccessToken = token.AccessToken,
                        Issuer = token.Issuer,
                        Audience = token.Audience,
                        Expires = token.Expires,
                        Empresas = Mapper.Map<List<EmpresaDTO>>(Empresas),
                        Sucursales = Mapper.Map<List<SucursalDTO>>(Sucursales)
                    };


                    return Ok(DTO);

                    }

                    return BadRequest("Error al iniciar la sesion del usuario " + User.UserName + " !");
            }

            return NotFound("El usuario " + Usuario.Username + " no existe!");
        }



        public async Task<Token> GenerateJwtToken(string email, Usuario user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim("Empresa", user.EmpresaId.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(Configuration["JwtExpireDays"]));

            var roles = await UserManager.GetRolesAsync(user);

            claims.AddRange(roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));

            var token = new JwtSecurityToken(
                Configuration["JwtIssuer"],
                Configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            var accesstoken = new JwtSecurityTokenHandler().WriteToken(token);

            var tokenObj = new Token()
            {
                AccessToken = accesstoken,
                Issuer = Configuration["JwtIssuer"],
                Audience = Configuration["JwtIssuer"],
                Claims = claims,
                Expires = expires,
                SigningCredentials = creds
            };

            return tokenObj;

        }
    }
}
