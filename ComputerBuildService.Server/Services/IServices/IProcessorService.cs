using ComputerBuildService.Shared;
using ComputerBuildService.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerBuildService.Server.IServices
{
    public interface IProcessorService
    {
        Task<ResponseObject<IEnumerable<ProcessorResponse>>> GetAll(Pagination pagination);

        Task<ResponseObject<ProcessorResponse>> Get(int id);

        Task<ResponseObject<ProcessorResponse>> Create(ProcessorRequest request);

        Task<ResponseObject<ProcessorResponse>> Update(ProcessorRequest request);

        Task<ResponseObject<ProcessorResponse>> Delete(int id);

        Task<bool> Any(int id);
    }
}
