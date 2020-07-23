using AutoMapper;
using ComputerBuildService.Server.Contract.Data;
using ComputerBuildService.Server.Contract.Services;
using ComputerBuildService.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerBuildService.Server.Services
{
    public class GenericService<TModel, TKey> : IService<TModel, TKey>
        where TModel : class, IEntity<TKey>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public GenericService(IRepository repository, IMapper mapper)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ResultObject<TResponse>> Create<TRequest, TResponse>(TRequest request)
            where TResponse : class
        {
            var result = ResultObject<TResponse>.Create();

            if (request == null)
                return result.AddError(new Exception($"The specified object could not be found by request"));

            var model = mapper.Map<TModel>(request);
            TModel entity = null;

            try
            {
                entity = await repository.Add<TModel, TKey>(model);
                await repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            var response = mapper.Map<TResponse>(entity);
            return result.SetValue(response);
        }

        public async Task<ResultObject<TResponse>> Update<TRequest, TResponse>(TRequest request)
            where TResponse : class
        {
            var result = ResultObject<TResponse>.Create();

            if (request == null)
                return result.AddError(new Exception($"The specified object could not be found by request"));

            var model = mapper.Map<TModel>(request);

            try
            {
                repository.Update<TModel, TKey>(model);
                await repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }

        public async Task<ResultObject<TResponse>> Delete<TResponse>(TKey id)
            where TResponse : class
        {
            var result = ResultObject<TResponse>.Create();

            var entity = repository
                .Get<TModel, TKey>(id)
                .FirstOrDefault(cpu => cpu.Id.Equals(id));

            if (entity == null)
                return result.AddError(new Exception($"The specified object could not be found by id {id}"));

            try
            {
                await repository.Remove<TModel, TKey>(entity);
                await repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }
    }
}
