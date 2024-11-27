using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NexusForever.Shared.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusForever.WorldServer.Api
{
    public class WorldServerApiStartup
    {
        public IConfiguration Configuration { get; }

        public WorldServerApiStartup(IConfiguration configuration)
        {
            Configuration = configuration;
            var api = configuration.GetSection("Api").Get<ApiConfig>();
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
            // app.Urls.Add($"http://{api.Host}:{api.Port}");
            app.MapControllers();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            app.UseCors();
            //app.Urls.Add($"http://{host}:{port}");
        }
    }
}
