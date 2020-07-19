using AutoMapper;
using ComputerBuildService.Server.Helpers;
using ComputerBuildService.Server.IServices;
using ComputerBuildService.Shared;
using ComputerBuildService.Shared.Models.IntegratedModule;
using ComputerBuildService.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerBuildService.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntegratedGraphicsController
        : GenericController<IntegratedGraphics, IntegratedGraphicsRequest, IntegratedGraphicsResponse, int>
    {
        public IntegratedGraphicsController(IApplicationDbService<IntegratedGraphics, int> servise,
            IMapper mapper, ILogger<IntegratedGraphicsController> logger) : base(servise, mapper, logger)
        {
        }

        [HttpGet]
        public async override Task<ActionResult<IEnumerable<IntegratedGraphicsResponse>>> GetAll([FromQuery] Pagination pagination)
        {
            var models = await servise
                .GetAll()
                .Include(ig => ig.Motherboards)
                .Include(ig => ig.Processors)
                .Pagination(pagination.Index, pagination.Size)
                .ToArrayAsync();

            var response = mapper.Map<IntegratedGraphicsResponse[]>(models);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public override ActionResult<IntegratedGraphicsResponse> Get(int id)
        {
            var entity = servise
                .Include(ig => ig.Motherboards, ig => ig.Processors)
                .FirstOrDefault();

            if (entity == null)
                return NotFound();

            var response = mapper.Map<IntegratedGraphicsResponse>(entity);

            return Ok(response);
        }
    }
}
