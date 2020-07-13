using AutoMapper;
using ComputerBuildService.Server.IServices;
using ComputerBuildService.Shared.Models;
using ComputerBuildService.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerBuildService.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerBuildController : ControllerBase
    {
        private readonly IProcessorServise servise;
        private readonly IMapper mapper;
        private readonly ILogger<ComputerBuildController> logger;

        public ComputerBuildController(IProcessorServise servise, IMapper mapper, ILogger<ComputerBuildController> logger)
        {
            this.servise = servise ?? throw new ArgumentNullException(nameof(servise));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult<CentralProcessorUnit>> Get()
        {
            logger.LogInformation("Test Message");

            var dto = mapper.Map<ProcessorViewModel>(servise.GerRange(1, 1).FirstOrDefault());

            return Ok(dto);
        }
    }
}
