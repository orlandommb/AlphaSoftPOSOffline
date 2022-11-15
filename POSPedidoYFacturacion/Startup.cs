using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using POSPedidoYFacturacion.Areas.Identity;
using POSPedidoYFacturacion.Data;
using POSPedidoYFacturacion.Models;
using POSPedidoYFacturacion.Utilidades;
using Radzen;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using POSPedidoYFacturacion.Services.AuthorizationServices;
using MudBlazor.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Blazor;

namespace POSPedidoYFacturacion
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContextFactory<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("SQLServerConnection"), opt => opt.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

            services.AddScoped(p => p.GetRequiredService<IDbContextFactory<ApplicationDbContext>>().CreateDbContext());

            services.AddDefaultIdentity<Usuario>(options => {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
                options.Lockout.AllowedForNewUsers = true;
            })
                .AddRoles<Rol>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();
            services.AddServerSideBlazor().AddHubOptions(o =>
            {
                o.MaximumReceiveMessageSize = 10 * 1024 * 1024;
            });
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<Usuario>>();

            services.AddAuthentication()
                    .AddCookie(cfg => cfg.SlidingExpiration = true)
                     .AddJwtBearer(x =>
                     {
                         // options
                         x.TokenValidationParameters = new TokenValidationParameters()
                         {
                             ValidIssuer = Configuration["JwtIssuer"],
                             ValidAudience = Configuration["JwtIssuer"],
                             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"])),
                             ClockSkew = TimeSpan.Zero
                         };
                     });

            services.AddAutoMapper(typeof(Startup));


            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddScoped<IMessage, Message>();
            services.AddScoped<DialogService>();
            services.AddScoped<EstadoOrden>();
            services.AddMudServices();
            services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });

            services.AddControllers()
                .AddNewtonsoftJson(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTE5ODE4QDMxMzkyZTMzMmUzMFI3bUpaMStiQkxSOXdFN0x3bUxnOTZZRDhMSFpzeEVNL3ZYbzdORUplejA9;NTE5ODE5QDMxMzkyZTMzMmUzMENuNmZTSGRId1dkNmhzOG9ubnhtdE84VHVMcUlNUFZ0NDBneWY2WDBnS289;NTE5ODIwQDMxMzkyZTMzMmUzMExDYWlzNVJmbnRhbHVYd0ZSd3ZhVm9GTkFIQ1hWVHZqa0I3em9aa1FNREU9;NTE5ODIxQDMxMzkyZTMzMmUzMGUwdmpSenZpYm1XRjVBSDF5YWV2Q3Bia1NVRHpqZGUyeUpHb3pJZjF1VDQ9;NTE5ODIyQDMxMzkyZTMzMmUzMGNiYy9GMjdKRUFNZDVlK1dUeXlEbUxGUDk3NkcvaDluekRKbE5CaHQ5RjA9;NTE5ODIzQDMxMzkyZTMzMmUzMFlPTkc4MmhmMjJ6ZFBpRVdGMHUweW9RTVVwbko3bFpkb3kzQ2I1TDE4dzQ9;NTE5ODI0QDMxMzkyZTMzMmUzMFk3RWRpYnlIbmdQdGIxNVZMOU5MRUx0QU9aUysyOGl3UFVLK0JaN0dtWkk9");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            var defaultDateCulture = "es-DO";
            var ci = new CultureInfo(defaultDateCulture);
            ci.NumberFormat.NumberDecimalSeparator = ".";
            ci.NumberFormat.CurrencyDecimalSeparator = ".";

            // Configure the Localization middleware
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(ci),
                SupportedCultures = new List<CultureInfo> { ci, },
                SupportedUICultures = new List<CultureInfo> { ci, }
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseUserDestroyer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
