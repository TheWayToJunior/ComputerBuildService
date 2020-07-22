using ComputerBuildService.Shared;
using ComputerBuildService.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputerBuildService.Server.Contract.Services
{
    public interface IMotherboardService
    {
        Task<ResultObject<IEnumerable<MotherboardResponse>>> GetAll(Pagination pagination);

        Task<ResultObject<MotherboardResponse>> Get(int id);

        Task<ResultObject<MotherboardResponse>> Create(MotherboardRequest request);

        Task<ResultObject<MotherboardResponse>> Update(MotherboardRequest request);

        Task<ResultObject<MotherboardResponse>> Delete(int id);

        Task<bool> Any(int id);
    }
}
