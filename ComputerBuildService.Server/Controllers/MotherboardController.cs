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
    public class MotherboardController : ControllerBase
    {
        private readonly IMotherboardService service;
        private readonly ILogger<MotherboardController> logger;

        public MotherboardController(IMotherboardService service, ILogger<MotherboardController> logger)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult<ResultObject<IEnumerable<MotherboardResponse>>>> GetAll([FromQuery] Pagination pagination)
        {
            var response = await service.GetAll(pagination);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResultObject<ProcessorResponse>>> Get(int id)
        {
            var response = await service.Get(id);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ResultObject<MotherboardResponse>>> Add([FromBody] MotherboardRequest requestModel)
        {
            var response = await service.Create(requestModel);

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ResultObject<MotherboardResponse>>> Update([FromBody] MotherboardRequest requestModel)
        {
            var result = await service.Update(requestModel);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResultObject<MotherboardResponse>>> Delete(int id)
        {
            var result = await service.Delete(id);

            return Ok(result);
        }
    }
}
