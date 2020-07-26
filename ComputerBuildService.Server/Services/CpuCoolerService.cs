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
    public class CpuCoolerService : ICpuCoolerService
    {
        private readonly IService<CpuСooler, int> service;
        private readonly IRepository repository;

        public CpuCoolerService(IService<CpuСooler, int> service, IRepository repository)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<ResultObject<IEnumerable<CpuСoolerResponse>>> GetAll(Pagination pagination, SearchOptions options)
        {
            async Task<CpuСooler[]> WrappedGetAll(Pagination pagin, SearchOptions opt)
            {
                return await repository
                    .GetAll<CpuСooler, int>()
                    .Search(opt)
                    .Pagination(pagin)
                    .ToArrayAsync();
            }

            return await service.InvolucreGetAll<CpuСoolerResponse>(WrappedGetAll, pagination, options);
        }

        public async Task<ResultObject<CpuСoolerResponse>> Get(int objectId)
        {
            async Task<CpuСooler> WrappedGet(int id)
            {
                return await repository
                    .Get<CpuСooler, int>(id)
                    .FirstOrDefaultAsync(cpu => cpu.Id == id);
            }

            return await service.InvolucreGet<CpuСoolerResponse>(WrappedGet, objectId);
        }

        public async Task<ResultObject<CpuСoolerResponse>> Create(CpuСoolerRequest request)
        {
            var result = await service.Create<CpuСoolerRequest, CpuСoolerResponse>(request);

            return result;
        }

        public async Task<ResultObject<CpuСoolerResponse>> Update(CpuСoolerRequest request)
        {
            var result = await service.Update<CpuСoolerRequest, CpuСoolerResponse>(request);

            return result;
        }

        public async Task<ResultObject<CpuСoolerResponse>> Delete(int id)
        {
            var result = await service.Delete<CpuСoolerResponse>(id);

            return result;
        }

        public async Task<bool> Any(int id)
        {
            return await repository.Any<CpuСooler, int>(id);
        }
    }
}
