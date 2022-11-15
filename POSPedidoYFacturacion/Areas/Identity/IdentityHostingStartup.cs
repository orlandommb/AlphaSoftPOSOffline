using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POSPedidoYFacturacion.Data;
using POSPedidoYFacturacion.Models;

[assembly: HostingStartup(typeof(POSPedidoYFacturacion.Areas.Identity.IdentityHostingStartup))]
namespace POSPedidoYFacturacion.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}