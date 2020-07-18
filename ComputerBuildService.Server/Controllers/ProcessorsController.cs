using AutoMapper;
using ComputerBuildService.Server.Helpers;
using ComputerBuildService.Server.IServices;
using ComputerBuildService.Shared;
using ComputerBuildService.Shared.Models;
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
    public class ProcessorsController : GenericController<Processor, ProcessorRequest, ProcessorResponse, int>
    {
        public ProcessorsController(IApplicationDbService<Processor, int> servise,
            IMapper mapper, ILogger<ProcessorsController> logger) : base(servise, mapper, logger)
        {
        }

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<ProcessorResponse>>> GetAll([FromQuery] Pagination pagination)
        {
            var models = await servise
                .GetAll()
                .Include(cpu => cpu.IntegratedGraphics)
                .Pagination(pagination.Index, pagination.Size)
                .ToArrayAsync();

            var response = mapper.Map<ProcessorResponse[]>(models);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public override ActionResult<ProcessorResponse> Get(int id)
        {
            var entity = servise.Include(cpu => cpu.IntegratedGraphics)
                .FirstOrDefault(cpu => cpu.Id == id);

            if (entity == null)
                return NotFound();

            var response = mapper.Map<ProcessorResponse>(entity);

            return Ok(response);
        }
    }
}
