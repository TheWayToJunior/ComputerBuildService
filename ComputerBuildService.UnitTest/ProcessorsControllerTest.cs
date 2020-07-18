using AutoMapper;
using ComputerBuildService.Server.Controllers;
using ComputerBuildService.Server.IServices;
using ComputerBuildService.Server.Profiles;
using ComputerBuildService.Shared;
using ComputerBuildService.Shared.Models;
using ComputerBuildService.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ComputerBuildService.UnitTest
{
    public class ProcessorsControllerTest
    {
        private IQueryable<Processor> GetEntity()
        {
            return new Processor[]
            {
                new Processor { Id = 1 },
                new Processor { Id = 2 }
            }
            .AsQueryable();
        }

        private IMapper CreateMapper()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ApplicatinProfile());
            });

            return mockMapper.CreateMapper();
        }

        private ProcessorsController CreateController(Mock<IApplicationDbService<Processor, int>> mockService)
        {
            IMapper mapper = CreateMapper();

            var mockLogger = new Mock<ILogger<ProcessorsController>>();
            var logger = mockLogger.Object;

            return new ProcessorsController(mockService.Object, mapper, logger);
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult()
        {
            var mockService = new Mock<IApplicationDbService<Processor, int>>();
            mockService.Setup(repo => repo.GetAll()).Returns(GetEntity());

            var controller = CreateController(mockService);

            var okResult = await controller.GetAll(new Pagination()); /// Тест не будет пройдет в случаи использования 
                                                                      /// ToArrayAsync в методе GetAll
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_ReturnsOkResult()
        {
            int entityId = 3;

            var mockService = new Mock<IApplicationDbService<Processor, int>>();
            mockService.Setup(repo => repo.Include(p => p.IntegratedGraphics)).Returns(GetEntity());

            var controller = CreateController(mockService);

            var okResult = controller.Get(entityId);

            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_ReturnEntityById()
        {
            int entityId = 3;

            var mockService = new Mock<IApplicationDbService<Processor, int>>();
            mockService.Setup(repo => repo.Include(p => p.IntegratedGraphics)).Returns(GetEntity());

            var controller = CreateController(mockService);

            var okResult = controller.Get(entityId).Result as OkObjectResult;

            var entity = Assert.IsType<ProcessorResponse>(okResult.Value);

            Assert.Equal(entityId, entity.Id);
        }

        [Fact]
        public void Add_ReturnsCreatedAtActionResult()
        {
            var mockService = new Mock<IApplicationDbService<Processor, int>>();
            mockService.Setup(repo => repo.Add(It.IsAny<Processor>())).Returns(new Processor { Id = 3 });

            var controller = CreateController(mockService);

            var result = controller.Add(new ProcessorRequest { });

            Assert.IsType<CreatedAtActionResult>(result);
        }

        [Fact]
        public void Add_ReturnsCreatedEntity()
        {
            var mockService = new Mock<IApplicationDbService<Processor, int>>();
            mockService.Setup(repo => repo.Add(It.IsAny<Processor>())).Returns(new Processor { Id = 3 });

            var controller = CreateController(mockService);

            var result = controller.Add(new ProcessorRequest { }) as CreatedAtActionResult;

            var entity = Assert.IsType<ProcessorResponse>(result.Value);

            Assert.Equal(3, entity.Id);
        }

        [Fact]
        public void Update_ReturnsNoContent()
        {
            int entityId = 3;

            var mockService = new Mock<IApplicationDbService<Processor, int>>();
            mockService.Setup(repo => repo.Update(It.IsAny<Processor>())).Verifiable();

            var controller = CreateController(mockService);

            var result = controller.Update(entityId, new ProcessorRequest { Id = entityId });

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Update_ReturnsBadRequest()
        {
            int entityId = 3;

            var mockService = new Mock<IApplicationDbService<Processor, int>>();
            mockService.Setup(repo => repo.Update(It.IsAny<Processor>())).Verifiable();

            var controller = CreateController(mockService);

            var result = controller.Update(entityId, new ProcessorRequest { Id = entityId });

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void Delete_ReturnsNoContent()
        {
            int entityId = 1;

            var mockService = new Mock<IApplicationDbService<Processor, int>>();
            mockService.Setup(repo => repo.Get(entityId)).Returns(GetEntity().First(e => e.Id == entityId));
            mockService.Setup(repo => repo.Remove(It.IsAny<Processor>())).Verifiable();

            var controller = CreateController(mockService);

            var result = controller.Delete(entityId);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Delete_ReturnsNotFound()
        {
            int entityId = 3;

            var mockService = new Mock<IApplicationDbService<Processor, int>>();
            mockService.Setup(repo => repo.Get(entityId)).Returns(GetEntity().FirstOrDefault(e => e.Id == entityId));

            mockService.Setup(repo => repo.Remove(It.IsAny<Processor>())).Verifiable();

            var controller = CreateController(mockService);

            var result = controller.Delete(entityId);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
