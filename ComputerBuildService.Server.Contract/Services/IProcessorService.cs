using ComputerBuildService.Shared;
using ComputerBuildService.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerBuildService.Server.Contract.Services
{
    public interface IProcessorService
    {
        Task<ResultObject<IEnumerable<ProcessorResponse>>> GetAll(Pagination pagination);

        Task<ResultObject<ProcessorResponse>> Get(int id);

        Task<ResultObject<ProcessorResponse>> Create(ProcessorRequest request);

        Task<ResultObject<ProcessorResponse>> Update(ProcessorRequest request);

        Task<ResultObject<ProcessorResponse>> Delete(int id);

        Task<bool> Any(int id);
    }
}
