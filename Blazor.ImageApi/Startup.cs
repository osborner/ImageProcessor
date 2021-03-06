using Blazor.ImageApi.Service;
using Blazor.ImageSharedLibrary.Class;
using Blazor.ImageSharedLibrary.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.ImageApi
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
            services.AddTransient<IImageProcessor, ImageProcessor>();
            services.AddTransient<IImageAnalyser, ImageAnalyser>();
            services.AddTransient<IImageRetriever, WebImageRetriever>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "sample-data")),
                    RequestPath = "/sample-data"
                });
                app.UseDirectoryBrowser(new DirectoryBrowserOptions
                {
                    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "sample-data")),
                    RequestPath = "/sample-data"
                });

                // Allow cross-origin resource sharing with Blazor.ImageClient
                app.UseCors(policy =>
                        policy.WithOrigins("http://localhost:47316", "https://localhost:44371")
                        .AllowAnyMethod()
                        .WithHeaders(HeaderNames.ContentType, HeaderNames.Authorization, "x-custom-header")
                        .AllowCredentials());
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
