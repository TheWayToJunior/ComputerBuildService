using ComputerBuildService.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerBuildService.Server.Contract.Services
{
    public interface IService<TModel, TKey>
        where TModel : class, IEntity<TKey>
    {
        Task<ResultObject<TResponse>> Create<TRequest, TResponse>(TRequest request)
            where TResponse : class;

        Task<ResultObject<TResponse>> Update<TRequest, TResponse>(TRequest request)
            where TResponse : class;

        Task<ResultObject<TResponse>> Delete<TResponse>(TKey id)
            where TResponse : class;
    }
}
