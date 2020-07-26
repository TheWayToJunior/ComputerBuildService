using ComputerBuildService.Shared;
using ComputerBuildService.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputerBuildService.Server.Contract.Services
{
    public interface IGraphicsCardService
    {
        Task<ResultObject<IEnumerable<GraphicsResponse>>> GetAll(Pagination pagination, SearchOptions options);

        Task<ResultObject<GraphicsResponse>> Get(int id);

        Task<ResultObject<GraphicsResponse>> Create(GraphicsRequest request);

        Task<ResultObject<GraphicsResponse>> Update(GraphicsRequest request);

        Task<ResultObject<GraphicsResponse>> Delete(int id);

        Task<bool> Any(int id);
    }
}
