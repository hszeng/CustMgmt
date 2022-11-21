using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustMgmt.Filters;
using CustMgmt.Entities;
using Microsoft.EntityFrameworkCore;
using CustMgmt.Services;
using System.Reflection;
using AutoMapper;
using CustMgmt.Models;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace CustMgmt
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
            services.AddControllers(config => { 
                config.Filters.Add<JsonExceptionFilter>();
            }).AddNewtonsoftJson(options =>
            {
                //Set datetime format
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            });
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();
          
            //Dynamic inject service types
            var types = Assembly.GetEntryAssembly().DefinedTypes.Where(a => typeof(IService).IsAssignableFrom(a) && a.FullName != "CustMgmt.Services.IService");
            foreach (var type in types)
            {
                services.AddTransient(type);
            }
            services.AddAutoMapper(typeof(CustMgmtMappingProfile));
            services.AddDbContext<CustMgmtDbContext>(config => {
                config.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            #if DEBUG
                config.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            #endif
            }
            );
            //services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<CheckCustomerExistFilterAttribute>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.)
            app.UseSwaggerUI();

            app.UseRouting();

            //app.UseCustomerization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
