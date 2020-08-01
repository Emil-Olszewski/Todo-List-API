using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;

using System;
using System.IO;
using System.Reflection;
using Todo.Application;
using Todo.Application.Services;
using Todo.Infrastructure;
using Todo.Infrastructure.Persistence;
using Todo.WebAPI.Helpers;
using Todo.WebAPI.Helpers.Implementations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Todo.Domain;

namespace Todo.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public static readonly ILoggerFactory Logger = CreateLogger();

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IAppDbContext, AppDbContext>(SetupDbContext);
            void SetupDbContext(DbContextOptionsBuilder options)
            {
                options.UseSqlServer(Configuration["Data:AppDb:ConnectionString"]);
                options.EnableSensitiveDataLogging();
            }

            services.AddControllers()
                .AddNewtonsoftJson();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddApplicationServices();

            services.AddInfrastructureServices();

            services.AddTransient<IControllerServices, ControllerServices>();

            services.AddSwaggerGen(setupSwagger);

            static void setupSwagger(SwaggerGenOptions setupAction)
            {
                {
                    setupAction.SwaggerDoc(Constants.Swagger_Endpoint_Name, new OpenApiInfo()
                    {
                        Title = Constants.Swagger_Title,
                        Version = Constants.Swagger_Version,
                        Description = Constants.Swagger_Description,
                        Contact = new OpenApiContact()
                        {
                            Email = Constants.Swagger_Contact_Email,
                            Name = Constants.Swagger_Contact_Name,
                            Url = new Uri(Constants.Swagger_Contact_Website)
                        }
                    });

                    var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
                    setupAction.IncludeXmlComments(xmlCommentsFullPath);
                };
            }

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint(Constants.Swagger_Endpoint, Constants.Swagger_Title);
                setupAction.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }

        private static ILoggerFactory CreateLogger()
        {
            return LoggerFactory.Create(builder => builder.AddConsole());
        }
    }
}