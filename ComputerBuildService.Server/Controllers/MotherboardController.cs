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
    public class MotherboardController : GenericController<Motherboard, MotherboardRequest, MotherboardResponse, int>
    {
        public MotherboardController(IApplicationDbService<Motherboard, int> servise,
           IMapper mapper, ILogger<MotherboardController> logger) : base(servise, mapper, logger)
        {
        }

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<MotherboardResponse>>> GetAll([FromQuery] Pagination pagination)
        {
            var models = await servise
                .GetAll()
                .Include(m => m.IntegratedGraphics)
                .Include(m => m.IntegratedProcessor)
                .Pagination(pagination.Index, pagination.Size)
                .ToArrayAsync();

            var response = mapper.Map<MotherboardResponse[]>(models);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public override ActionResult<MotherboardResponse> Get(int id)
        {
            var entity = servise
                .Include(m => m.IntegratedGraphics)
                .Include(m => m.IntegratedProcessor)
                .FirstOrDefault(m => m.Id == id);

            if (entity == null)
                return NotFound();

            var response = mapper.Map<MotherboardResponse>(entity);

            return Ok(response);
        }
    }
}
