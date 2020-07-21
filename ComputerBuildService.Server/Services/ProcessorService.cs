using AutoMapper;
using ComputerBuildService.Server.Helpers;
using ComputerBuildService.Server.IServices;
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

        public async Task<ResponseObject<IEnumerable<ProcessorResponse>>> GetAll(Pagination pagination)
        {
            var entity = await repository
                .GetAll<Processor, int>()
                .Include(cpu => cpu.IntegratedGraphics)
                .Pagination(pagination.Index, pagination.Size)
                .ToArrayAsync();

            var response = mapper.Map<ProcessorResponse[]>(entity);

            return ResponseObject<IEnumerable<ProcessorResponse>>.Create(response);
        }

        public async Task<ResponseObject<ProcessorResponse>> Get(int id)
        {
            var entity = await repository
                .Get<Processor, int>(id)
                .Include(cpu => cpu.IntegratedGraphics)
                .FirstOrDefaultAsync(cpu => cpu.Id == id);

            if (entity == null)
                return ResponseObject<ProcessorResponse>.Create(null,
                    new Exception($"The specified object could not be found by id {id}"));

            var response = mapper.Map<ProcessorResponse>(entity);

            return ResponseObject<ProcessorResponse>.Create(response);
        }

        public async Task<ResponseObject<ProcessorResponse>> Create(ProcessorRequest request)
        {
            var model = mapper.Map<Processor>(request);

            try
            {
                var entity = repository.Add<Processor, int>(model);
                await repository.SaveChangesAsync();

                var response = mapper.Map<ProcessorResponse>(entity);

                return ResponseObject<ProcessorResponse>.Create(response);
            }
            catch (Exception ex)
            {
                return ResponseObject<ProcessorResponse>.Create(null, ex);
            }
        }

        public async Task<ResponseObject<ProcessorResponse>> Update(ProcessorRequest request)
        {
            var model = mapper.Map<Processor>(request);

            try
            {
                repository.Update<Processor, int>(model);
                await repository.SaveChangesAsync();

                return ResponseObject<ProcessorResponse>.Create(null);
            }
            catch (Exception ex)
            {
                return ResponseObject<ProcessorResponse>.Create(null, ex);
            }
        }

        public async Task<ResponseObject<ProcessorResponse>> Delete(int id)
        {
            var entity = repository
                .Get<Processor, int>(id)
                .FirstOrDefault(cpu => cpu.Id == id);

            try
            {
                await repository.Remove<Processor, int>(entity);
                await repository.SaveChangesAsync();

                return ResponseObject<ProcessorResponse>.Create(null);
            }
            catch (Exception ex)
            {

                return ResponseObject<ProcessorResponse>.Create(null, ex);
            }
        }

        public async Task<bool> Any(int id)
        {
            return await repository.Any<Processor, int>(id);
        }
    }
}
