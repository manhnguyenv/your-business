using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace YourBusiness.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    name: "v1",
                    info: new Swashbuckle.AspNetCore.Swagger.Info
                    {
                        Title = "your-business",
                        Version = "v1",
                        Description = "Web API for the your-business application",
                        Contact = new Swashbuckle.AspNetCore.Swagger.Contact
                        {
                            Name = "Schlee, Kevin",
                            Email = "schlee.kevin@xxx.com"
                        },
                        License = new Swashbuckle.AspNetCore.Swagger.License
                        {
                            Name = "Licensed under the MIT open source license",
                            Url = "/license.html"
                        }
                    }
                );

                var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseMvc(options =>
            {
                options.MapRoute("default", "your-business/{controller}/{action}/{id?}");
            });
            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Swagger
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "your-business Web API v1");
                options.InjectStylesheet("/swagger/ui/custom.css");
            });
        }
    }
}