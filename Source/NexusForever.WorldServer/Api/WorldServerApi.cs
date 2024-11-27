using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NexusForever.Network.Configuration.Model;
using NexusForever.Shared.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NexusForever.WorldServer.Api
{

    public class WorldServerApi
    {
        public static IServiceProvider Services { get; set; }

        public static WebApplication CreateApp(IServiceProvider otherServices)
        {
            //otherServices.GetRequiredService<object>();
            WorldServerApi.Services = otherServices;
            WebApplicationOptions options = new WebApplicationOptions();
            var networkOptions = otherServices.GetService<IOptions<NetworkConfig>>();
            var apiOptions = otherServices.GetService<IOptions<ApiConfig>>();
            var apiConfig = apiOptions.Value;
            if (String.IsNullOrEmpty(apiConfig.Host) || apiConfig.Port == 0)
            {
                return null;
            }

            // IOptions<NetworkConfig> networkOptions
            var builder = WebApplication.CreateBuilder(); // could pass options
            builder.Services.AddControllers();
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("*");
                    policy.WithMethods("*");
                    policy.WithHeaders("*");
                    policy.WithExposedHeaders("*");
                });
            });
            var app = builder.Build();
            app.UseCors();
            app.Urls.Add($"http://{apiConfig.Host}:{apiConfig.Port}");
            app.MapControllers();
            return app;
        }
        /*
        public static Task StartAsync(CancellationToken token)
        {
            var api = SharedConfiguration.Configuration.GetSection("Api").Get<ApiConfig>();
            if (string.IsNullOrEmpty(api.Host) || api.Port == 0)
            {
                return Task.CompletedTask;
            };

            var app = CreateApp();
            return app.RunAsync(token);
        }

        public static WebApplication CreateApp()
        {
            var api = SharedConfiguration.Configuration.GetSection("Api").Get<ApiConfig>();
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddControllers();
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("*");
                    policy.WithMethods("*");
                    policy.WithHeaders("*");
                    policy.WithExposedHeaders("*");
                });
            });
            var app = builder.Build();
            app.UseCors();
            app.Urls.Add($"http://{api.Host}:{api.Port}");
            app.MapControllers();
            return app;
        }
        */

        internal static IWebHostBuilder Build(IWebHostBuilder configure)
        {
            configure.UseUrls("http://localhost:5003");
            configure.ConfigureServices(services =>
            {
                services.AddControllers();
                services.AddCors(options =>
                {
                    options.AddDefaultPolicy(policy =>
                    {
                        policy.WithOrigins("*");
                        policy.WithMethods("*");
                        policy.WithHeaders("*");
                        policy.WithExposedHeaders("*");
                    });
                });
            });
            return configure;
        }
    }
}
