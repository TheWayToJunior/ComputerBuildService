//using AutoMapper;
//using ComputerBuildService.Server.Profiles;
//using ComputerBuildService.Server.Services;
//using ComputerBuildService.Shared;
//using Moq;
//using System.Linq;
//using System.Threading.Tasks;
//using Xunit;

//namespace ComputerBuildService.UnitTest
//{
//    public class GenericServiceTest
//    {
//        private IService<Processor, int> CreateService(Mock<IRepository> mockRepo)
//        {
//            var mockMapper = new MapperConfiguration(cfg =>
//            {
//                cfg.AddProfile(new ApplicatinProfile());
//            });

//            return new GenericService<Processor, int>(mockRepo.Object, mockMapper.CreateMapper());
//        }

//        [Fact]
//        public async Task Create_ReturnsResultObject()
//        {
//            var mockRepo = new Mock<IRepository>();
//            mockRepo.Setup(repo => repo.Add<Processor, int>(It.IsAny<Processor>())).Returns(Task.FromResult(new Processor { Id = 3 }));

//            var service = CreateService(mockRepo);

//            var response = await service.Create<ProcessorRequest, ProcessorResponse>(new ProcessorRequest());

//            Assert.IsType<ResultObject<ProcessorResponse>>(response);
//        }

//        [Fact]
//        public async Task Create_ReturnsResultObject_IsSuccess()
//        {
//            var mockRepo = new Mock<IRepository>();
//            mockRepo.Setup(repo => repo.Add<Processor, int>(It.IsAny<Processor>())).Returns(Task.FromResult(new Processor { Id = 3 }));

//            var service = CreateService(mockRepo);

//            var response = await service.Create<ProcessorRequest, ProcessorResponse>(new ProcessorRequest());

//            Assert.True(response.IsSuccess);
//            Assert.Equal(3, response.Value.Id);
//        }

//        [Fact]
//        public async Task Create_ReturnsResultObject_IsNoSuccess()
//        {
//            var mockRepo = new Mock<IRepository>();

//            var service = CreateService(mockRepo);

//            var response = await service.Create<ProcessorRequest, ProcessorResponse>(null);

//            Assert.False(response.IsSuccess);
//        }

//        [Fact]
//        public async Task Update_ReturnsResultObject()
//        {
//            var mockRepo = new Mock<IRepository>();
//            mockRepo.Setup(repo => repo.Update<Processor, int>(It.IsAny<Processor>())).Verifiable();

//            var service = CreateService(mockRepo);

//            var response = await service.Update<ProcessorRequest, ProcessorResponse>(new ProcessorRequest());

//            Assert.IsType<ResultObject<ProcessorResponse>>(response);
//        }

//        [Fact]
//        public async Task Update_ReturnsResultObject_IsSuccess()
//        {
//            var mockRepo = new Mock<IRepository>();
//            mockRepo.Setup(repo => repo.Update<Processor, int>(It.IsAny<Processor>())).Verifiable();

//            var service = CreateService(mockRepo);

//            var response = await service.Update<ProcessorRequest, ProcessorResponse>(new ProcessorRequest());

//            Assert.True(response.IsSuccess);
//        }

//        [Fact]
//        public async Task Update_ReturnsResultObject_IsNoSuccess()
//        {
//            var mockRepo = new Mock<IRepository>();

//            var service = CreateService(mockRepo);

//            var response = await service.Update<ProcessorRequest, ProcessorResponse>(null);

//            Assert.False(response.IsSuccess);
//        }

//        [Fact]
//        public async Task Delete_ReturnsResultObject()
//        {
//            int entityId = 1;

//            var mockRepo = new Mock<IRepository>();
//            mockRepo.Setup(repo => repo.Get<Processor, int>(entityId))
//                .Returns(new Processor[] { new Processor { Id = entityId } }.AsQueryable());

//            mockRepo.Setup(repo => repo.Remove<Processor, int>(It.IsAny<Processor>())).Verifiable();

//            var service = CreateService(mockRepo);

//            var response = await service.Delete<ProcessorResponse>(entityId);

//            Assert.IsType<ResultObject<ProcessorResponse>>(response);
//        }

//        [Fact]
//        public async Task Delete_ReturnsResultObject_IsSuccess()
//        {
//            int entityId = 1;

//            var mockRepo = new Mock<IRepository>();
//            mockRepo.Setup(repo => repo.Get<Processor, int>(entityId))
//                .Returns(new Processor[] { new Processor { Id = entityId } }.AsQueryable());

//            mockRepo.Setup(repo => repo.Remove<Processor, int>(It.IsAny<Processor>())).Verifiable();

//            var service = CreateService(mockRepo);

//            var response = await service.Delete<ProcessorResponse>(entityId);

//            Assert.True(response.IsSuccess);
//        }

//        [Fact]
//        public async Task Delete_ReturnsResultObject_IsNoSuccess()
//        {
//            int entityId = 3;

//            var mockRepo = new Mock<IRepository>();
//            mockRepo.Setup(repo => repo.Get<Processor, int>(entityId))
//                .Returns(new Processor[] { }.AsQueryable());

//            mockRepo.Setup(repo => repo.Remove<Processor, int>(It.IsAny<Processor>())).Verifiable();

//            var service = CreateService(mockRepo);

//            var response = await service.Delete<ProcessorResponse>(entityId);

//            Assert.False(response.IsSuccess);
//        }
//    }
//}
