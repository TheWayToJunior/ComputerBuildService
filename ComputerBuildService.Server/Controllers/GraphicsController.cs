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
    public class GraphicsController : ControllerBase
    {
        private readonly IGraphicsService service;
        private readonly ILogger<GraphicsController> logger;

        public GraphicsController(IGraphicsService service, ILogger<GraphicsController> logger)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult<ResultObject<IEnumerable<GraphicsResponse>>>> GetAll(
            [FromQuery] Pagination pagination,
            [FromBody] SearchOptions options)
        {
            var response = await service.GetAll(pagination, options);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResultObject<GraphicsResponse>>> Get(int id)
        {
            var response = await service.Get(id);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ResultObject<GraphicsResponse>>> Add(
            [FromBody] GraphicsRequest requestModel)
        {
            var response = await service.Create(requestModel);

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ResultObject<GraphicsResponse>>> Update(
            [FromBody] GraphicsRequest requestModel)
        {
            var result = await service.Update(requestModel);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResultObject<GraphicsResponse>>> Delete(int id)
        {
            var result = await service.Delete(id);

            return Ok(result);
        }
    }
}
