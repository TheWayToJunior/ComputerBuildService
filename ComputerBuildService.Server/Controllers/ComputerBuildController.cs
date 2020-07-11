using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ComputerBuildService.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerBuildController : ControllerBase
    {
        private readonly ILogger<ComputerBuildController> logger;

        public ComputerBuildController(ILogger<ComputerBuildController> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult<int>> Get()
        {
            logger.LogInformation("Test Message");

            return Ok(200);
        }
    }
}
