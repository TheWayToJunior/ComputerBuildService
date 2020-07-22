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
    public class ProcessorService : IProcessorService
    {
        private readonly IService<Processor, int> service;
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public ProcessorService(IService<Processor, int> service, IRepository repository, IMapper mapper)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ResultObject<IEnumerable<ProcessorResponse>>> GetAll(Pagination pagination)
        {
            var entity = await repository
                .GetAll<Processor, int>()
                .Include(cpu => cpu.IntegratedGraphics)
                .Pagination(pagination.Index, pagination.Size)
                .ToArrayAsync();

            var response = mapper.Map<ProcessorResponse[]>(entity);

            return ResultObject<IEnumerable<ProcessorResponse>>.Create(response);
        }

        public async Task<ResultObject<ProcessorResponse>> Get(int id)
        {
            var result = ResultObject<ProcessorResponse>.Create();

            var entity = await repository
                .Get<Processor, int>(id)
                .Include(cpu => cpu.IntegratedGraphics)
                .FirstOrDefaultAsync(cpu => cpu.Id == id);

            if (entity == null)
                return result.AddError(new Exception($"The specified object could not be found by id {id}"));

            var response = mapper.Map<ProcessorResponse>(entity);

            return result.SetValue(response);
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
