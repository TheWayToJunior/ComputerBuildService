using ComputerBuildService.Server.Contract.Data;
using ComputerBuildService.Server.Contract.Services;
using ComputerBuildService.Server.Helpers;
using ComputerBuildService.Shared;
using ComputerBuildService.Shared.Models;
using ComputerBuildService.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerBuildService.Server.Services
{
    public class GraphicsService : IGraphicsService
    {
        private readonly IService<GraphicsCard, int> service;
        private readonly IRepository repository;

        public GraphicsService(IService<GraphicsCard, int> service, IRepository repository)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<ResultObject<IEnumerable<GraphicsResponse>>> GetAll(Pagination pagination, SearchOptions options)
        {
            async Task<GraphicsCard[]> WrappedGetAll(Pagination pagin, SearchOptions opt)
            {
                return await repository
                    .GetAll<GraphicsCard, int>()
                    .Search(opt)
                    .Pagination(pagin)
                    .ToArrayAsync();
            }

            return await service.InvolucreGetAll<GraphicsResponse>(WrappedGetAll, pagination, options);
        }

        public async Task<ResultObject<GraphicsResponse>> Get(int objectId)
        {
            async Task<GraphicsCard> WrappedGet(int id)
            {
                return await repository
                    .Get<GraphicsCard, int>(id)
                    .FirstOrDefaultAsync(cpu => cpu.Id == id);
            }

            return await service.InvolucreGet<GraphicsResponse>(WrappedGet, objectId);
        }

        public async Task<ResultObject<GraphicsResponse>> Create(GraphicsRequest request)
        {
            var result = await service.Create<GraphicsRequest, GraphicsResponse>(request);

            return result;
        }

        public async Task<ResultObject<GraphicsResponse>> Update(GraphicsRequest request)
        {
            var result = await service.Update<GraphicsRequest, GraphicsResponse>(request);

            return result;
        }

        public async Task<ResultObject<GraphicsResponse>> Delete(int id)
        {
            var result = await service.Delete<GraphicsResponse>(id);

            return result;
        }

        public async Task<bool> Any(int id)
        {
            return await repository.Any<GraphicsCard, int>(id);
        }
    }
}
