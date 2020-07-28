using ComputerBuildService.Shared;
using ComputerBuildService.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerBuildService.Server.Contract.Services
{
    public interface IMemoryService
    {
        Task<ResultObject<IEnumerable<MemoryResponse>>> GetAll(Pagination pagination, SearchOptions options);

        Task<ResultObject<MemoryResponse>> Get(int id);

        Task<ResultObject<MemoryResponse>> Create(MemoryRequest request);

        Task<ResultObject<MemoryResponse>> Update(MemoryRequest request);

        Task<ResultObject<MemoryResponse>> Delete(int id);
    }
}
