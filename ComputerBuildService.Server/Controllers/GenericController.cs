using AutoMapper;
using ComputerBuildService.Server.Helpers;
using ComputerBuildService.Server.IServices;
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
    public abstract class GenericController<TModel, TViewModel> : ControllerBase
        where TModel : class
        where TViewModel : class
    {
        protected readonly IApplicationDbService<TModel> servise;
        protected readonly IMapper mapper;
        protected readonly ILogger<GenericController<TModel, TViewModel>> logger;

        public GenericController(IApplicationDbService<TModel> servise,
            IMapper mapper, ILogger<GenericController<TModel, TViewModel>> logger)
        {
            this.servise = servise ?? throw new ArgumentNullException(nameof(servise));
            this.mapper = mapper   ?? throw new ArgumentNullException(nameof(mapper));
            this.logger = logger   ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TViewModel>>> Get(int index = 1, int size = 5)
        {
            var models = await servise
                .GetAll()
                .Pagination(index, size)
                .ToArrayAsync();

            var viewModels = mapper.Map<TViewModel[]>(models);

            return Ok(viewModels);
        }

        [HttpGet("{id}")]
        public virtual ActionResult<TViewModel> Get(int id)
        {
            var entity = servise.Get(id);

            if (entity == null)
                return NotFound();

            var viewModel = mapper.Map<TViewModel>(entity);

            return Ok(viewModel);
        }

        [HttpPost]
        public virtual IActionResult Add([FromBody] TViewModel viewModel)
        {
            if (viewModel == null)
                return BadRequest($"The argument {nameof(viewModel)} cannot be null");

            var model = mapper.Map<TModel>(viewModel);

            try
            {
                var entityEntry = servise.Add(model);

                logger.LogInformation("The entity has been added");

                servise.SaveChanges();

                return CreatedAtAction(
                    "Get",
                    new { Id = (int)entityEntry.Property("Id").OriginalValue },
                    entityEntry.Entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.InnerException.Message);

                return StatusCode(500, ex.InnerException.Message);
            }
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int id)
        {
            var entity = servise.Get(id);

            if (entity == null)
                return NotFound();

            try
            {
                servise.Remove(entity);

                logger.LogInformation("The entity has been deleted");

                servise.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.InnerException.Message);

                return StatusCode(500, ex.InnerException.Message);
            }
        }
    }
}
