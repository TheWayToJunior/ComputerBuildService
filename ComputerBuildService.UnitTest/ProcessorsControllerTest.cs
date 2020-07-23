using AutoMapper;
using ComputerBuildService.Server.Contract.Services;
using ComputerBuildService.Server.Controllers;
using ComputerBuildService.Server.Profiles;
using ComputerBuildService.Shared;
using ComputerBuildService.Shared.Models;
using ComputerBuildService.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ComputerBuildService.UnitTest
{
    public class ProcessorsControllerTest
    {
        private IQueryable<ProcessorResponse> GetEntitys()
        {
            return new ProcessorResponse[]
            {
                new ProcessorResponse { Id = 1 },
                new ProcessorResponse { Id = 2 }
            }
            .AsQueryable();
        }

        private Task<ResultObject<T>> GetResultObject<T>(T value, Exception ex = null)
            where T : class
        {
            var result = ResultObject<T>.Create(value);

            if (ex != null) result.AddError(ex);

            return Task.FromResult(result);
        }

        private ProcessorsController CreateController(Mock<IProcessorService> mockService)
        {
            var mockLogger = new Mock<ILogger<ProcessorsController>>();
            var logger = mockLogger.Object;

            return new ProcessorsController(mockService.Object, logger);
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult()
        {
            var mockService = new Mock<IProcessorService>();
            mockService.Setup(repo => repo.GetAll(It.IsAny<Pagination>()))
                .Returns(GetResultObject<IEnumerable<ProcessorResponse>>(GetEntitys().ToArray()));

            var controller = CreateController(mockService);

            var response = await controller.GetAll(new Pagination());

            Assert.IsType<OkObjectResult>(response.Result);
        }

        [Fact]
        public async Task Get_ReturnsOkResult()
        {
            int entityId = 3;
            var mockService = new Mock<IProcessorService>();
            mockService.Setup(repo => repo.Get(entityId))
                .Returns(GetResultObject<ProcessorResponse>(GetEntitys().FirstOrDefault(x => x.Id == entityId)));

            var controller = CreateController(mockService);

            var response = await controller.Get(entityId);

            Assert.IsType<OkObjectResult>(response.Result);
        }

        [Fact]
        public async Task Get_ReturnEntityById()
        {
            int entityId = 1;
            var mockService = new Mock<IProcessorService>();
            mockService.Setup(repo => repo.Get(entityId))
                .Returns(GetResultObject<ProcessorResponse>(GetEntitys().FirstOrDefault(x => x.Id == entityId)));

            var controller = CreateController(mockService);

            var response = (await controller.Get(entityId)).Result as OkObjectResult;

            var resultObjet = Assert.IsType<ResultObject<ProcessorResponse>>(response.Value);

            Assert.Equal(entityId, resultObjet.Value.Id);
        }

        [Fact]
        public async Task Add_ReturnsOkResult()
        {
            var mockService = new Mock<IProcessorService>();
            mockService.Setup(repo => repo.Create(It.IsAny<ProcessorRequest>()))
                .Returns(GetResultObject<ProcessorResponse>(new ProcessorResponse { Id = 3 }));

            var controller = CreateController(mockService);

            var response = await controller.Add(new ProcessorRequest { });

            Assert.IsType<OkObjectResult>(response.Result);
        }

        [Fact]
        public async Task Add_ReturnsResultObject_IsSuccess()
        {
            var mockService = new Mock<IProcessorService>();
            mockService.Setup(repo => repo.Create(It.IsAny<ProcessorRequest>()))
                .Returns(GetResultObject<ProcessorResponse>(new ProcessorResponse { Id = 3 }));

            var controller = CreateController(mockService);

            var response = (await controller.Add(new ProcessorRequest { })).Result as OkObjectResult;

            var resultObject = Assert.IsType<ResultObject<ProcessorResponse>>(response.Value);

            Assert.True(resultObject.IsSuccess);
        }

        [Fact]
        public async Task Update_ReturnsResultObject_IsSuccess()
        {
            var mockService = new Mock<IProcessorService>();
            mockService.Setup(repo => repo.Update(It.IsAny<ProcessorRequest>()))
                .Returns(GetResultObject<ProcessorResponse>(null));

            var controller = CreateController(mockService);

            var response = (await controller.Update(new ProcessorRequest { })).Result as OkObjectResult;

            var resultObject = Assert.IsType<ResultObject<ProcessorResponse>>(response.Value);

            Assert.True(resultObject.IsSuccess);
        }

        [Fact]
        public async Task Update_ReturnsResultObject_IsNoSuccess()
        {
            var mockService = new Mock<IProcessorService>();
            mockService.Setup(repo => repo.Update(null))
                .Returns(GetResultObject<ProcessorResponse>(null, new Exception()));

            var controller = CreateController(mockService);

            var response = (await controller.Update(null)).Result as OkObjectResult;

            var resultObject = Assert.IsType<ResultObject<ProcessorResponse>>(response.Value);

            Assert.False(resultObject.IsSuccess);
        }

        [Fact]
        public async Task Delete_ReturnsResultObject_IsSuccess()
        {
            int entityId = 1;

            var mockService = new Mock<IProcessorService>();
            mockService.Setup(repo => repo.Delete(entityId))
                .Returns(GetResultObject<ProcessorResponse>(null));

            var controller = CreateController(mockService);

            var response = (await controller.Delete(entityId)).Result as OkObjectResult;

            var resultObject = Assert.IsType<ResultObject<ProcessorResponse>>(response.Value);

            Assert.True(resultObject.IsSuccess);
        }

        [Fact]
        public async Task Delete_ReturnsResultObject_IsNoSuccess()
        {
            int entityNoExistingId = 3;

            var mockService = new Mock<IProcessorService>();
            mockService.Setup(repo => repo.Delete(entityNoExistingId))
                .Returns(GetResultObject<ProcessorResponse>(null, new Exception()));

            var controller = CreateController(mockService);

            var response = (await controller.Delete(entityNoExistingId)).Result as OkObjectResult;

            var resultObject = Assert.IsType<ResultObject<ProcessorResponse>>(response.Value);

            Assert.False(resultObject.IsSuccess);
        }
    }
}
