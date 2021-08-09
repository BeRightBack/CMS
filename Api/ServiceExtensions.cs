using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System;
using System.Text;

namespace Api
{
    public static class ServiceExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<ApiUser>(q => { 
                
                // Password settings
                q.Password.RequireDigit = true;
                q.Password.RequiredLength = 8;
                q.Password.RequireNonAlphanumeric = true;
                q.Password.RequireUppercase = true;
                q.Password.RequireLowercase = true;
                q.Password.RequiredUniqueChars = 6;

                // Lockout settings
                q.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                q.Lockout.MaxFailedAccessAttempts = 10;
                q.Lockout.AllowedForNewUsers = true;

                // User settings
                q.User.RequireUniqueEmail = true;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
            builder.AddEntityFrameworkStores<CMSDbContext>().AddDefaultTokenProviders();
        }

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration Configuration)
        {
            var jwtSettings = Configuration.GetSection("Jwt");
            //var key = Environment.GetEnvironmentVariable("KEY");
            var key = jwtSettings.GetSection("Key").Value;

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.GetSection("Issuer").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                };
            });
        }

        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error => {
                error.Run(async context => {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        Log.Error($"Something Went Wrong in the {contextFeature.Error}");

                        await context.Response.WriteAsync(new Error
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error. Please Try Again Later."
                        }.ToString());
                    }
                });
            });
        }

        //public static void ConfigureVersioning(this IServiceCollection services)
        //{
        //    services.AddApiVersioning(opt =>
        //    {
        //        opt.ReportApiVersions = true;
        //        opt.AssumeDefaultVersionWhenUnspecified = true;
        //        opt.DefaultApiVersion = new ApiVersion(1, 0);
        //        opt.ApiVersionReader = new HeaderApiVersionReader("api-version");
        //    });
        //}

        //public static void ConfigureHttpCacheHeaders(this IServiceCollection services)
        //{
        //    services.AddResponseCaching();
        //    services.AddHttpCacheHeaders(
        //        (expirationOpt) =>
        //        {
        //            expirationOpt.MaxAge = 120;
        //            expirationOpt.CacheLocation = CacheLocation.Private;
        //        },
        //        (validationOpt) =>
        //        {
        //            validationOpt.MustRevalidate = true;
        //        }
        //    );
        //}

        //public static void ConfigureRateLimiting(this IServiceCollection services)
        //{
        //    var rateLimitRules = new List<RateLimitRule>
        //    {
        //        new RateLimitRule
        //        {
        //            Endpoint = "*",
        //            Limit= 1,
        //            Period = "5s"
        //        }
        //    };
        //    services.Configure<IpRateLimitOptions>(opt =>
        //    {
        //        opt.GeneralRules = rateLimitRules;
        //    });
        //    services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
        //    services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
        //    services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        //}
    }
}
