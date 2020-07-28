using ComputerBuildService.Server.Contract.Services;
using ComputerBuildService.Shared;
using ComputerBuildService.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerBuildService.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemoryController : ControllerBase
    {
        private readonly IMemoryService service;

        public MemoryController(IMemoryService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public async Task<ActionResult<ResultObject<IEnumerable<MemoryResponse>>>> GetAll(
            [FromQuery] Pagination pagination,
            [FromBody] SearchOptions options)
        {
            var response = await service.GetAll(pagination, options);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResultObject<MemoryResponse>>> Get(int id)
        {
            var response = await service.Get(id);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ResultObject<MemoryResponse>>> Add(
            [FromBody] MemoryRequest requestModel)
        {
            var response = await service.Create(requestModel);

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ResultObject<MemoryResponse>>> Update(
            [FromBody] MemoryRequest requestModel)
        {
            var result = await service.Update(requestModel);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResultObject<MemoryResponse>>> Delete(int id)
        {
            var result = await service.Delete(id);

            return Ok(result);
        }
    }
}
