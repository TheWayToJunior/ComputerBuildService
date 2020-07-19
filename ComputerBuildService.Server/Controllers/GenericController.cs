using AutoMapper;
using ComputerBuildService.Server.Helpers;
using ComputerBuildService.Server.IServices;
using ComputerBuildService.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerBuildService.Server.Controllers
{
    /// <summary>
    /// Базовый обобщённый REST API Controller
    /// </summary>
    /// <typeparam name="TModel">Модель данных</typeparam>
    /// <typeparam name="TRequest">Получаемое от клиента DTO, на основе которого будет обрабатываться модель</typeparam>
    /// <typeparam name="TResponse">Обьект отправляемый на клинт вместо основной модели</typeparam>
    /// <typeparam name="TPrimaryKey">Наследованный тип Id свойства от IEntity<TPrimaryKey></typeparam>
    [Route("api/[controller]")]
    [ApiController]
    public abstract class GenericController<TModel, TRequest, TResponse, TPrimaryKey> : ControllerBase
        where TModel : class, IEntity<TPrimaryKey>
        where TRequest : class
        where TResponse : class
    {
        protected readonly IApplicationDbService<TModel, TPrimaryKey> servise;
        protected readonly IMapper mapper;
        protected readonly ILogger<GenericController<TModel, TRequest, TResponse, TPrimaryKey>> logger;

        public GenericController(IApplicationDbService<TModel, TPrimaryKey> servise,
            IMapper mapper, ILogger<GenericController<TModel, TRequest, TResponse, TPrimaryKey>> logger)
        {
            this.servise = servise ?? throw new ArgumentNullException(nameof(servise));
            this.mapper = mapper   ?? throw new ArgumentNullException(nameof(mapper));
            this.logger = logger   ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TResponse>>> GetAll([FromQuery] Pagination pagination)
        {
            var models = await servise
                .GetAll()
                .Pagination(pagination.Index, pagination.Size)
                .ToArrayAsync();

            var response = mapper.Map<TResponse[]>(models);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public virtual ActionResult<TResponse> Get(TPrimaryKey id)
        {
            var entity = servise.Get(id);

            if (entity == null)
                return NotFound();

            var response = mapper.Map<TResponse>(entity);

            return Ok(response);
        }

        [HttpPost]
        public virtual IActionResult Add([FromBody] TRequest requestModel)
        {
            if (requestModel == null)
                return BadRequest($"The argument {nameof(requestModel)} cannot be null");

            var model = mapper.Map<TModel>(requestModel);

            try
            {
                var entity = servise.Add(model);

                logger.LogInformation("The entity has been added");

                servise.SaveChanges();

                var response = mapper.Map<TResponse>(entity);

                return CreatedAtAction(
                    "Get",
                    new { Id = entity.Id },
                    response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.InnerException.Message);

                return StatusCode(500, ex.InnerException.Message);
            }
        }

        [HttpPut("{id}")]
        public virtual IActionResult Update(TPrimaryKey id, [FromBody] TRequest requestModel)
        {
            if (requestModel == null)
                return BadRequest($"The argument {nameof(requestModel)} cannot be null");

            var model = mapper.Map<TModel>(requestModel);

            if (!model.Id.Equals(id))
                return BadRequest();

            try
            {
                /// Возможен сценнарий отсуцтвия объекта в базе данных
                servise.Update(model);

                logger.LogInformation("The entity has been update");

                servise.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                /// В случае ошибки проверяется существует ли такой объект в базе,
                /// если объект найден, значит не удалось обновить его
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
