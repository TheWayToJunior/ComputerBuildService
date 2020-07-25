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

        public MotherboardService(IService<Motherboard, int> service, IRepository repository)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<ResultObject<IEnumerable<MotherboardResponse>>> GetAll(Pagination pagination, SearchOptions options)
        {
            async Task<Motherboard[]> WrappedFunc(Pagination pagin, SearchOptions opt)
            {
                return await repository
                    .GetAll<Motherboard, int>()
                    .Include(m => m.IntegratedGraphics)
                    .Include(m => m.IntegratedProcessor)
                    .Search(opt)
                    .Pagination(pagin)
                    .ToArrayAsync();
            }

            return await service.InvolucreGetAll<MotherboardResponse>(WrappedFunc, pagination, options);
        }

        public async Task<ResultObject<MotherboardResponse>> Get(int objectId)
        {
            async Task<Motherboard> WrappedFunc(int id)
            {
                return await repository
                    .Get<Motherboard, int>(id)
                    .Include(m => m.IntegratedGraphics)
                    .Include(m => m.IntegratedProcessor)
                    .FirstOrDefaultAsync(m => m.Id == id);
            }

            return await service.InvolucreGet<MotherboardResponse>(WrappedFunc, objectId);
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
