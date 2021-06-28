using AutomobilesApi.Models.Database;
using AutomobilesApi.Models.Views;
using AutomobilesApi.RepositoriesApi;
using AutomobilesApi.ServicesApi;
using AutomobilesCore.Database;
using AutomobilesCore.Repositories;
using AutomobilesCore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text.Json.Serialization;
using Web.SwaggerExamples;

namespace Web
{
    public class Startup
    {
        private const string _dbConnectionParameter = "DbConnection";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            #region Services
            services.AddDbContext<AutomobilesDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString(_dbConnectionParameter)));

            services.AddScoped<IAutomobileRepository, AutomobileRepository>();
            services.AddScoped<IBaseRepository<Automobile>, AutomobileRepository>();
            services.AddScoped<IBaseRepository<Model>, ModelsRepository>();
            services.AddScoped<IBaseRepository<Body>, BodyRepository>();

            services.AddScoped<IBaseService<AutomobileView>, AutomobileService>();
            services.AddScoped<IAutomobileService, AutomobileService>();
            services.AddScoped<IBaseService<ModelView>, ModelsService>();
            services.AddScoped<IBodyService, BodyService>();
            #endregion Services

            #region Swagger
            services.AddSwaggerExamplesFromAssemblyOf<AutomobilesQueryExample>();
            services.AddSwaggerGen(c =>
            {
                c.ExampleFilters();
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AutomobilesAPI", Version = "v1" });
            });
            #endregion Swagger
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });


            #region SWAGGER
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Automobiles API V1");
            });
            #endregion SWAGGER
        }
    }
}
