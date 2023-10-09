using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using API.Controllers;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic.CompilerServices;
using Persistence.Data;

namespace API.Startup
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetEntryAssembly());
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddDbContext<PassaportAuthContext>(options=>{
                string connectionString = Configuration.GetConnectionString("ConexMysql");
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/google-login";
                    options.ExpireTimeSpan = TimeSpan.FromSeconds(30);
                    options.LogoutPath = "/Account/google-logout";

                })
                .AddGoogle(options =>
                {
                    options.ClientId = "682739648072-ssra7k6sd3s6oohavsju06add7mkrh3g.apps.googleusercontent.com";
                    options.ClientSecret = "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";
                });

            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
