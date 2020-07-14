using AutoMapper;
using ComputerBuildService.Server.Helpers;
using ComputerBuildService.Server.IServices;
using ComputerBuildService.Shared.Models;
using ComputerBuildService.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerBuildService.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessorsController : GenericController<Processor, ProcessorViewModel, int>
    {
        public ProcessorsController(IApplicationDbService<Processor, int> servise,
            IMapper mapper, ILogger<ProcessorsController> logger) : base(servise, mapper, logger)
        {
        }

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<ProcessorViewModel>>> Get(int index = 1, int size = 5)
        {
            var models = await servise
                .GetAll()
                .Include(cpu => cpu.IntegratedGraphics)
                .Pagination(index, size)
                .ToArrayAsync();

            var viewModels = mapper.Map<ProcessorViewModel[]>(models);

            return Ok(viewModels);
        }
    }
}
