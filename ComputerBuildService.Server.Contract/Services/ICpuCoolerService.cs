using ComputerBuildService.Shared;
using ComputerBuildService.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerBuildService.Server.Contract.Services
{
    public interface ICpuCoolerService
    {
        Task<ResultObject<IEnumerable<CpuСoolerResponse>>> GetAll(Pagination pagination, SearchOptions options);

        Task<ResultObject<CpuСoolerResponse>> Get(int id);

        Task<ResultObject<CpuСoolerResponse>> Create(CpuСoolerRequest request);

        Task<ResultObject<CpuСoolerResponse>> Update(CpuСoolerRequest request);

        Task<ResultObject<CpuСoolerResponse>> Delete(int id);

        Task<bool> Any(int id);
    }
}
