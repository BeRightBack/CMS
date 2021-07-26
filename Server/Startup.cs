using Localization.SqlLocalizer.DbStringLocalizer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Resources;
using Server.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Server.Shared;
using HttpContextAccessor = Server.Shared.HttpContextAccessor;

namespace Server
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
            services.AddHttpContextAccessor();
            services.AddScoped<HttpContextAccessor>();

            var sqlConnectionString = Configuration["DbStringLocalizer:ConnectionString"];

            services.AddDbContext<LocalizationModelContext>(options =>
                options.UseSqlServer(
                    sqlConnectionString,
                    b => b.MigrationsAssembly("Mvc")
                ),
                ServiceLifetime.Singleton,
                ServiceLifetime.Singleton
            );

            services.AddSingleton<LocService>();

            var useTypeFullNames = false;
            var useOnlyPropertyNames = true;
            var returnOnlyKeyIfNotFound = true;

            services.AddSqlLocalization(options => options.UseSettings(
              useTypeFullNames,
              useOnlyPropertyNames,
              returnOnlyKeyIfNotFound,
              true
            ));

            services.Configure<RequestLocalizationOptions>(
                options =>
                {
                    var supportedCultures = new List<CultureInfo>
                        {
                            new CultureInfo("en-CA"),
                            new CultureInfo("fr-CA"),
                            new CultureInfo("en-US"),
                            new CultureInfo("fr-FR")
                        };

                    options.DefaultRequestCulture = new RequestCulture(culture: "fr-CA", uiCulture: "fr-CA");
                    options.SupportedCultures = supportedCultures;
                    options.SupportedUICultures = supportedCultures;

                    options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
                });



            services.AddControllersWithViews()
                .AddNewtonsoftJson()
                .AddViewLocalization()
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                    {
                        var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName);
                        return factory.Create("SharedResource", assemblyName.Name);
                    };
                });

            

            services.AddRazorPages().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
