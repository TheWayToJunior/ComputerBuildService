using AutoMapper;
using ComputerBuildService.Server.Configuration;
using ComputerBuildService.Server.Data;
using ComputerBuildService.Server.Helpers;
using ComputerBuildService.Server.IServices;
using ComputerBuildService.Server.Profiles;
using ComputerBuildService.Server.Services;
using ComputerBuildService.Shared.Models;
using ComputerBuildService.Shared.Models.IntegratedModule;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ComputerBuildService.Server
{
    public class Startup
    {
        private IConfiguration configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("ApplicationDbContext"));
            });

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ApplicatinProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            var dbServices = services.AddDbService(
                 new DbServiceOptions<Processor, int>("processorServeice"),
                 new DbServiceOptions<Cpu—ooler, int>("cpu—oolerServeice"),
                 new DbServiceOptions<Motherboard, int>("motherboardServeice"),
                 new DbServiceOptions<GraphicsCard, int>("graphicsCardServeice"),
                 new DbServiceOptions<IntegratedGraphics, int>("integratedGraphicsServeice")
             );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
