using AutoMapper;
using ComputerBuildService.Server.Contract.Data;
using ComputerBuildService.Server.Contract.Services;
using ComputerBuildService.Server.Helpers;
using ComputerBuildService.Shared;
using ComputerBuildService.Shared.Models;
using ComputerBuildService.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerBuildService.Server.Services
{
    public class MotherboardService : IMotherboardService
    {
        private readonly IService<Motherboard, int> service;
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public MotherboardService(IService<Motherboard, int> service, IRepository repository, IMapper mapper)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ResultObject<IEnumerable<MotherboardResponse>>> GetAll(Pagination pagination)
        {
            var entity = await repository
                 .GetAll<Motherboard, int>()
                 .Include(m => m.IntegratedGraphics)
                 .Include(m => m.IntegratedProcessor)
                 .Pagination(pagination.Index, pagination.Size)
                 .ToArrayAsync();

            var response = mapper.Map<MotherboardResponse[]>(entity);

            return ResultObject<IEnumerable<MotherboardResponse>>.Create(response);
        }

        public async Task<ResultObject<MotherboardResponse>> Get(int id)
        {
            var result = ResultObject<MotherboardResponse>.Create();

            var entity = await repository
                .Get<Motherboard, int>(id)
                .Include(m => m.IntegratedGraphics)
                .Include(m => m.IntegratedProcessor)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (entity == null)
                return result.AddError(new Exception($"The specified object could not be found by id {id}"));

            var response = mapper.Map<MotherboardResponse>(entity);

            return result.SetValue(response);
        }

        public async Task<ResultObject<MotherboardResponse>> Create(MotherboardRequest request)
        {
            var result = await service.Create<MotherboardRequest, MotherboardResponse>(request);

            return result;
        }

        public async Task<ResultObject<MotherboardResponse>> Update(MotherboardRequest request)
        {
            var result = await service.Update<MotherboardRequest, MotherboardResponse>(request);

            return result;
        }

        public async Task<ResultObject<MotherboardResponse>> Delete(int id)
        {
            var result = await service.Delete<MotherboardResponse>(id);

            return result;
        }

        public async Task<bool> Any(int id)
        {
            return await repository.Any<Motherboard, int>(id);
        }
    }
}
