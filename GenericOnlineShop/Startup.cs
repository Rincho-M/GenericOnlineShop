using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GenericOnlineShop.Db;
using GenericOnlineShop.Services;
using Microsoft.AspNetCore.Identity;

namespace GenericOnlineShop
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<AppDbContext>(options =>
            {
                string connectionString = _configuration.GetConnectionString("Dev");
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(30);
                options.Cookie.Name = "GenericOnlineShop.Session";
                options.Cookie.HttpOnly = true;
            });

            services.AddAuthentication("CookieAuthN")
                .AddCookie("CookieAuthN", options =>
                {
                    options.Cookie.Name = "GenericOnlineShop.AuthN";
                    options.LoginPath = "/Home";
                });

            services.AddScoped<IReadWriteDbService, ReadWriteDbService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                //app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "cart",
                    pattern: "cart",
                    defaults: new { controller = "Cart", action = "Cart" });
                endpoints.MapControllerRoute(
                    name: "account",
                    pattern: "account",
                    defaults: new { controller = "Account", action = "Index" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{productTypeName?}");
            });
        }
    }
}
