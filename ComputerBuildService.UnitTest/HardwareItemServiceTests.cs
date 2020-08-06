using AutoMapper;
using ComputerBuildService.BL.Models;
using ComputerBuildService.BL.Services;
using ComputerBuildService.DAL.Entities;
using ComputerBuildService.DAL.IRepositories;
using ComputerBuildService.Server.Profiles;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ComputerBuildService.UnitTest
{
    public class HardwareItemServiceTests
    {
        HardwareTypeEntity[] GetTypes()
        {
            return new HardwareTypeEntity[]
            {
                new HardwareTypeEntity
                {
                    Id = 1,
                    Name = "Processor"
                },

                new HardwareTypeEntity
                {
                    Id = 2,
                    Name = "Motherboard"
                }
            };
        }

        ICollection<CompatibilityPropertyHardwareItem> GetPropertysItems()
        {
            return new List<CompatibilityPropertyHardwareItem>
            {
                new CompatibilityPropertyHardwareItem
                {
                    Property = new CompatibilityPropertyEntity
                    {
                        Id = 1,
                        PropertyName = "AM4",
                        PropertyType = "Socket"
                    }
                },
            };
        }

        IQueryable<HardwareItemEntity> GetItem()
        {
            return new HardwareItemEntity[]
            {
                new HardwareItemEntity
                {
                    Id = 1,
                    /// Processor
                    HardwareType = GetTypes().First(),
                    PropertysItems = GetPropertysItems()
                },

                new HardwareItemEntity
                {
                    Id = 2,
                    /// Processor
                    HardwareType = GetTypes().First()
                },

                new HardwareItemEntity
                {
                    Id = 3,
                    /// Motherboard
                    HardwareType = GetTypes().Last()
                }

           }.AsQueryable();
        }

        [Fact]
        public async Task Get_IsSuccess()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ApplicatinProfile());
            });

            var mockContainer = new Mock<IRepositoryContainer>();

            mockContainer.Setup(c => c.HardwareTypeRepository.SearchByName("processor"))
                .Returns(Task.FromResult(GetTypes().First()));

            mockContainer.Setup(c => c.HardwareItemRepository.GetAllFullObjects())
               .Returns(Task.FromResult(GetItem()));

            var service = new HardwareItemService(mockContainer.Object, mockMapper.CreateMapper());

            var response = await service.GetHardwareItem(new Pagination(), new SelectingHardware
            {
                Type = "processor"
            });

            Assert.IsType<ResultObject<IEnumerable<HardwareItemResponse>>>(response);
            Assert.True(response.IsSuccess);
            Assert.Equal(2, response.Value.Count());

            var any = response.Value.Where(i => i.HardwareType != "Processor").Any();
            Assert.False(any);
        }

        [Fact]
        public async Task Delete_IsSuccess()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ApplicatinProfile());
            });

            var mockContainer = new Mock<IRepositoryContainer>();

            mockContainer.Setup(c => c.HardwareItemRepository.GetFullObject(2)).Returns(Task.FromResult(GetItem().ToArray()[2]));

            mockContainer.Setup(c => c.HardwareItemRepository.RemoveAsync(It.IsAny<HardwareItemEntity>()))
               .Verifiable();

            mockContainer.Setup(c => c.SaveAsync()).Verifiable();

            var service = new HardwareItemService(mockContainer.Object, mockMapper.CreateMapper());

            var response = await service.DeleteHardwareItem(2);

            Assert.IsType<ResultObject<HardwareItemResponse>>(response);
            Assert.True(response.IsSuccess);
            Assert.Null(response.Value);
        }

        [Fact]
        public async Task Add_IsSuccess()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ApplicatinProfile());
            });

            var mockContainer = new Mock<IRepositoryContainer>();

            mockContainer.Setup(c => c.CompatibilityPropertyRepository.Get("Socket", "AM4"))
                .Returns(Task.FromResult(new CompatibilityPropertyEntity { PropertyType = "Socket", PropertyName = "AM4" }));

            mockContainer.Setup(c => c.CompatibilityPropertyRepository.AddAsync(It.IsAny<CompatibilityPropertyEntity>()))
               .Returns(Task.FromResult(new CompatibilityPropertyEntity { Id = 1 }));

            /// TODO : Mock Repositories

            var service = new HardwareItemService(mockContainer.Object, mockMapper.CreateMapper());

            throw new NotImplementedException();
        }

        [Fact]
        public async Task Update_IsSuccess() 
        {
            throw new NotImplementedException();
        }
    }
}
