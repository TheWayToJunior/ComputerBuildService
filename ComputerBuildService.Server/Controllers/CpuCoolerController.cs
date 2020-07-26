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
    public class CpuCoolerController : ControllerBase
    {
        private readonly ICpuCoolerService service;
        private readonly ILogger<CpuCoolerController> logger;

        public CpuCoolerController(ICpuCoolerService service, ILogger<CpuCoolerController> logger)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult<ResultObject<IEnumerable<CpuСoolerResponse>>>> GetAll(
            [FromQuery] Pagination pagination,
            [FromBody] SearchOptions options)
        {
            var response = await service.GetAll(pagination, options);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResultObject<CpuСoolerResponse>>> Get(int id)
        {
            var response = await service.Get(id);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ResultObject<CpuСoolerResponse>>> Add(
            [FromBody] CpuСoolerRequest requestModel)
        {
            var response = await service.Create(requestModel);

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ResultObject<CpuСoolerResponse>>> Update(
            [FromBody] CpuСoolerRequest requestModel)
        {
            var result = await service.Update(requestModel);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResultObject<CpuСoolerResponse>>> Delete(int id)
        {
            var result = await service.Delete(id);

            return Ok(result);
        }
    }
}
