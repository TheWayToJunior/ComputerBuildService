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
using System.Linq;
using System.Threading.Tasks;

namespace ComputerBuildService.Server.Services
{
    public class ProcessorService : IProcessorService
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public ProcessorService(IRepository repository, IMapper mapper)
        {
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
            var result = ResultObject<ProcessorResponse>.Create();
            var model = mapper.Map<Processor>(request);

            if (model == null)
               return result.AddError(new Exception($"The specified object could not be found by model"));

            Processor entity = null;

            try
            {
                entity = await repository.Add<Processor, int>(model);
                await repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            var response = mapper.Map<ProcessorResponse>(entity);
            return result.SetValue(response);
        }

        public async Task<ResultObject<ProcessorResponse>> Update(ProcessorRequest request)
        {
            var result = ResultObject<ProcessorResponse>.Create();
            var model = mapper.Map<Processor>(request);

            if (model == null)
                return result.AddError(new Exception($"The specified object could not be found by model"));

            try
            {
                repository.Update<Processor, int>(model);
                await repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }

        public async Task<ResultObject<ProcessorResponse>> Delete(int id)
        {
            var result = ResultObject<ProcessorResponse>.Create();

            var entity = repository
                .Get<Processor, int>(id)
                .FirstOrDefault(cpu => cpu.Id == id);

            if (entity == null)
                return result.AddError(new Exception($"The specified object could not be found by id {id}"));

            try
            {
                await repository.Remove<Processor, int>(entity);
                await repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }

        public async Task<bool> Any(int id)
        {
            return await repository.Any<Processor, int>(id);
        }
    }
}
