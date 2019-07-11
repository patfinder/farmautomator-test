using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using FarmAutomatorServer.Repository;

namespace FarmAutomatorServer
{
    public class Startup
    {
        public const string CookieScheme = "Cookies";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<OracleDbContext>(options =>
            //options.UseSqlite(
            //    Configuration.GetConnectionString("DefaultConnection")));
                options.UseOracle(
                    //Configuration.GetConnectionString(@"User Id=blog;Password=<password>;Data Source=pdborcl;")));
                    Configuration.GetConnectionString(@"User Id=farmdb;Password=123456;Data Source=localhost:1521/xe;")));

            services.AddCors();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAuthentication(CookieScheme) // Sets the default scheme to cookies
                .AddCookie(CookieScheme, options =>
                {
                    //options.AccessDeniedPath = "/account/denied";
                    //options.LoginPath = "/account/login";

                    options.Cookie.Name = "auth_cookie";
                    options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None;
                    options.Events = new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents
                    {
                        OnRedirectToLogin = redirectContext =>
                        {
                            redirectContext.HttpContext.Response.StatusCode = 401;
                            return Task.CompletedTask;
                        }
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseCors(configurePolicy => {
                configurePolicy.AllowAnyHeader();
                configurePolicy.AllowAnyMethod();
                configurePolicy.AllowAnyOrigin();
                configurePolicy.AllowCredentials();
            });

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
