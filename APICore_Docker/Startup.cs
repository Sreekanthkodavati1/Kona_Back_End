﻿using Core_APIService.Helpers;
using Core_BAL;
using Core_BALInterfaceCore;
using Core_DomainModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Core_DAL;
using Core_DALInterface;
namespace Core_APIService
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


            services.AddMvc(config =>
            {
                config.Filters.Add(typeof(ExceptionHandler));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            #region Swagger Generation
            services.AddSwaggerGen(s => { s.SwaggerDoc("v1", new Info { Title = "Core API", Description = "Core API Swagger Integration" }); });
            #endregion

            #region DB Connection String
            services.Configure<AppSettingsModel>(Configuration.GetSection("ConnectionStrings"));
            #endregion

            #region DAL and BAL Dependncy Injection
            DALDependnecies.RegisterDALDependnecies(services);
            BALDependnecies.RegisterBALDependnecies(services);
            #endregion

            //services.AddScoped<IEntityBAL<User>, UserBAL>();
            
            //services.AddScoped<IRepository<User>, PostgresSqlRepository<User>>();
            //services.AddAuthentication("BasicAuthentication")
            //.AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new Info { Title = "My Demo API", Version = "1.0" });
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();

            #region Swagger UI Integration          

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "My Demo API (V 1.0)");
            });
            #endregion
        }
    }
}
