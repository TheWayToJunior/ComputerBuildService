using ComputerBuildService.Server.Contract.Services;
using ComputerBuildService.Shared;
using ComputerBuildService.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerBuildService.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessorController : ControllerBase
    {
        private readonly IProcessorService service;
        private readonly ILogger<ProcessorController> logger;

        public ProcessorController(IProcessorService service, ILogger<ProcessorController> logger)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult<ResultObject<IEnumerable<ProcessorResponse>>>> GetAll(
            [FromQuery] Pagination pagination,
            [FromBody] SearchOptions options)
        {
            var response = await service.GetAll(pagination, options);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResultObject<ProcessorResponse>>> Get(int id)
        {
            var response = await service.Get(id);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ResultObject<ProcessorResponse>>> Add(
            [FromBody] ProcessorRequest requestModel)
        {
            var response = await service.Create(requestModel);

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ResultObject<ProcessorResponse>>> Update(
            [FromBody] ProcessorRequest requestModel)
        {
            var result = await service.Update(requestModel);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResultObject<ProcessorResponse>>> Delete(int id)
        {
            var result = await service.Delete(id);

            return Ok(result);
        }
    }
}
