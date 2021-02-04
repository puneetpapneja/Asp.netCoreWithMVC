using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;
using BookStore.Models.Repository;

namespace BookStore
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection service)
        {
            service.AddDbContext<BookDBContext>(options => 
                 options.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=bookstore;integrated security=true"));            
            service.AddMvc();
#if DEBUG
            service.AddRazorPages().AddRazorRuntimeCompilation();
#endif
            service.AddScoped<BookRepo, BookRepo>();
            service.AddScoped<LanguageRepo, LanguageRepo>();
        }

        public void Configure(IApplicationBuilder app,IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
