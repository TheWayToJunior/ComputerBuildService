using ComputerBuildService.Server.Helpers;
using ComputerBuildService.Shared.Models;
using ComputerBuildService.Shared.Models.IntegratedModule;
using Microsoft.Extensions.DependencyInjection;

namespace ComputerBuildService.Server.Configuration
{
    /// <summary>
    /// Инкапсуляция инжектов db сервисов
    /// </summary>
    public class ConfigureDbServices
    {
        public static void Configure(IServiceCollection services)
        {
            var dbServices = services.AddDbService(
                 new DbServiceOptions<Processor, int>("processorServeice"),
                 new DbServiceOptions<CpuСooler, int>("cpuСoolerServeice"),
                 new DbServiceOptions<Motherboard, int>("motherboardServeice"),
                 new DbServiceOptions<GraphicsCard, int>("graphicsCardServeice"),
                 new DbServiceOptions<IntegratedGraphics, int>("integratedGraphicsServeice")
             );
        }
    }
}
