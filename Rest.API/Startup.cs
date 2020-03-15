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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Versioning;
using Rest.API.Services;
using Rest.API.Filters;
using Rest.API.Models;
using NSwag.AspNetCore;

namespace Rest.API
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
            services.AddRouting(options => options.LowercaseUrls = true);
            services
                .AddMvc(options =>
                {
                    options.CacheProfiles.Add("Static", new CacheProfile { Duration = 86400 });
                    options.CacheProfiles.Add("Collection", new CacheProfile { Duration = 60 });
                    options.CacheProfiles.Add("Resource", new CacheProfile { Duration = 180 });

                    options.Filters.Add<JsonExceptionFilter>();
                });
            //settings.GeneratorSettings.AllowNullableBodyParameters = false;
            services.AddControllers();
            services.AddScoped<IFibonacciService, DefaultFibonacciService>();
            services.AddScoped<IReverseWordsService, DefaultReverseWordsService>();
            services.AddScoped<ITriangleTypeService, DefaultTriangleTypeService>();
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Rest API";
                    document.Info.Description = "A simple REST API with ASP.NET Core web API";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Diego Torres",
                        Email = "ing.diego.torres95@gmail.com",
                        Url = "https://www.linkedin.com/in/diego-torres-7b353822/"
                    };
                    document.Info.License = new NSwag.OpenApiLicense
                    {
                        Name = "Use under MIT",
                        Url = "https://github.com/SPLAYER-HD"
                    };
                };
            });
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ApiVersionReader
                    = new MediaTypeApiVersionReader();
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionSelector
                     = new CurrentImplementationApiVersionSelector(options);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseOpenApi();
                app.UseSwaggerUi3();
            }

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
