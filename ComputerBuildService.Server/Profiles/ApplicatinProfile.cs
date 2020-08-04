using AutoMapper;
using ComputerBuildService.BL.Models;
using ComputerBuildService.BL.Models.Requests;
using ComputerBuildService.DAL.Entities;
using System.Linq;

namespace ComputerBuildService.Server.Profiles
{
    public class ApplicatinProfile : Profile
    {
        public ApplicatinProfile()
        {
            CreateMap<HardwareItemEntity, HardwareItemResponse>()
                 .ForMember(model => model.PropertysItems, opt => opt
                    .MapFrom(entity => entity.PropertysItems
                        .Select(p => p.Property)
                        .ToList()))
                 .ForMember(model => model.Manufacturer, opt => opt
                    .MapFrom(entity => entity.Manufacturer.Name))
                 .ForMember(model => model.HardwareType, opt => opt
                    .MapFrom(entity => entity.HardwareType.Name));

            CreateMap<HardwareItemRequest, HardwareItemEntity>()
                .ForMember(entity => entity.HardwareType, opt => opt.Ignore())
                .ForMember(entity => entity.Manufacturer, opt => opt.Ignore())
                .ForMember(entity => entity.PropertysItems, opt => opt.Ignore());

            CreateMap<CompatibilityPropertyEntity, CompatibilityPropertyResponse>();
            CreateMap<CompatibilityPropertyRequest, CompatibilityPropertyEntity>();
        }
    }
}
