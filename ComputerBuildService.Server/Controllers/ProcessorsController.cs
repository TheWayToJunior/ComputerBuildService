using ComputerBuildService.Server.IServices;
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
    public class ProcessorsController : ControllerBase
    {
        private readonly IProcessorService service;
        private readonly ILogger<ProcessorsController> logger;

        public ProcessorsController(IProcessorService service, ILogger<ProcessorsController> logger)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.logger = logger   ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult<ResponseObject<IEnumerable<ProcessorResponse>>>> GetAll([FromQuery] Pagination pagination)
        {
            return Ok(await service.GetAll(pagination));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseObject<ProcessorResponse>>> Get(int id)
        {
            var response = await service.Get(id);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProcessorRequest requestModel)
        {
            var response = await service.Create(requestModel);

            return CreatedAtAction(
                    "Get",
                    new { Id = response.Value.Id },
                    response);
        }

        [HttpPut]
        public async Task<ActionResult<ResponseObject<ProcessorResponse>>> Update([FromBody] ProcessorRequest requestModel)
        {
            var result =  await service.Update(requestModel);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseObject<ProcessorResponse>>> Delete(int id)
        {
            var result = await service.Delete(id);

            return Ok(result);
        }
    }
}
