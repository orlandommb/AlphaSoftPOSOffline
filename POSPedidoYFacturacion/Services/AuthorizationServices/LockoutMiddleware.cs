using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using POSPedidoYFacturacion.Data;
using POSPedidoYFacturacion.Models;

namespace POSPedidoYFacturacion.Services.AuthorizationServices
{
    public class LockoutMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDbContextFactory<ApplicationDbContext> dbFactory;

        public LockoutMiddleware(RequestDelegate next, IDbContextFactory<ApplicationDbContext> DbFactory)
        {
            _next = next;
            dbFactory = DbFactory;
        }

        public async Task Invoke(HttpContext httpContext,
            UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager)
        {
            //var user1 = await userManager.GetUserAsync(httpContext.User);

            using var DbContext = dbFactory.CreateDbContext();
            var Empresa = await DbContext.Empresa.FirstOrDefaultAsync();
            if(Empresa != null)
            {
                if ( DateTime.Now >= Empresa.FechaVencimientoServicio)
                {
                    var Usuarios = await userManager.Users.Where(u => u.UserName != "AlphaSoft").ToListAsync();
                    foreach (var item in Usuarios)
                    {
                        await userManager.SetLockoutEnabledAsync(item, true);
                        var FechaBloqueo = new DateTime(9999, 01, 01, 1, 1, 1, 1);
                        await userManager.SetLockoutEndDateAsync(item, FechaBloqueo);
                        await userManager.UpdateAsync(item);
                    }
                }
                else
                {
                    var Usuarios = await userManager.Users.Where(u => u.UserName != "AlphaSoft").ToListAsync();
                    foreach (var item in Usuarios)
                    {
                        if (await userManager.IsLockedOutAsync(item))
                        {
                            var FechaBloqueo = new DateTime(1900,01,01,1,1,1,1);
                            await userManager.SetLockoutEndDateAsync(item, FechaBloqueo);
                            await userManager.UpdateAsync(item);
                        }
                        
                    }
                }

                if (!string.IsNullOrEmpty(httpContext.User.Identity.Name))
                {
                    var user = await userManager.FindByNameAsync(httpContext.User.Identity.Name);

                    if (await userManager.IsLockedOutAsync(user))
                    {
                        //Log the user out and redirect back to homepage
                        await signInManager.SignOutAsync();
                    }

                }
            }
            

            await _next(httpContext);
        }
    }

    public static class LockoutMiddlewareExtensions
    {
        public static IApplicationBuilder UseUserDestroyer(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LockoutMiddleware>();
        }
    }


}

