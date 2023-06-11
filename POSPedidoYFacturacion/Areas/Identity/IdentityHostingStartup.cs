using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AlphaSoftPOSOffline.Data;
using AlphaSoftPOSOffline.Models;

[assembly: HostingStartup(typeof(AlphaSoftPOSOffline.Areas.Identity.IdentityHostingStartup))]
namespace AlphaSoftPOSOffline.Areas.Identity
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