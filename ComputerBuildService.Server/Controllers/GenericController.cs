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
    public abstract class GenericController<TModel, TViewModel, TPrimaryKey> : ControllerBase
        where TModel : class, IEntity<TPrimaryKey>
        where TViewModel : class, IEntity<TPrimaryKey>
    {
        protected readonly IApplicationDbService<TModel, TPrimaryKey> servise;
        protected readonly IMapper mapper;
        protected readonly ILogger<GenericController<TModel, TViewModel, TPrimaryKey>> logger;

        public GenericController(IApplicationDbService<TModel, TPrimaryKey> servise,
            IMapper mapper, ILogger<GenericController<TModel, TViewModel, TPrimaryKey>> logger)
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
        public virtual ActionResult<TViewModel> Get(TPrimaryKey id)
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

        [HttpPut("{id}")]
        public virtual IActionResult Put(TPrimaryKey id, [FromBody] TViewModel viewModel)
        {
            if (viewModel == null)
                return BadRequest($"The argument {nameof(viewModel)} cannot be null");

            if (!viewModel.Id.Equals(id))
                return BadRequest();

            var model = mapper.Map<TModel>(viewModel);

            try
            {
                servise.Update(model);

                logger.LogInformation("The entity has been update");

                servise.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                var exists = servise.Any(id);

                if (!exists)
                {
                    return NotFound();
                }
                else
                {
                    logger.LogError(ex.InnerException.Message);

                    return StatusCode(500, ex.InnerException.Message);
                }
            }
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(TPrimaryKey id)
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
