using Deeplink.Api.Configuration;
using Deeplink.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Deeplink.Api
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
            services.AddControllers();

            services.AddSwaggerGen(c =>
               {
                   c.SwaggerDoc("v1", new OpenApiInfo
                   {
                       Version = "v1",
                       Title = "Trendyol Deeplink API"
                   });
                   
                   var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                   var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                   c.IncludeXmlComments(xmlPath);
               });

            services.AddScoped<IDeeplinkFlow, DeeplinkFlow>();
            services.AddScoped<IDeeplinkBuilder, DeeplinkBuilder>();
            services.AddScoped<IDeeplinkServiceFinder, DeeplinkServiceFinder>();
            services.AddScoped<IDeeplinkValidatior, DeeplinkValidator>();
            services.AddScoped<IDeeplinkConfiguration, DeeplinkConfiguraiton>();
            services.AddScoped<IDeeplinkRepository, DeeplinkRepository>();
            services.AddScoped<IRepositoryConfiguration, RedisRepositoryConfiguration>();
            services.AddScoped<IWebUrlConfiguration, WebUrlConfiguration>();
            services.AddScoped<IWebUrlFlow, WebUrlFlow>();
            services.AddScoped<IWebUrlValidator, WebUrlValidator>();
            services.AddScoped<IWebUrlRepository, WebUrlRepository>();

            
            services.AddTransient<IRepository, RedisRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureExceptionHandler();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Trendyol Deeplink Api V1.0");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
