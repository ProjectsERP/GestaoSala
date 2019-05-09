using api.adm.gestaosala.core.manager.usuario;
using api.adm.gestaosala.core.providers;
using api.adm.gestaosala.provider;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using AutoMapper;
using api.adm.gestaosala.Swagger;
using Swashbuckle.AspNetCore.Swagger;

namespace api.adm.gestaosala
{
    /// <summary>
    ///     
    /// </summary>
    public class Startup
    {

        /// <summary>
        ///     
        /// </summary>
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            var builder = new ConfigurationBuilder()
              .SetBasePath(env.ContentRootPath)
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
              .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
              .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper();

            #region Manager
            services.AddTransient<IUsuarioManager, UsuarioManager>();

            #endregion

            #region Providers
            services.AddTransient<IUsuarioProvider, UsuarioProvider>();

            #endregion

            #region swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "API de usuario",
                    Description = "API de cadastro de usuario",
                    TermsOfService = "None"
                });

                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "api.adm.gestaosala.xml");
                c.IncludeXmlComments(filePath);
                c.DescribeAllEnumsAsStrings();
            });


            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Info { Title = "Usuario Api", Version = "v1" });
            //    var applicationBasePath = PlatformServices.Default.Application.ApplicationBasePath;
            //    var applicationName = PlatformServices.Default.Application.ApplicationName;
            //    var xmlDocumentPath = Path.Combine(applicationBasePath, $"{applicationName}.xml");


            //    if (File.Exists(xmlDocumentPath))
            //    {
            //        c.IncludeXmlComments(xmlDocumentPath);
            //    }

            //});

            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
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
            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1 docs");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Usuario}/{action=Get}/{id?}");
            });
        }
    }
}
