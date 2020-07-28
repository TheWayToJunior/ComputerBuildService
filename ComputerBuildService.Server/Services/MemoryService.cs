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
    public class MemoryService : IMemoryService
    {
        private readonly IService<RandomAccessMemory, int> service;
        private readonly IRepository repository;

        public MemoryService(IService<RandomAccessMemory, int> service, IRepository repository)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<ResultObject<IEnumerable<MemoryResponse>>> GetAll(Pagination pagination, SearchOptions options)
        {
            async Task<RandomAccessMemory[]> WrappedGetAll(Pagination pagin, SearchOptions opt)
            {
                return await repository
                    .GetAll<RandomAccessMemory, int>()
                    .Search(opt)
                    .Pagination(pagin)
                    .ToArrayAsync();
            }

            return await service.InvolucreGetAll<MemoryResponse>(WrappedGetAll, pagination, options);
        }

        public async Task<ResultObject<MemoryResponse>> Get(int objectId)
        {
            async Task<RandomAccessMemory> WrappedGet(int id)
            {
                return await repository
                    .Get<RandomAccessMemory, int>(id)
                    .FirstOrDefaultAsync(cpu => cpu.Id == id);
            }

            return await service.InvolucreGet<MemoryResponse>(WrappedGet, objectId);
        }

        public async Task<ResultObject<MemoryResponse>> Create(MemoryRequest request)
        {
            var result = await service.Create<MemoryRequest, MemoryResponse>(request);

            return result;
        }

        public async Task<ResultObject<MemoryResponse>> Update(MemoryRequest request)
        {
            var result = await service.Update<MemoryRequest, MemoryResponse>(request);

            return result;
        }

        public async Task<ResultObject<MemoryResponse>> Delete(int id)
        {
            var result = await service.Delete<MemoryResponse>(id);

            return result;
        }
    }
}
