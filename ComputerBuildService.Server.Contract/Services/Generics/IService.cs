using ComputerBuildService.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerBuildService.Server.Contract.Services
{
    public interface IService<TModel, TKey>
        where TModel : class, IEntity<TKey>
    {
        Task<ResultObject<IEnumerable<TResponse>>> InvolucreGetAll<TResponse>(
            Func<Pagination, SearchOptions, Task<TModel[]>> wrappedFunc,
            Pagination pagination,
            SearchOptions options)
            where TResponse : class;

        Task<ResultObject<TResponse>> InvolucreGet<TResponse>(Func<int, Task<TModel>> wrappedFunc, int Id)
          where TResponse : class;

        Task<ResultObject<TResponse>> Create<TRequest, TResponse>(TRequest request)
             where TResponse : class;

        Task<ResultObject<TResponse>> Update<TRequest, TResponse>(TRequest request)
            where TResponse : class;

        Task<ResultObject<TResponse>> Delete<TResponse>(TKey id)
            where TResponse : class;
    }
}
