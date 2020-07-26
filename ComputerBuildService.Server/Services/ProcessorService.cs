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
    public class ProcessorService : IProcessorService
    {
        private readonly IService<Processor, int> service;
        private readonly IRepository repository;

        public ProcessorService(IService<Processor, int> service, IRepository repository)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<ResultObject<IEnumerable<ProcessorResponse>>> GetAll(Pagination pagination, SearchOptions options)
        {
            async Task<Processor[]> WrappedGetAll(Pagination pagin, SearchOptions opt)
            {
                return await repository
                    .GetAll<Processor, int>()
                    .Include(cpu => cpu.IntegratedGraphics)
                    .Search(opt)
                    .Pagination(pagin)
                    .ToArrayAsync();
            }

            return await service.InvolucreGetAll<ProcessorResponse>(WrappedGetAll, pagination, options);
        }

        public async Task<ResultObject<ProcessorResponse>> Get(int objectId)
        {
            async Task<Processor> WrappedGet(int id)
            {
                return await repository
                    .Get<Processor, int>(id)
                    .Include(cpu => cpu.IntegratedGraphics)
                    .FirstOrDefaultAsync(cpu => cpu.Id == id);
            }

            return await service.InvolucreGet<ProcessorResponse>(WrappedGet, objectId);
        }

        public async Task<ResultObject<ProcessorResponse>> Create(ProcessorRequest request)
        {
            var result = await service.Create<ProcessorRequest, ProcessorResponse>(request);

            return result;
        }

        public async Task<ResultObject<ProcessorResponse>> Update(ProcessorRequest request)
        {
            var result = await service.Update<ProcessorRequest, ProcessorResponse>(request);

            return result;
        }

        public async Task<ResultObject<ProcessorResponse>> Delete(int id)
        {
            var result = await service.Delete<ProcessorResponse>(id);

            return result;
        }

        public async Task<bool> Any(int id)
        {
            return await repository.Any<Processor, int>(id);
        }
    }
}
