using AutoMapper;
using ComputerBuildService.Server.IServices;
using ComputerBuildService.Shared.Models;
using ComputerBuildService.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ComputerBuildService.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CpuСoolerController : GenericController<CpuСooler, CpuСoolerRequest, CpuСoolerResponse, int>
    {
        public CpuСoolerController(IApplicationDbService<CpuСooler, int> servise,
            IMapper mapper, ILogger<CpuСoolerController> logger) : base(servise, mapper, logger)
        {
        }
    }
}
