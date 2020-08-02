using AutoMapper;
using ComputerBuildService.BL.Helpers;
using ComputerBuildService.BL.IServices;
using ComputerBuildService.BL.Models;
using ComputerBuildService.BL.Models.Requests;
using ComputerBuildService.DAL.Entitys;
using ComputerBuildService.DAL.IRepositorys;
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

        private async Task<IQueryable<HardwareItemEntity>> GetHardwareItemByType(string hardwareType)
        {
            var entityType = await container.HardwareTypeRepository.GetByName(hardwareType);

            if (entityType == null)
                throw new Exception($"The specified spare part type could not be found: {hardwareType}");

            var entitys = await container.HardwareItemRepository.GetAllFullObjects();

            return entitys.Where(item => item.HardwareType.Id == entityType.Id);
        }

        private async Task<IEnumerable<HardwareItemEntity>> SelectHardware(
            IQueryable<HardwareItemEntity> entities,
            IEnumerable<CompatibilityPropertyRequest> propertyResponses)
        {
            if (!propertyResponses?.Any() ?? true)
                return entities.AsEnumerable();

            var propentieEntities = await container.CompatibilityPropertyRepository
                    .GetByName(propertyResponses.Select(e => (e.PropertyType, e.PropertyName)));

            return entities
                    .AsEnumerable()
                    .Where(e => !propentieEntities.Except(e.PropertysItems.Select(pi => pi.Property)).Any());
        }

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
    }
}
