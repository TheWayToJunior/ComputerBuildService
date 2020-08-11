using AutoMapper;
using ComputerBuildService.BL.Helpers;
using ComputerBuildService.BL.IServices;
using ComputerBuildService.BL.Models;
using ComputerBuildService.BL.Models.Requests;
using ComputerBuildService.DAL.Entities;
using ComputerBuildService.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerBuildService.BL.Services
{
    public class HardwareItemService : IHardwareItemService
    {
        private readonly IRepositoryContainer container;
        private readonly IMapper mapper;

        public HardwareItemService(IRepositoryContainer container, IMapper mapper)
        {
            this.container = container ?? throw new ArgumentNullException(nameof(container));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Возвращает коллекцию необходимых компьютерных деталей
        /// </summary>
        /// <param name="pagination">Параметры постраничной навигации</param>
        /// <param name="selecting">Параметры выбора деталей</param>
        /// <returns></returns>
        public async Task<ResultObject<IEnumerable<HardwareItemResponse>>> GetHardwareItem(
            Pagination pagination,
            SelectingHardware selecting)
        {
            var result = ResultObject<IEnumerable<HardwareItemResponse>>.Create();

            IEnumerable<HardwareItemEntity> takeEntities = null;

            try
            {
                var entities = await GetHardwareItemByType(selecting.Type);

                takeEntities = (await SelectHardware(entities, selecting.СompatibilityProperties))
                    .Pagination(pagination)
                    .ToArray();
            }
            catch (Exception ex)
            {
                return result.AddError(ex);
            }

            var response = mapper.Map<HardwareItemResponse[]>(takeEntities);

            return result.SetValue(response);
        }

        private async Task<IQueryable<HardwareItemEntity>> GetHardwareItemByType(string hardwareType)
        {
            var entityType = await container.HardwareTypeRepository.SearchByName(hardwareType);

            if (entityType == null)
                throw new Exception($"The specified spare part type could not be found: {hardwareType}");

            var entitys = await container.HardwareItemRepository.GetAllFullObjects();

            return entitys.Where(item => item.HardwareType.Id == entityType.Id);
        }

        private async Task<IEnumerable<HardwareItemEntity>> SelectHardware(
            IQueryable<HardwareItemEntity> entities,
            IEnumerable<CompatibilityPropertyRequest> propertiesRequests)
        {
            if (!propertiesRequests?.Any() ?? true)
                return entities.AsEnumerable();

            var propentieEntities = await container.CompatibilityPropertyRepository
                    .Get(propertiesRequests.Select(e => (e.PropertyType, e.PropertyName)));

            return entities
                    .AsEnumerable()
                    .Where(e => !propentieEntities.Except(e.PropertysItems.Select(pi => pi.Property)).Any());
        }

        /// <summary>
        /// Добавляет новую деталь в базу, в случае если изготовитель или тип детали отсутствует в базе,
        /// он будет добавлен автоматически
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ResultObject<HardwareItemResponse>> AddHardwareItem(HardwareItemRequest request)
        {
            var result = ResultObject<HardwareItemResponse>.Create();

            var mapEntity = mapper.Map<HardwareItemEntity>(request);

            HardwareItemEntity entity = null;

            try
            {
                await MapPropertyRequest(mapEntity, request.PropertysItems);

                var manufacturerEntity = await GetOrCreateEntity(container.ManufacturerRepository, request.Manufacturer);
                mapEntity.Manufacturer = manufacturerEntity;

                var hardwareTypeEntity = await GetOrCreateEntity(container.HardwareTypeRepository, request.HardwareType);
                mapEntity.HardwareType = hardwareTypeEntity;

                entity = await container.HardwareItemRepository.AddAsync(mapEntity);
                await container.SaveAsync();
            }
            catch (Exception ex)
            {
                if (entity != null)
                    await container.HardwareItemRepository.RemoveAsync(entity);

                return result.AddError(ex);
            }

            var response = mapper.Map<HardwareItemResponse>(entity);

            return result.SetValue(response);
        }

        /// <summary>
        /// Изменяет данные указанного объекта
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ResultObject<HardwareItemResponse>> UpdateHardwareItem(HardwareItemRequest request)
        {
            var result = ResultObject<HardwareItemResponse>.Create();

            var entity = await container.HardwareItemRepository.GetFullObject(request.Id);

            if (entity == null)
                return result.AddError(new Exception($"The specified object could not be found: Id = {request.Id}"));

            try
            {
                /// Мапит в entity, игнорируя связи, новый объект который мы получили
                mapper.Map(request, entity);

                /// Удаляет старые связи детали к характеристикам
                entity.PropertysItems.Clear();
                await MapPropertyRequest(entity, request.PropertysItems);

                var manufacturerEntity = await GetOrCreateEntity(container.ManufacturerRepository, request.Manufacturer);
                entity.Manufacturer = manufacturerEntity;

                var hardwareTypeEntity = await GetOrCreateEntity(container.HardwareTypeRepository, request.HardwareType);
                entity.HardwareType = hardwareTypeEntity;

                await container.SaveAsync();
            }
            catch (Exception ex)
            {
                return result.AddError(ex);
            }

            return result;
        }

        private async Task<TModel> GetOrCreateEntity<TModel, TKey>(IRepository<TModel, TKey> repository, string name)
            where TModel : class, IUniqueEntity<TKey>, new()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            var entity = await (repository as ISearcher<TModel, TKey>).SearchByName(name);

            if (entity != null)
                return entity;

            entity = await repository.AddAsync(new TModel { Name = name });

            return entity;
        }

        /// <summary>
        /// Проверяет существует ли properties, в случае если в базе нет данного объекта создает новый
        /// и установит необходимые связи
        /// </summary>
        private async Task MapPropertyRequest(HardwareItemEntity entity, IEnumerable<CompatibilityPropertyRequest> properties)
        {
            var propertysItems = new List<CompatibilityPropertyHardwareItem>();

            foreach (var item in properties)
            {
                var propertyEntity = await container.CompatibilityPropertyRepository.Get(item.PropertyType, item.PropertyName);

                if (propertyEntity == null)
                {
                    propertyEntity = await container.CompatibilityPropertyRepository.AddAsync(new CompatibilityPropertyEntity
                    {
                        PropertyName = item.PropertyName,
                        PropertyType = item.PropertyType
                    });
                }

                propertysItems.Add(new CompatibilityPropertyHardwareItem
                {
                    Item = entity,
                    Property = propertyEntity
                });
            }

            entity.PropertysItems = propertysItems;
        }

        public async Task<ResultObject<HardwareItemResponse>> DeleteHardwareItem(int id)
        {
            var result = ResultObject<HardwareItemResponse>.Create();

            var entity = await container.HardwareItemRepository.GetFullObject(id);

            if (entity == null)
                return result.AddError(new Exception($"The specified object could not be found: Id = {id}"));

            try
            {
                await container.HardwareItemRepository.RemoveAsync(entity);
                await container.SaveAsync();
            }
            catch (Exception ex)
            {
                return result.AddError(ex);
            }

            return result;
        }
    }
}
