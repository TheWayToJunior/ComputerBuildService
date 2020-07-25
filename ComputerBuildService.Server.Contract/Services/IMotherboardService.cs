using ComputerBuildService.Shared;
using ComputerBuildService.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerBuildService.Server.Contract.Services
{
    public interface IMotherboardService
    {
        Task<ResultObject<IEnumerable<MotherboardResponse>>> GetAll(Pagination pagination, SearchOptions options);

        Task<ResultObject<MotherboardResponse>> Get(int id);

        Task<ResultObject<MotherboardResponse>> Create(MotherboardRequest request);

        Task<ResultObject<MotherboardResponse>> Update(MotherboardRequest request);

        Task<ResultObject<MotherboardResponse>> Delete(int id);

        Task<bool> Any(int id);
    }
}
